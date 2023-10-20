﻿using System.Text;
using Kusto.Cloud.Platform.Utils;

using Klipboard.Utils;


namespace Klipboard.Workers
{
    public class ExternalDataQueryWorker : WorkerBase
    {
        private const string NotificationTitle = "External Data Query";
        private const string FirstRowIsHeader = "First Row Is Header";
        private const string NoHeaderRow = "No Header Row";

        public ExternalDataQueryWorker(ISettings settings, INotificationHelper notificationHelper)
            : base(ClipboardContent.CSV | ClipboardContent.Text | ClipboardContent.Files, settings, notificationHelper, new List<string> { FirstRowIsHeader, NoHeaderRow })
        {
        }

        public override string GetMenuText(ClipboardContent content) => $"Paste to External Data Query";

        public override bool IsMenuVisible() => true;

        public override string GetToolTipText() => "Upload clipboard tabular data , free text or a single file to a blob and invoke a an external data query on it";

        public override async Task HandleCsvAsync(string csvData, string? chosenOption)
        {
            var upstreamFileName = FileHelper.CreateUploadFileName("Table", "tsv");
            using var csvStream = new MemoryStream(Encoding.UTF8.GetBytes(csvData));

            await HandleStreamAsync(csvStream, FileHelper.TsvFormatDefinition, upstreamFileName, chosenOption);
        }

        public override async Task HandleTextAsync(string textData, string? chosenOption)
        {
            var upstreamFileName = FileHelper.CreateUploadFileName("Text", "txt");
            using var textStream = new MemoryStream(Encoding.UTF8.GetBytes(textData));

            await HandleStreamAsync(textStream, FileHelper.UnknownFormatDefinition, upstreamFileName, chosenOption);
        }

        public override async Task HandleFilesAsync(List<string> files, string? chosenOption)
        {
            if (files.Count > 1)
            {
                m_notificationHelper.ShowBasicNotification(NotificationTitle, "External data query only supports a single file.");
            }

            var file = files[0];
            var fileInfo = new FileInfo(file);

            if ((fileInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                m_notificationHelper.ShowBasicNotification(NotificationTitle, "External data query does not support directories.");
                return;
            }

            if (!fileInfo.Exists)
            {
                m_notificationHelper.ShowBasicNotification(NotificationTitle, $"File '{file}' does not exist.");
            }

            var dt = DateTime.Now;
            var upsteramFileName = FileHelper.CreateUploadFileName(fileInfo.Name);
            var formatDefintion = FileHelper.GetFormatFromFileName(fileInfo.Name);
            using var dataStream = File.OpenRead(file);

            await HandleStreamAsync(dataStream, formatDefintion, upsteramFileName, chosenOption);
        }

        private async Task HandleStreamAsync(Stream dataStream, FileFormatDefiniton formatDefintion, string upstreamFileName, string? chosenOption)
        {
            using var databaseHelper = new KustoDatabaseHelper(m_settings.GetConfig().ChosenCluster);
            var uploadRes = await databaseHelper.TryUploadFileToEngineStagingAreaAsync(dataStream, upstreamFileName, formatDefintion);
            var firstrowIsHeader = FirstRowIsHeader.Equals(chosenOption);

            if (!uploadRes.Success)
            {
                m_notificationHelper.ShowExtendedNotification(NotificationTitle, $"Failed to upload file", uploadRes.Error);
                return;
            }

            string schemaStr = AppConstants.TextLinesSchemaStr;

            var format = formatDefintion.Extension;
            switch (format)
            {
                case AppConstants.UnknownFormat:
                    var autoDetectRes = await databaseHelper.TryAutoDetectTextBlobScheme(uploadRes.BlobUri);

                    if (autoDetectRes.Success)
                    {
                        schemaStr = autoDetectRes.Schema.ToSchemaString();
                        format = autoDetectRes.Format;
                        break;
                    }

                    schemaStr = AppConstants.TextLinesSchemaStr;
                    format = "txt";
                    break;

                case "csv":
                case "psv":
                case "tsv":
                case "scsv":
                case "sohsv":
                case "tsve":
                case "json":
                case "multijson":
                case "orc":
                case "parquet":
                case "avro":
                    var schemaRes = await databaseHelper.TryGetBlobSchemeAsync(uploadRes.BlobUri, format: format, firstrowIsHeader);
                    if (schemaRes.Success)
                    {
                        schemaStr = schemaRes.TableScheme.ToSchemaString();
                        break;
                    }

                    format = "txt";
                    break;

                default:
                    format = "txt";
                    break;
            }

            var blobPath = uploadRes.BlobUri.SplitFirst("?", out var blboSas);
            var queryBuilder = new StringBuilder();

            queryBuilder.AppendLine("let Klipboard =");
            queryBuilder.Append("externaldata");
            queryBuilder.AppendLine(schemaStr);
            queryBuilder.AppendLine("[");
            queryBuilder.Append(" '");
            queryBuilder.Append(blobPath);
            queryBuilder.Append("' h'?");
            queryBuilder.Append(blboSas);
            queryBuilder.AppendLine("'");
            queryBuilder.AppendLine("]");
            queryBuilder.Append("with(");

            if (format != AppConstants.UnknownFormat)
            {
                queryBuilder.Append("format = '");
                queryBuilder.Append(format);
                queryBuilder.Append("', ");
            }

            queryBuilder.Append("ignoreFirstRecord = ");
            queryBuilder.Append(firstrowIsHeader);
            queryBuilder.AppendLine(");");
            queryBuilder.AppendLine("Klipboard");

            var appConfig = m_settings.GetConfig();
            if (format == "txt" && !string.IsNullOrWhiteSpace(appConfig.PrependFreeTextQueriesWithKql))
            {
                queryBuilder.AppendLine(appConfig.PrependFreeTextQueriesWithKql);
            }

            queryBuilder.AppendLine("| take 100");

            var query = queryBuilder.ToString();
            if (!InlineQueryHelper.TryInvokeInlineQuery(appConfig, appConfig.ChosenCluster.ConnectionString, appConfig.ChosenCluster.DatabaseName, query, out var error))
            {
                m_notificationHelper.ShowExtendedNotification(NotificationTitle, "Failed to invoke external data query", error ?? "Unknown error.");
                return;
            }
        }
    }
}

﻿using Klipboard.Utils;


namespace Klipboard.Workers
{
    public class OptionsWorker : WorkerBase
    {
        public OptionsWorker(WorkerCategory category, AppConfig config, object? icon = null)
            : base(category, ClipboardContent.None, config, icon)
        {
        }

        public override string GetMenuText(ClipboardContent content)
        {
            return "Options";
        }

        public override string GetToolTipText(ClipboardContent content)
        {
            return string.Empty;
        }
    }
}

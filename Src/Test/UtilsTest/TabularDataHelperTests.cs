﻿using Klipboard.Utils;
using TestUtils;

namespace UtilsTest
{
    [TestClass]
    public class TabularDataHelperTests
    {
        [TestMethod]
        public void AnalyzeTsvStringWithHeader()
        {
            var generator = new TableGenerator(autoGenerateScheme: true);
            var tableScheme = generator.GenerateTableScheme();
            var tableData = generator.GenerateTableString(lines: 10, addHeader: true, addNullRows: true, addEmptyRows: true);
            var res = TabularDataHelper.TryAnalyzeTabularData(tableData, "\t", out var scheme, out var firstRowIsHeader);
            
            Assert.IsTrue(res);
            Assert.IsTrue(firstRowIsHeader);
            Assert.AreEqual(tableScheme, scheme.ToString());
        }

        [TestMethod]
        public void AnalyzeTsvStringWithoutHeader()
        {
            var generator = new TableGenerator(autoGenerateScheme: true);
            var tableScheme = generator.GenerateTableScheme(firstRowIsHeader: false);
            var tableData = generator.GenerateTableString(lines: 10, addHeader: false);
            var res = TabularDataHelper.TryAnalyzeTabularData(tableData, "\t", out var scheme, out var firstRowIsHeader);

            Assert.IsTrue(res);
            Assert.IsFalse(firstRowIsHeader);
            Assert.AreEqual(tableScheme, scheme.ToString());
        }

        [TestMethod]
        public void AnalyzeTsvStringWithHeaderOnly()
        {
            var generator = new TableGenerator(autoGenerateScheme: true);
            var tableScheme = generator.GenerateTableScheme(firstRowIsHeader: true);
            var tableData = generator.GenerateTableString(lines: 0, addHeader: true);
            var res = TabularDataHelper.TryAnalyzeTabularData(tableData, "\t", out var scheme, out var firstRowIsHeader);

            Assert.IsTrue(res);
            Assert.IsFalse(firstRowIsHeader);
            Assert.AreNotEqual(tableScheme, scheme.ToString());
        }

        [TestMethod]
        public void AnalyzeTsvStringWithSingleLineNoHeader()
        {
            var generator = new TableGenerator(autoGenerateScheme: true);
            var tableScheme = generator.GenerateTableScheme(firstRowIsHeader: false);
            var tableData = generator.GenerateTableString(lines: 1, addHeader: false);
            var res = TabularDataHelper.TryAnalyzeTabularData(tableData, "\t", out var scheme, out var firstRowIsHeader);

            Assert.IsTrue(res);
            Assert.IsFalse(firstRowIsHeader);
            Assert.AreEqual(tableScheme, scheme.ToString());
        }

        [TestMethod]
        public void AnalyzeCsvStream()
        {
            var generator = new TableGenerator(autoGenerateScheme: true);
            var tableScheme = generator.GenerateTableScheme();
            var tableData = generator.GenerateTableStream(lines: 10, addHeader: true);
            var res = TabularDataHelper.TryAnalyzeTabularData(tableData, ",", out var scheme, out var firstRowIsHeader);

            Assert.IsTrue(res);
            Assert.IsTrue(firstRowIsHeader);
            Assert.AreEqual(tableScheme, scheme.ToString());
        }

        #region Consider if this is needed
        public static readonly string s_testData =
@"col 1	Col 2	Col 3
a	b	c
1	2	3
x	y	z

";

        [TestMethod]
        public void GivenValidTsv_WhenDetectFormat_ResultIsTab()
        {
            Assert.IsTrue(TabularDataHelper.TryDetectTabularTextFormat(s_testData, out var separator));
            Assert.AreEqual('\t', separator);
        }

        [TestMethod]
        public void GivenInvalidTsv_WhenDetectFormat_ResultIsTab()
        {
            var data = s_testData.Replace("z", "z\t");

            Assert.IsFalse(TabularDataHelper.TryDetectTabularTextFormat(data, out var separator));
        }

        [TestMethod]
        public void GivenValidCsv_WhenDetectFormat_ResultIsComa()
        {
            var data = s_testData.Replace('\t', ',');
            Assert.IsTrue(TabularDataHelper.TryDetectTabularTextFormat(data, out var separator));
            Assert.AreEqual(',', separator);
        }
        #endregion
    }
}

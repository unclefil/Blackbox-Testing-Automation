using System;
using System.Collections.Generic;
using Domain;
using IoCNinja;
using Application;
using Excel = Microsoft.Office.Interop.Excel;

namespace Data
{
    public class ExcelWriter : ExcelIO, ITestExecutionGateway, IImplement<ITestExecutionGateway>
    {
        #region variables
        private string _file;
        private string _File
        {
            get
            {
                if (string.IsNullOrEmpty(_file))
                    _file = Application.MySetup.Default.TestDataFolder + MySetup.Default.TestSetxls_FileName;

                return _file;
            }
            set
            {
                _file = value;
            }
        }

        private string _date;
        private string _Date
        {
            get
            {
                if (string.IsNullOrEmpty(_date))
                    _date = System.DateTime.Now.ToString("yyyyMMddHHmmss");

                return _date;
            }
        }

        private string _Browser { get; set; }
        #endregion variables

        private void SaveTestCaseStatus(string browser, ITestCase testCase, string status)
        {
            _Browser = browser;

            SetUp(_File, MySetup.Default.NameOfTestSetTab);

            SaveTestCaseFinalResult(testCase, status);

            SaveAs();

            TearDown();
        }

        private void SaveStepStatus(string browser, ITestCase testCase, ITestStep step)
        {
            _Browser = browser;

            SetUp(_File, testCase.Name);

            SaveStepActualResult(testCase, step);

            SaveAs();

            TearDown();
        }

        private void SaveTestCaseFinalResult(ITestCase testCase, string testCaseStatus)
        {
            SetCellValue(testCase.ID, ExcelConsts.ColumnD, testCaseStatus);
        }

        private void SaveStepActualResult(ITestCase testCase, ITestStep step)
        {
            if (testCase.Schema.ToUpper().Equals(ExcelConsts.SchemaGeneric.ToUpper()))
                SetCellValue(step.ID, SchemaGeneric.ACTUAl_RESULT, step.ActualResult);
            else
                throw new NotImplementedException();
        }

        private void SaveAs()
        {
            _File = string.Format("{0}{1}_{2}_{3}", MySetup.Default.ReportsFolder, _Date, _Browser, MySetup.Default.TestSetxls_FileName).ToString();
            ExcelSaveAs(_File);
        }
    }
}

using System;
using System.Collections.Generic;
using Domain;
using IoCNinja;
using Application;
using Excel = Microsoft.Office.Interop.Excel;

namespace Data
{
    public class ExcelReader : ExcelIO, ITestPlanGateway, IImplement<ITestPlanGateway>
    {
        #region variables
        private List<ITestCase> _testCases;

        private string _file;
        private string _File
        {
            get
            {
                if (string.IsNullOrEmpty(_file))
                    _file = Application.MySetup.Default.TestDataFolder + MySetup.Default.TestSetxls_FileName;

                return _file;
            }
        }
        #endregion variables

        public List<ITestCase> GetActiveTestCases()
        {
            ReadTestCases();

            _testCases.ForEach(testCase => AddTestSteps(testCase));

            return _testCases;
        }

        #region GetActiveTestCases - private methods
        private void ReadTestCases()
        {
            SetUp(_File, MySetup.Default.NameOfTestSetTab);

            CheckIsExcelSetup();
            CheckIsInformationNotAvailable();

            TryReadTestCases();

            TearDown();
        }

        private void TryReadTestCases()
        {
            _testCases = new List<ITestCase>();
            for (var row = ExcelConsts.FirstMainTabRow; row <= RowsCount; row++)
                ReadActiveTestCases(row);
        }

        private void ReadActiveTestCases(int row)
        {
            CheckEndOfFile(row, ExcelConsts.ColumnB);

            ClearTestCaseStatus(row);

            if (IsActive(GetActiveFlag(row)))
                ReadTabNameAndSchema(row);
        }

        private void ClearTestCaseStatus(int row)
        {
            SetCellValue(row, ExcelConsts.ColumnD, "");
            ExcelSave();
        }

        private void ReadTabNameAndSchema(int row)
        {
            string tabName = GetTabName(row);
            if (string.IsNullOrEmpty(tabName))
                Console.WriteLine("Error: In tab " + tabName + " it was found a missing tab name then it was skipped.");
            else
                AddTestCase(row, tabName);
        }

        private void AddTestCase(int row, string tabName)
        {
            ITestCase tc = IoC.Get<ITestCase>();
            tc.ID = row;
            tc.Name = tabName;
            tc.Schema = GetSchema(row);
            _testCases.Add(tc);
        }

        private void CheckIsInformationNotAvailable()
        {
            if (IsInformationNotAvailable())
            {
                ExcelCloseAndQuit();
                throw new NoInformationFoundInTab(TabName);
            }
        }

        private bool IsInformationNotAvailable()
        {
            return RowsCount < ExcelConsts.FirstMainTabRow;
        }

        private bool IsActive(string cellValue)
        {
            return !cellValue.ToUpper().Equals(ExcelConsts.NotActive);
        }

        private string GetActiveFlag(int row)
        {
            string value = GetCellValue(row, ExcelConsts.ColumnA);
            return string.IsNullOrEmpty(value) ? ExcelConsts.NotActive : value;
        }

        private string GetTabName(int row)
        {
            return GetCellValue(row, ExcelConsts.ColumnB);
        }

        private string GetSchema(int row)
        {
            string value = GetCellValue(row, ExcelConsts.ColumnC);
            return string.IsNullOrEmpty(value) ? ExcelConsts.SchemaGeneric : value;
        }
        #endregion

        private void AddTestSteps(ITestCase tc)
        {
            SetUp(_File, tc.Name);

            try
            {
                TryAddTestSteps(tc);
            }
            catch (EndOfFileException) { } // Just stop reading excel
            finally
            {
                ExcelCloseAndQuit();
            }
        }

        #region AddTestSteps(ITestCase tc) - private methods
        private void TryAddTestSteps(ITestCase tc)
        {
            tc.Steps = new List<ITestStep>();

            for (var row = ExcelConsts.FirstTestCaseCommandRow; row <= RowsCount; row ++)
                tc.Steps.Add(TryGetTestStep(row, tc.Schema));
        }

        private ITestStep TryGetTestStep(int stepRow, string schema)
        {
            if (schema.ToUpper().Equals(ExcelConsts.SchemaGeneric.ToUpper()))
                return TryGetTestStepGeneric(stepRow);
            else
                throw new NotImplementedException();
        }

        private ITestStep TryGetTestStepGeneric(int stepRow)
        {
            CheckEndOfFile(stepRow, SchemaGeneric.COMMAND);

            return GetTestStepGeneric(stepRow);
        }

        private ITestStep GetTestStepGeneric(int stepRow)
        {
            var step = IoC.Get<ITestStep>();

            step.Action         = GetStepActionGeneric(stepRow);
            step.ID             = stepRow;
            step.ExpectedResult = GetCellValue(stepRow, SchemaGeneric.EXPECTED_RESULT);

            ClearActualResultGeneric(stepRow);

            return step;
        }

        private IStepAction GetStepActionGeneric(int stepRow)
        {
            var action = IoC.Get<IStepAction>();

            action.Command          = GetCellValue(stepRow, SchemaGeneric.COMMAND);
            action.FindMethod       = GetCellValue(stepRow, SchemaGeneric.FINDMETHOD);
            action.Element          = GetCellValue(stepRow, SchemaGeneric.ELEMENT);
            action.CommandParameter = GetCellValue(stepRow, SchemaGeneric.COMMAND_PARAMETER);

            return action;
        }

        private void ClearActualResultGeneric(int row)
        {
            SetCellValue(row, SchemaGeneric.ACTUAl_RESULT, "");
            ExcelSave();
        }
        #endregion
    }
}

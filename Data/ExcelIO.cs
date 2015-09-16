using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Data
{
    public class ExcelIO
    {
        #region Excel variables
        private Excel.Application _excelApp;
        private Excel.Workbook _excelSpreadsheet;
        private Excel.Worksheet _excelTab;
        private Excel.Range _excelRange;

        private int _rowsCount;
        private int _columnsCount;

        public int RowsCount
        {
            get
            {
                if (_rowsCount <= 0)
                    _rowsCount = _excelRange.Rows.Count;

                return _rowsCount;
            }
            set
            {
                _rowsCount = value;
            }
        }

        public int ColumnsCount
        {
            get
            {
                if (_columnsCount <= 0)
                    _columnsCount = _excelRange.Columns.Count;

                return _columnsCount;
            }
            set
            {
                _columnsCount = value;
            }
        }

        public string TabName { get; set; }
        public string FilePath { get; set; }
        #endregion Excel variables

        public void SetupExcel()
        {
            _excelApp = new Excel.Application();

            CheckIsExcelInstalled();

            _excelApp.DisplayAlerts = false;

            _excelSpreadsheet = (_excelApp.Workbooks.Open(FilePath, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0));
            _excelTab = TryGetExcelTag();
            _excelRange = _excelTab.UsedRange; // range of occupied cell in the tab

            RowsCount = _excelRange.Rows.Count;
            ColumnsCount = _excelRange.Columns.Count;
        }

        private Excel.Worksheet TryGetExcelTag()
        {
            try
            {
                return _excelSpreadsheet.Worksheets.get_Item(TabName);
            }
            catch (Exception ex)
            {
                ExcelCloseAndQuit();
                throw ex;
            }
        }

        public string GetCellValue(int row, int column)
        {
            var value = Convert.ToString((_excelRange.Cells[row, column] as Excel.Range).Value2);
            return string.IsNullOrEmpty(value) ? "" : value;
        }

        public void SetCellValue(int row, int column, string value)
        {
            try
            {
                _excelTab.Cells[row, column] = value;
            }
            catch (Exception ex)
            {
                ExcelCloseAndQuit();
                throw ex;
            }
        }

        public void CheckIsExcelInstalled()
        {
            if (!IsExcelInstalled())
                throw new ExcelNotInstalledException();
        }

        public void CheckIsExcelSetup()
        {
            if (!IsExcelSetup())
                throw new ForgotToCallExcelBaseSetupException();
        }

        public void ExcelCloseAndQuit()
        {
            _excelSpreadsheet.Close();
            _excelApp.Quit();
            ReleaseExcelObjects();
        }

        public void ExcelSave()
        {
            _excelSpreadsheet.Save();
        }

        public void ExcelSaveAs(string filePath)
        {
            _excelSpreadsheet.SaveAs(Filename: filePath);
        }

        #region Utils
        protected void SetUp(string filePath, string tabName)
        {
            FilePath = filePath;
            TabName = tabName;
            SetupExcel();
        }

        protected void TearDown()
        {
            ExcelCloseAndQuit();
        }

        protected void CheckEndOfFile(int row, int col)
        {
            if (string.IsNullOrWhiteSpace(GetCellValue(row, col)))
                throw new EndOfFileException();
        }

        private bool IsExcelInstalled()
        {
            return (_excelApp != null);
        }

        private bool IsExcelSetup()
        {
            return (_excelSpreadsheet != null);
        }

        private void ReleaseExcelObjects()
        {
            ReleaseObject(_excelRange);
            ReleaseObject(_excelTab);
            ReleaseObject(_excelSpreadsheet);
            ReleaseObject(_excelApp);
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                TryReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                WriteInConsoleThatIsUnableToReleaseObject(ex.ToString());
            }
        }

        private void TryReleaseComObject(object obj)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }

        private void WriteInConsoleThatIsUnableToReleaseObject(string exception)
        {
            Console.WriteLine("Unable to release the Object " + exception);
        }

        private static void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        #endregion Utils
    }

    #region Exceptions
    public class ForgotToCallExcelBaseSetupException : Exception { }

    public class ExcelNotInstalledException : Exception
    {
        public ExcelNotInstalledException() : base("Error: Excel looks like not installed in this machine") { }
    }

    public class NoInformationFoundInTab : Exception
    {
        public NoInformationFoundInTab(string tagName) : base("Error: No information was found in tab " + tagName) { }
    }

    public class EndOfFileException : Exception { }
    #endregion Exceptions
}

using System.Collections.Generic;

namespace Data
{
    public class ExcelConsts
    {
        public const int ColumnA = 1;
        public const int ColumnB = 2;
        public const int ColumnC = 3;
        public const int ColumnD = 4;
        public const int ColumnE = 5;
        public const int ColumnF = 6;
        public const int ColumnG = 7;
        public const int FirstTestCaseCommandRow = 2;
        public const int FirstMainTabRow = 2;

        public const string NotActive = "N";
        public const string SchemaGeneric = "GENERIC";

        public static List<string> Schemas = new List<string>()
        {
            SchemaGeneric
        };
    }
}

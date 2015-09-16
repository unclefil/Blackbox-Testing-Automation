using System;

namespace Application
{
    public static class ConfigValidator
    {
        public static void Validate()
        {
            CheckXLSFileExtension(MySetup.Default.TestSetxls_FileName);
        }

        public static void CheckXLSFileExtension(string fileName)
        {
            if (!fileName.EndsWith(".xls"))
                throw new FileHasInvalidFileExtensionUseXLS(fileName);
        }
    }

    public class FileHasInvalidFileExtensionUseXLS : Exception 
    {
        public FileHasInvalidFileExtensionUseXLS(string file) 
            : base("Error: File must end with the extension '.xls'. Invalid Entry: " + file) { }
    }
}

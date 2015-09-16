using System;
using Application;

namespace Reports
{
    public class HtmlDefect
    {
        public string FileExtension { get; set; }

        public string DefectName { get; set; }

        public string FullPath
        {
            get
            {
                var folderPath = MySetup.Default.DefectsFolder;

                return string.Format("{0}{1}{2}", folderPath, DefectName, FileExtension).ToString();
            }
        }

        public string Content { get; set; }
    }
}
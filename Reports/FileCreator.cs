using System;
using System.IO;
using System.Text;

namespace Reports
{
    public class FileCreator
    {
        public static void Create(string path, string content)
        {
            try
            {
                TryCreate(path, content);
            }
            catch (Exception)
            {
                throw new NotAbleToCreateFile(path);
            }
        }

        private static void TryCreate(string path, string content)
        {
            using (FileStream fs = File.Create(path))
            {
                Byte[] _content = new UTF8Encoding(true).GetBytes(content);

                fs.Write(_content, 0, _content.Length);
            }
        }
    }

    #region Exceptions
    public class NotAbleToCreateFile : Exception
    {
        public NotAbleToCreateFile(string path) : base("Error: NotAbleToCreateFile: " + path) { }
    }
    #endregion Exceptions
}
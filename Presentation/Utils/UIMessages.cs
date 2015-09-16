using System;
using System.Windows.Forms;

namespace Presentation
{
    public class UIMessages
    {
        public static void ShowMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new MessageIsNullOrWhiteSpaceException();

            MessageBox.Show(message);
        }

        public static void ShowMessageBool(bool b)
        {
            ShowMessage(b.ToString());
        }

        public static void ShowMessageInt(int i)
        {
            ShowMessage(i.ToString());
        }
    }

    public class MessageIsNullOrWhiteSpaceException : Exception { }
}

namespace Reports
{
    public class HtmlDefectCreator
    {
        public static void Create(HtmlDefect de)
        {
             FileCreator.Create(de.FullPath, de.Content);
        }
    }
}
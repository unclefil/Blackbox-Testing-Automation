using System;
using System.Linq;
using System.Text;
using Application;
using Domain;
using IoCNinja;

namespace Reports
{
    public class HtmlReport : IReports, IImplement<IReports>
    {
        private DateTime _currentDate;

        #region IReports Members
        public void ReportDefect(IDefect de, DateTime now)
        {
            _currentDate = now;

            var htmlDefect = new HtmlDefect
            {
                DefectName = de.Name,
                FileExtension = ".html"
            };

            htmlDefect.Content = GetHtmlTags(FormatDefect(de), htmlDefect.DefectName);

            HtmlDefectCreator.Create(htmlDefect);
        }
        #endregion IReports Members

        #region ReportDefect - private methods
        private string FormatDefect(IDefect de)
        {
            StringBuilder defect = new StringBuilder();

            defect.AppendLine(Bold("Date: ") + GetFullDateTime());
            defect.AppendLine(BR);
            defect.AppendLine(Bold("Environment: ") + Link(GetFirstUrl(de)));
            defect.AppendLine(BR);
            defect.AppendLine(Bold("Browser: ") + de.Browser);
            defect.AppendLine(BR);
            defect.AppendLine(BR);
            defect.AppendLine(GetPassedSteps(de));
            defect.AppendLine(BR);
            defect.AppendLine(Bold("Issue: "));
            defect.AppendLine(BR);
            defect.AppendLine(GetFailedAction(de));

            return defect.ToString();
        }

        private string GetFirstUrl(IDefect de)
        {
            string url = de.TestCase.Steps.FirstOrDefault(step => step.Action.Command.Equals(DomainConsts.GOTOURL)).Action.CommandParameter;

            if (string.IsNullOrWhiteSpace(url))
                url = DomainConsts.NA;

            return url;
        }

        private string GetPassedSteps(IDefect de)
        {
            StringBuilder steps = new StringBuilder();

            steps.AppendLine(Bold("Steps:"));
            steps.AppendLine(BR);

            steps.AppendLine("<ol>");
            de.TestCase.Steps.TakeWhile(step => step.Status.ToLower().Equals("passed")).ToList().ForEach(step =>
            {
                steps.AppendLine(string.Format("{0}{1}{2}", "<li>", GetFormattedAction(de, step), "</li>").ToString());
            });
            steps.AppendLine("</ol>");

            return steps.ToString();
        }

        private string GetFormattedAction(IDefect de, ITestStep step)
        {
            IStepAction action = step.Action;
            int id = step.ID;
            string formattedCommand = "";

            if (action.Command.Equals(DomainConsts.GOTOURL))
                formattedCommand = string.Format("Open URL: {0};", Link(action.CommandParameter)).ToString();
            else if (action.Command.Equals(DomainConsts.CLOSE))
                formattedCommand = "Close window;";
            else if (action.Command.Equals(DomainConsts.CLICK))
                formattedCommand = string.Format("Click on {0};", GetElement(de, id, step)).ToString();
            else if (action.Command.Equals(DomainConsts.CLEAR))
                formattedCommand = string.Format("Clear {0};", GetElement(de, id, step)).ToString();
            else if (action.Command.Equals(DomainConsts.SUBMIT))
                formattedCommand = string.Format("Submit {0};", GetElement(de, id, step)).ToString();
            else if (action.Command.Equals(DomainConsts.SENDKEYS))
                formattedCommand = string.Format("Send keys: '{0}' to {1};", action.CommandParameter, GetElement(de, id, step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ISDISPLAYED))
                formattedCommand = string.Format("Check if {0} is displayed {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ISENABLED))
                formattedCommand = string.Format("Check if {0} is enabled {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ISSELECTED))
                formattedCommand = string.Format("Check if {0} is selected {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ELEMENTTAGNAME))
                formattedCommand = string.Format("Check tag name of {0} - {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ELEMENTINNERTEXT))
                formattedCommand = string.Format("Check inner text of {0} - {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME))
                formattedCommand = string.Format("Check value of attribute '{0}' of {1} - {2};",
                    action.CommandParameter, GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_CSSVALUE_BY_PROPERTYNAME))
                formattedCommand = string.Format("Check CSS style of property '{0}' of {1} - {2};",
                    action.CommandParameter, GetElement(de, id, step), GetActualAndExpected(step)).ToString();

            return formattedCommand;
        }

        private string GetElement(IDefect de, int id, ITestStep step)
        {
            string tagName = "";

            if (WasElementFound(step))
                tagName = IsInput(de, id) ? string.Format("input type={0}", de.InputTypes[id]).ToString() : de.TagNames[id];

            return string.Format("element {0}{1}", tagName, GetIdentifier(step.Action)).ToString();
        }

        private bool WasElementFound(ITestStep step)
        {
            return !step.ActualResult.Equals(MySetup.Default.ElementNotFoundText);
        }

        private bool IsInput(IDefect de, int id)
        {
            return de.TagNames[id].ToLower().Equals("input");
        }

        private string GetIdentifier(IStepAction action)
        {
            return string.Format(" ({0}:'{1}')", action.FindMethod.ToLower(), action.Element).ToString();
        }

        private string GetActualAndExpected(ITestStep step)
        {
            string actual = step.ActualResult ?? "";
            string expected = step.ExpectedResult ?? "";

            string final;

            if (step.Status.ToLower().Equals("failed"))
                final = string.Format("({2}| actual: {0}, expected: {1})", Red(actual), expected, Bold(Red(step.Status))).ToString();
            else
                final = string.Format("({2}| actual: {0}, expected: {1})", actual, expected, step.Status).ToString();

            return final;
        }

        private string GetFailedAction(IDefect de)
        {
            ITestStep failingStep = de.TestCase.Steps.FirstOrDefault(step => step.Status.ToLower().Equals("failed"));
            return GetFormattedFailedAction(de, failingStep);
        }

        private string GetFormattedFailedAction(IDefect de, ITestStep step)
        {
            IStepAction action = step.Action;
            int id = step.ID;
            string formattedCommand = "";

            if (action.Command.Equals(DomainConsts.GOTOURL))
                formattedCommand = string.Format("Not able  to Open URL: {0}. Error: '{1}';", Link(action.CommandParameter), step.ActualResult).ToString();
            else if (action.Command.Equals(DomainConsts.CLOSE))
                formattedCommand = string.Format("Not able to Close window. Error: '{0}';", step.ActualResult).ToString();
            else if (action.Command.Equals(DomainConsts.CLICK))
                formattedCommand = string.Format("Not able to Click on {0}. Error: '{1}';", GetElement(de, id, step), step.ActualResult).ToString();
            else if (action.Command.Equals(DomainConsts.CLEAR))
                formattedCommand = string.Format("Not able to Clear {0}. Error: '{1}';", GetElement(de, id, step), step.ActualResult).ToString();
            else if (action.Command.Equals(DomainConsts.SUBMIT))
                formattedCommand = string.Format("Not able to Submit {0}. Error: '{1}';", GetElement(de, id, step), step.ActualResult).ToString();
            else if (action.Command.Equals(DomainConsts.SENDKEYS))
                formattedCommand = string.Format("Not able to Send keys: '{0}' to {1}. Error: '{2}';", 
                    action.CommandParameter, GetElement(de, id, step), step.ActualResult).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ISDISPLAYED))
                formattedCommand = string.Format("Check if {0} is displayed {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ISENABLED))
                formattedCommand = string.Format("Check if {0} is enabled {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ISSELECTED))
                formattedCommand = string.Format("Check if {0} is selected {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ELEMENTTAGNAME))
                formattedCommand = string.Format("Check tag name of {0} - {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ELEMENTINNERTEXT))
                formattedCommand = string.Format("Check inner text of {0} - {1};", GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME))
                formattedCommand = string.Format("Check value of attribute '{0}' of {1} - {2};",
                    action.CommandParameter, GetElement(de, id, step), GetActualAndExpected(step)).ToString();
            else if (action.Command.Equals(DomainConsts.RETURN_CSSVALUE_BY_PROPERTYNAME))
                formattedCommand = string.Format("Check CSS style of property '{0}' of {1} - {2};",
                    action.CommandParameter, GetElement(de, id, step), GetActualAndExpected(step)).ToString();

            return formattedCommand;
        }

        private string GetHtmlTags(string content, string title)
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<title>");
            html.AppendLine("Defect - " + title);
            html.AppendLine("</title>");
            html.AppendLine("</head>");
            html.AppendLine("<body style='font-family:Arial'>");
            html.AppendLine(content);
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }
        #endregion ReportDefect - private methods

        #region Utils
        private string GetFullDateTime()
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;

            string timeZoneName = localZone.IsDaylightSavingTime(_currentDate) ? localZone.DaylightName : localZone.StandardName;

            return string.Format("{0} ({1})", _currentDate, timeZoneName).ToString();
        }

        private string BR
        {
            get
            {
                return "<br />";
            }
        }

        private string Bold(string content)
        {
            return "<b>" + content + "</b>";
        }

        private string Red(string content)
        {
            return "<span style='color:red'>" + content + "</span>";
        }

        private string Link(string url)
        {
            return "<a href='>" + url + "'>" + url + "</a>";
        }

        private string Textbox(string content)
        {
            return "<input type='text' readonly='readonly' value='>" + content + "' /";
        }
        #endregion Utils
    }
}
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using IoCNinja;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Application
{
    class TestCaseExecutor
    {
        #region variables and constructor
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private ITestPlanGateway _testReader;
        private ITestExecutionGateway _testWriter;
        private readonly ActionExecutor _executor;
        private string _browserName;
        private IDefect _defect;
        private DateTime _whenFailed;

        public TestCaseExecutor(string browserName, IWebDriver driver, WebDriverWait wait)
        {
            _browserName = browserName;
            _driver = driver;
            _wait = wait;
            _testReader = IoC.Get<ITestPlanGateway>();
            _testWriter = IoC.Get<ITestExecutionGateway>();
            _executor = new ActionExecutor(driver, wait);
        }
        #endregion

        public string Execute(ITestCase tc)
        {
            var msg = LogMessageInvalidActions(StepActionValidator.GetInvalidActions(tc.Steps));
            return msg ?? ExecuteTestCase(tc);
        }

        #region Execute - private methods
        private string LogMessageInvalidActions(List<IStepAction> invalidCommands)
        {
            var msg = invalidCommands.Any() ? string.Format("Commands: {0} are not valid", string.Join(", ", invalidCommands)) : null;

            if (invalidCommands.Any())
                throw new Exception(msg);

            return msg;
        }

        private string ExecuteTestCase(ITestCase tc)
        {
            tc.Status = ExecuteSteps(tc);

            _testWriter.SaveTestCaseStatus(_browserName, tc, tc.Status);

            SaveDefectIfAny(tc.Status);

            return tc.Status;
        }

        private string ExecuteSteps(ITestCase tc)
        {
            _defect = IoC.Get<IDefect>();

            tc.Steps.ForEach(step => ExecuteStep(tc, step));

            return GetTestCaseExecutionStatus(tc);
        }

        private void ExecuteStep(ITestCase tc, ITestStep step)
        {
            step.ActualResult = "";

            if (step.Action.IsElementDependent)
                ExecuteElementDependentAction(tc, step);
            else
                TryExecuteNonElementDependentAction(tc, step);

            PrepareDefectIfAny(tc, step);
        }

        #region ExecuteStep - methods
        private void TryExecuteNonElementDependentAction(ITestCase tc, ITestStep step)
        {
            try
            {

                if (step.Action.IsReturningValue)
                    step.ActualResult = _executor.ExecuteNonElementDependentReadingAction(step.Action);
                else
                    _executor.ExecuteNonElementDependentAction(step.Action);                    
            }
            catch (NotAbleToExecuteAction ex)
            {
                step.ActualResult = ex.Message;
            }
            finally
            {
                SaveActualResult(tc, step);
            }
        }

        private void ExecuteElementDependentAction(ITestCase tc, ITestStep step)
        {
            try
            {
                TryExecuteElementDependentAction(tc, step);
            }
            catch (ElementNotFound)
            {
                step.ActualResult = MySetup.Default.ElementNotFoundText;
            }
            catch (NotAbleToClick ex)
            {
                step.ActualResult = ex.Message;
            }
            catch (NotAbleToExecuteAction ex)
            {
                step.ActualResult = ex.Message;
            }
            finally
            {
                SaveActualResult(tc, step);
            }
        }

        private void TryExecuteElementDependentAction(ITestCase tc, ITestStep step)
        {
            var element = GetElement(step);

            SaveElementTag(step.ID, element);

            if (step.Action.IsReturningValue)
                step.ActualResult = _executor.ExecuteElementDependentReadingAction(step.Action, element);
            else
                _executor.ExecuteElementDependentActionCommand(step.Action, element);
        }

        private void SaveElementTag(int stepID, IWebElement element)
        {
            _defect.AddTagName(stepID, element.TagName);
            if (element.TagName.ToLower().Equals("input"))
                _defect.AddInputType(stepID, element.GetAttribute("type"));
        }

        private IWebElement GetElement(ITestStep step)
        {
            try
            {
                return _executor.GetElement(step.Action);
            }
            catch (ElementNotFound)
            {
                return _executor.GetElement(step.Action);
            }
        }

        private void SaveActualResult(ITestCase tc, ITestStep step)
        {
            _testWriter.SaveStepStatus(_browserName, tc, step);
        }
        #endregion ExecuteStep - methods

        #region PrepareDefectIfAny
        private void PrepareDefectIfAny(ITestCase tc, ITestStep step)
        {
            if (IsFailed(step.Status))
                PrepareDefect(tc, step.ID);
        }

        private void PrepareDefect(ITestCase tc, int stepID)
        {
            _whenFailed = DateTime.Now;
            _defect.TestCase = tc;
            _defect.Name = GenerateDefectName(tc.Name);
            _defect.Browser = GetBrowserForDefect();

            TryGetScreenshot(stepID);
        }

        private string GenerateDefectName(string testCaseName)
        {
            var testSetFileName = MySetup.Default.TestSetxls_FileName;
            var testSetExtension = ".xls";
            var testSetName = MySetup.Default.TestSetxls_FileName.Substring(0, testSetFileName.Length - testSetExtension.Length);

            var strDate = _whenFailed.ToString("yyyyMMddHHmmss");

            return string.Format("DE_{0}_{1}_{2}", testSetName, testCaseName, strDate).ToString();
        }

        private string GetBrowserForDefect()
        {
            ICapabilities c = ((RemoteWebDriver)_driver).Capabilities;
            return string.Format("{0} (version: {1}, IsJavaScriptEnabled: {2})", c.BrowserName.ToUpper(), c.Version, c.IsJavaScriptEnabled).ToString();
        }

        private void TryGetScreenshot(int stepID)
        {
            try
            {
                ScreenshotTaker.GetAndSaveScreenshot(_driver, GetDefectFilePath(), ImageFormat.Png);
                _defect.AddScreenshotInfo(stepID, GetDefectFilePath());
            }
            catch (Exception) { }
        }

        private string GetDefectFilePath()
        {
            return string.Format("{0}{1}.png", MySetup.Default.DefectsFolder, _defect.Name).ToString();
        }
        #endregion PrepareDefectIfAny

        private string GetTestCaseExecutionStatus(ITestCase tc)
        {
            var anyFailed = tc.Steps.Any(x => IsFailed(x.Status));

            return (anyFailed ? DomainConsts.FAILED : DomainConsts.PASSED);
        }

        private void SaveDefectIfAny(string tcStatus)
        {
            if (IsFailed(tcStatus))
                IoC.Get<IReports>().ReportDefect(_defect, _whenFailed);
        }

        private bool IsFailed(string status)
        {
            return status.ToLower().Equals(DomainConsts.FAILED.ToLower());
        }
        #endregion Execute - private methods
    }
}

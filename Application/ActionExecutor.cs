using System;
using System.Collections.Generic;
using Domain;
using IoCNinja;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Application
{
    class ActionExecutor
    {
        #region variables and constructor
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private IWebElement _lastElement;
        private IStepAction _actualAction;
        private IStepAction _lastAction;

        public ActionExecutor(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }
        #endregion variables and constructor

        public void ExecuteElementDependentActionCommand(IStepAction action, IWebElement element)
        {
            _actualAction = action;

            if (_actualAction.IsParameterized)
                ExecuteCommandDependentOfElementParameterized(element);
            else
                ExecuteCommandDependentOfElementNotParameterized(element);
        }

        public void ExecuteNonElementDependentAction(IStepAction action)
        {
            _actualAction = action;

            ExecuteCommandNotDependentOfElement();
        }

        #region Action Commands
        private void ExecuteCommandDependentOfElementParameterized(IWebElement element)
        {
            if (CommandIs(DomainConsts.SENDKEYS))
                TrySendKeys(element);
        }

        private void ExecuteCommandDependentOfElementNotParameterized(IWebElement element)
        {
            if (CommandIs(DomainConsts.CLICK))
                TryClick(element);
            else if (CommandIs(DomainConsts.CLEAR))
                TryClear(element);
            else if (CommandIs(DomainConsts.SUBMIT))
                TrySubmit(element);
            else if (CommandIs(DomainConsts.SWITCH_TO_FRAME))
                TrySwitchToFrame(element);
        }

        private void ExecuteCommandNotDependentOfElement()
        {
            if (CommandIs(DomainConsts.GOTOURL))
                TryGoToUrl();
            else if (CommandIs(DomainConsts.CLOSE))
                TryClose();
            else if (CommandIs(DomainConsts.MESSAGEBOX))
                TryMessageBox();
            else if (CommandIs(DomainConsts.POPUP_JSALERT_ACCEPT))
                TryPopupJSAlertAccept();
            else if (CommandIs(DomainConsts.POPUP_JSCONFIRM_ACCEPT))
                TryPopupJSAlertAccept();
            else if (CommandIs(DomainConsts.POPUP_JSCONFIRM_DISMISS))
                TryPopupJSAlertDismiss();
            else if (CommandIs(DomainConsts.POPUP_JSPROMPT_SENDKEYS))
                TryPopupJSAlertSendKeys();
            else if (CommandIs(DomainConsts.POPUP_JSPROMPT_ACCEPT))
                TryPopupJSAlertAccept();
            else if (CommandIs(DomainConsts.SWITCH_TO_WINDOW))
                TrySwitchToWindow();
            else if (CommandIs(DomainConsts.SWITCH_TO_DEFAULT_CONTENT))
                TrySwitchToDefaultContent();
            else if (CommandIs(DomainConsts.SWITCH_TO_PARENT_FRAME))
                TrySwitchToParentFrame();
        }

        private void TrySendKeys(IWebElement element)
        {
            try
            {
                element.SendKeys(_actualAction.CommandParameter);
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TryClick(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception)
            {
                throw new NotAbleToClick("Element is not clickable. Other element would receive the click.");
            }
        }

        private void TryClear(IWebElement element)
        {
            try
            {
                element.Clear();
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TrySubmit(IWebElement element)
        {
            try
            {
                element.Submit();
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TrySwitchToFrame(IWebElement element)
        {
            try
            {
                _driver.SwitchTo().Frame(element);
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TryGoToUrl()
        {
            try
            {
                _driver.Navigate().GoToUrl(_actualAction.CommandParameter);
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TryClose()
        {
            try
            {
                _driver.Close();
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TryPopupJSAlertAccept()
        {
            try
            {                
                IAlert alert = _driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException)
            {
                throw new NotAbleToExecuteAction("No Alert Present");
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TryPopupJSAlertDismiss()
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                alert.Dismiss();
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TryPopupJSAlertSendKeys()
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                alert.SendKeys(_actualAction.CommandParameter);
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TrySwitchToWindow()
        {
            try
            {
                _driver.SwitchTo().Window(_actualAction.CommandParameter);               
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TrySwitchToDefaultContent()
        {
            try
            {
                _driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }


        private void TrySwitchToParentFrame()
        {
            try
            {
                _driver.SwitchTo().ParentFrame();
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void TryMessageBox()
        {
            try
            {
                IoC.Get<IPresentation>().ShowMessage(_actualAction.CommandParameter);
            }
            catch (Exception ex)
            {
                ThrowNotAbleToExecuteAction(ex);
            }
        }

        private void ThrowNotAbleToExecuteAction(Exception ex)
        {
            throw new NotAbleToExecuteAction(ex.Message);
        }
        #endregion Action Commands

        public string ExecuteElementDependentReadingAction(IStepAction action, IWebElement element)
        {
            _actualAction = action;

            return _actualAction.IsParameterized ? GetElementAttributeOrCssValue(element) : TryGetOneElementProperty(element);
        }

        public string ExecuteNonElementDependentReadingAction(IStepAction action)
        {
            _actualAction = action;

            return GetPopupJSAlertGetText();
        }

        #region Reading Commands - private methods
        private string GetElementAttributeOrCssValue(IWebElement element)
        {
            if (CommandIs(DomainConsts.RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME))
                return TryGetAttribute(element);
            else
                return TryGetCssValue(element);
        }

        private string TryGetAttribute(IWebElement element)
        {
            try
            {
                return element.GetAttribute(_actualAction.CommandParameter);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string TryGetCssValue(IWebElement element)
        {
            try
            {
                return element.GetCssValue(_actualAction.CommandParameter);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string TryGetOneElementProperty(IWebElement element)
        {
            try
            {
                return GetElementProperties(element)[_actualAction.Command];
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private Dictionary<string, string> GetElementProperties(IWebElement element)
        {
            return new Dictionary<string, string>
            {
                { DomainConsts.RETURN_ISDISPLAYED, element.Displayed.ToString() },
                { DomainConsts.RETURN_ISENABLED, element.Enabled.ToString() },
                { DomainConsts.RETURN_ISSELECTED, element.Selected.ToString() },
                { DomainConsts.RETURN_ELEMENTTAGNAME, element.TagName },
                { DomainConsts.RETURN_ELEMENTINNERTEXT, element.Text }
            };
        }

        private string GetPopupJSAlertGetText()
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                return alert.Text;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion Reading Commands - private methods

        public IWebElement GetElement(IStepAction action)
        {
            _actualAction = action;

            IWebElement element = CanReuseLastElement() ? _lastElement : TryToFindElement(TryBy());

            SaveActionAndElement(_actualAction, element);

            return element;
        }

        #region GetElement - private methods
        private bool CanReuseLastElement()
        {
            return (_lastAction != null && _actualAction.Element == _lastAction.Element && _lastAction.IsReturningValue && _actualAction.FindMethod == _lastAction.FindMethod);
        }

        private IWebElement TryToFindElement(By by)
        {
            try
            {
                //return _wait.Until<IWebElement>(x => x.FindElement(by));
                //return _wait.Until(ExpectedConditions.ElementIsVisible(by));
                return _wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (Exception)
            {
                throw new ElementNotFound(by.ToString());
            }
        }

        private By TryBy()
        {
            return GetBy()[_actualAction.FindMethod];
        }

        private Dictionary<string, By> GetBy()
        {
            if (_actualAction.FindMethod.Equals(DomainConsts.CLASSNAME))
                return new Dictionary<string, By> 
                { 
                    { DomainConsts.CLASSNAME, By.ClassName(_actualAction.Element) } 
                };
            else
                return new Dictionary<string, By> 
                {
                    { DomainConsts.ID, By.Id(_actualAction.Element) },
                    { DomainConsts.NAME, By.Name(_actualAction.Element) },
                    { DomainConsts.LINKTEXT, By.LinkText(_actualAction.Element) },
                    { DomainConsts.CSSSELECTOR, By.CssSelector(_actualAction.Element) },
                    { DomainConsts.PARTIALLINKTEXT, By.PartialLinkText(_actualAction.Element) },
                    { DomainConsts.TAGNAME, By.TagName(_actualAction.Element) },
                    { DomainConsts.XPATH, By.XPath(_actualAction.Element) }
                };
        }

        private void SaveActionAndElement(IStepAction action, IWebElement element)
        {
            _lastAction = action;
            _lastElement = element;
        }
        #endregion GetElement - private methods

        #region Utils
        private bool CommandIs(string command)
        {
            return string.Equals(_actualAction.Command, command);
        }
        #endregion Utils
    }

    #region Exceptions
    public class ElementNotFound : Exception
    {
        public ElementNotFound(string element) : base("Error: ElementNotFound: " + element) { }
    }

    public class NotAbleToClick : Exception
    {
        public NotAbleToClick(string message) : base(message) { }
    }

    public class NotAbleToExecuteAction : Exception
    {
        public NotAbleToExecuteAction(string message) : base(message) { }
    }
    #endregion Exceptions
}
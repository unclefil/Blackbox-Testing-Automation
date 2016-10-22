using System;
using System.Collections.Generic;

namespace Domain
{
    public static class DomainConsts
    {
        public const string PASSED = "Passed";
        public const string FAILED = "Failed";

        public const string NA = "N/A";

        public const string SchemaGeneric = "GENERIC";

        public static List<string> Schemas = new List<string>(){
            SchemaGeneric
        };

        #region Commands Without Element
        public const string GOTOURL = "GOTOURL(STRURL)";
        public const string CLOSE = "CLOSE()";
        public const string POPUP_JSALERT_ACCEPT = "POPUP_JSALERT_ACCEPT()";
        public const string POPUP_JSALERT_GETTEXT = "POPUP_JSALERT_GETTEXT()";
        public const string POPUP_JSCONFIRM_ACCEPT = "POPUP_JSCONFIRM_ACCEPT()";
        public const string POPUP_JSCONFIRM_DISMISS = "POPUP_JSCONFIRM_DISMISS()";
        public const string POPUP_JSCONFIRM_GETTEXT = "POPUP_JSCONFIRM_GETTEXT()";
        public const string POPUP_JSPROMPT_SENDKEYS = "POPUP_JSPROMPT_SENDKEYS(INPUTSTR)";
        public const string POPUP_JSPROMPT_ACCEPT = "POPUP_JSPROMPT_ACCEPT()";
        public const string POPUP_JSPROMPT_GETTEXT = "POPUP_JSPROMPT_GETTEXT()";
        public const string MESSAGEBOX = "MESSAGEBOX(MESSAGE)";
        #endregion

        #region Commands depeding of Element only
        public const string CLICK = "CLICK()";
        public const string CLEAR = "CLEAR()";
        public const string SUBMIT = "SUBMIT()";
        #endregion

        #region Commands depeding of Element and parameter
        public const string SENDKEYS = "SENDKEYS(INPUTSTR)";
        #endregion

        #region Commands depeding of Element only that return value
        public const string RETURN_ISDISPLAYED = "RETURN_ISDISPLAYED()";
        public const string RETURN_ISENABLED = "RETURN_ISENABLED()";
        public const string RETURN_ISSELECTED = "RETURN_ISSELECTED()";
        public const string RETURN_ELEMENTTAGNAME = "RETURN_ELEMENTTAGNAME()";
        public const string RETURN_ELEMENTINNERTEXT = "RETURN_ELEMENTINNERTEXT()";
        #endregion

        #region Commands depeding of Element and parameter that return value
        public const string RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME = "RETURN_ATTRIBUTEVALUE(ATTRIBUTENAME)";
        public const string RETURN_CSSVALUE_BY_PROPERTYNAME = "RETURN_CSSVALUE(PROPERTYNAME)";
        #endregion

        public static List<string> Commands = new List<string>
        {
            GOTOURL,
            CLOSE,
            POPUP_JSALERT_ACCEPT,
            POPUP_JSALERT_GETTEXT,
            POPUP_JSCONFIRM_ACCEPT,
            POPUP_JSCONFIRM_DISMISS,
            POPUP_JSCONFIRM_GETTEXT,
            POPUP_JSPROMPT_SENDKEYS,
            POPUP_JSPROMPT_ACCEPT,
            POPUP_JSPROMPT_GETTEXT,
            MESSAGEBOX,
            CLICK,
            CLEAR,
            SUBMIT,
            SENDKEYS,
            RETURN_ISDISPLAYED,
            RETURN_ISENABLED,
            RETURN_ISSELECTED,
            RETURN_ELEMENTTAGNAME,
            RETURN_ELEMENTINNERTEXT,
            RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME,
            RETURN_CSSVALUE_BY_PROPERTYNAME
        };

        public static List<string> CommandsDependingOfElement = new List<string>
        {
            CLICK,
            CLEAR,
            SUBMIT,
            SENDKEYS,
            RETURN_ISDISPLAYED,
            RETURN_ISENABLED,
            RETURN_ISSELECTED,
            RETURN_ELEMENTTAGNAME,
            RETURN_ELEMENTINNERTEXT,
            RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME,
            RETURN_CSSVALUE_BY_PROPERTYNAME
        };

        public static List<string> CommandsDependingOfParameter = new List<string>
        {
            GOTOURL,
            POPUP_JSPROMPT_SENDKEYS,
            MESSAGEBOX,
            SENDKEYS,
            RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME,
            RETURN_CSSVALUE_BY_PROPERTYNAME
        };

        public static List<string> CommandsReturningValue = new List<string>
        {
            RETURN_ISDISPLAYED,
            RETURN_ISENABLED,
            RETURN_ISSELECTED,
            RETURN_ELEMENTTAGNAME,
            RETURN_ELEMENTINNERTEXT,
            RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME,
            RETURN_CSSVALUE_BY_PROPERTYNAME,
            POPUP_JSALERT_GETTEXT,
            POPUP_JSCONFIRM_GETTEXT,
            POPUP_JSPROMPT_GETTEXT
        };

        #region FindMethods
        public const string ID = "ID";
        public const string LINKTEXT = "LINKTEXT";
        public const string CLASSNAME = "CLASSNAME";
        public const string CSSSELECTOR = "CSSSELECTOR";
        public const string NAME = "NAME";
        public const string PARTIALLINKTEXT = "PARTIALLINKTEXT";
        public const string TAGNAME = "TAGNAME";
        public const string XPATH = "XPATH";

        public static List<string> FindMethods = new List<string>
        {
            ID,
            LINKTEXT,
            CLASSNAME,
            CSSSELECTOR,
            NAME,
            PARTIALLINKTEXT,
            TAGNAME,
            XPATH
        };
        #endregion
    }
}

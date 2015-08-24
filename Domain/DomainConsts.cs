﻿using System;
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
        public const string RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME = "RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME(ATTRIBUTENAME)";
        public const string RETURN_CSSVALUE_BY_PROPERTYNAME = "RETURN_CSSVALUE_BY_PROPERTYNAME(PROPERTYNAME)";
        #endregion

        public static List<string> ReturningValueCommands = new List<string>
        {
            RETURN_ISDISPLAYED,
            RETURN_ISENABLED,
            RETURN_ISSELECTED,
            RETURN_ELEMENTTAGNAME,
            RETURN_ELEMENTINNERTEXT,
            RETURN_ATTRIBUTEVALUE_BY_ATTRIBUTENAME,
            RETURN_CSSVALUE_BY_PROPERTYNAME
        };

        public static List<string> Commands = new List<string>
        {
            GOTOURL,
            CLOSE,
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
            RETURN_CSSVALUE_BY_PROPERTYNAME
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
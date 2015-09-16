using System.Collections.Generic;
using Application;
using Domain;
using IoCNinja;

namespace Reports
{
    public class Defect : IDefect, IImplement<IDefect>
    {
        #region variables
        private Dictionary<int, string> _tagNames;
        private Dictionary<int, string> _inputTypes;
        private Dictionary<int, string> _screenshots;
        #endregion variables
        
        #region IDefect Members
        public string Name { get; set; }
        
        public string Browser { get; set; }
        
        public ITestCase TestCase { get; set; }
        
        public Dictionary<int, string> TagNames
        { 
            get
            {
                if (_tagNames == null)
                    _tagNames = new Dictionary<int, string>();
                
                return _tagNames;
            }
            private set
            {
                _tagNames = value;
            }
        }
        
        public Dictionary<int, string> InputTypes
        { 
            get
            {
                if (_inputTypes == null)
                    _inputTypes = new Dictionary<int, string>();
                
                return _inputTypes;
            }
            private set
            {
                _inputTypes = value;
            }
        }
        
        public Dictionary<int, string> Screenshots
        { 
            get
            {
                if (_screenshots == null)
                    _screenshots = new Dictionary<int, string>();
                
                return _screenshots;
            }
            private set
            {
                _screenshots = value;
            }
        }
        
        public void AddTagName(int stepID, string tagName)
        {
            TagNames.Add(stepID, tagName);
        }
        
        public void AddInputType(int stepID, string inputType)
        {
            InputTypes.Add(stepID, inputType);
        }

        public void AddScreenshotInfo(int stepID, string filePath)
        {
            Screenshots.Add(stepID, filePath);
        }
        #endregion IDefect Members
    }
}
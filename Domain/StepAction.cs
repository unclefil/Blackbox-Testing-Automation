using IoCNinja;

namespace Domain
{
    class StepAction : IStepAction, IImplement<IStepAction>
    {
        private string _command;
        private string _findMethod;
        private string _element;
        private string _commandParameter;

        #region IStepAction Members
        public string Command
        {
            get
            {
                return _command;
            }
            set
            {
                StepActionValidator.ValidateCommand(value);
                _command = value.ToUpper();
                SetFlags();
            }
        }

        public string FindMethod
        {
            get
            {
                return _findMethod;
            }
            set
            {
                _findMethod = string.IsNullOrEmpty(value) ? DomainConsts.NA : value.ToUpper();

                if (!_findMethod.Equals(DomainConsts.NA))
                    StepActionValidator.ValidateFindMethod(_findMethod);
            }
        }

        public string Element
        {
            get
            {
                return _element;
            }
            set
            {
                _element = string.IsNullOrEmpty(value) ? DomainConsts.NA : value;
            }
        }

        public string CommandParameter
        {
            get
            {
                return _commandParameter;
            }
            set
            {
                _commandParameter = string.IsNullOrEmpty(value) ? DomainConsts.NA : value;
            }
        }

        public bool IsElementDependent { get; private set; }

        public bool IsParameterized { get; private set; }

        public bool IsReturningValue { get; private set; }
        #endregion

        private void SetFlags()
        {
            IsReturningValue = DomainConsts.CommandsReturningValue.Contains(Command);
            IsElementDependent = DomainConsts.CommandsDependingOfElement.Contains(Command);
            IsParameterized = DomainConsts.CommandsDependingOfParameter.Contains(Command);
        }
    }
}

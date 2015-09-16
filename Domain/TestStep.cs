using System;
using IoCNinja;

namespace Domain
{
    class TestStep : ITestStep, IImplement<ITestStep>
    {
        #region ITestStep Members
        public int ID { get; set; }

        public IStepAction Action { get; set; }

        public string ActualResult { get; set; }

        public string ExpectedResult { get; set; }

        public string Status
        {
            get
            {
                return (string.Equals(Convert.ToString(ActualResult), Convert.ToString(ExpectedResult))) ?
                    DomainConsts.PASSED : DomainConsts.FAILED;
            }
        }
        #endregion
    }
}

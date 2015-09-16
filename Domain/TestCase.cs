using System;
using System.Collections.Generic;
using IoCNinja;

namespace Domain
{
    class TestCase : ITestCase, IImplement<ITestCase>
    {
        private string _schema;

        #region ITestCase Members
        public int ID { get; set; }

        public string Name { get; set; }

        public string Schema
        {
            get
            {
                return _schema;
            }
            set
            {
                CheckSchema(value);
                _schema = value.ToUpper();
            }
        }

        public string Status { get; set; }

        public List<ITestStep> Steps { get; set; }
        #endregion

        private void CheckSchema(string schema)
        {
            if (!DomainConsts.Schemas.Contains(schema.ToUpper()))
                throw new InvalidSchemaName();
        }
    }

    public class InvalidSchemaName : Exception { }
}

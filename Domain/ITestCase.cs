using System.Collections.Generic;

namespace Domain
{
    public interface ITestCase
    {
        int ID { get; set; }
        string Name { get; set; }
        string Schema { get; set; }
        string Status { get; set; }
        List<ITestStep> Steps { get; set; }
    }
}

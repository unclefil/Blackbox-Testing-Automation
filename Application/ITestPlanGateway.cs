using System.Collections.Generic;
using Domain;

namespace Application
{
    public interface ITestPlanGateway
    {
        List<ITestCase> GetActiveTestCases();
    }
}

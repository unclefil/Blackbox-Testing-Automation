using Domain;

namespace Application
{
    public interface ITestExecutionGateway
    {
        void SaveTestCaseStatus(string browser, ITestCase testCase, string status);
        void SaveStepStatus(string browser, ITestCase testCase, ITestStep testStep);
    }
}

namespace Domain
{
    public interface ITestStep
    {
        int ID { get; set; }
        IStepAction Action { get; set; }
        string ActualResult { get; set; }
        string ExpectedResult { get; set; }
        string Status { get; }
    }
}

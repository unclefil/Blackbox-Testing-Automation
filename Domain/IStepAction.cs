namespace Domain
{
    public interface IStepAction
    {
        string Command { get; set; }
        string FindMethod { get; set; }
        string Element { get; set; }
        string CommandParameter { get; set; }
        bool IsElementDependent { get; }
        bool IsParameterized { get; }
        bool IsReturningValue { get; }
    }
}

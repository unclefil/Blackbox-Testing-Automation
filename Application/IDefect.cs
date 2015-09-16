using System.Collections.Generic;
using Domain;

namespace Application
{
    public interface IDefect
    {
        string Name { get; set; }

        string Browser { get; set; }

        ITestCase TestCase { get; set; }

        Dictionary<int, string> TagNames { get; }

        Dictionary<int, string> InputType { get; }

        Dictionary<int, string> Screenshots { get; }

        void AddTagName(int stepID, string tagName);

        void AddInputType(int stepID, string inputType);

        void AddScreenshotInfo(int stepID, string filePath);
    }
}

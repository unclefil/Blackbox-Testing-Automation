using System;

namespace Application
{
    public interface IReports
    {
        void ReportDefect(IDefect de, DateTime now);
    }
}

using System;

namespace Application
{
    public interface IPresentation
    {
        void Show();

        void ShowMessage(string message);

        void TreatException(Exception e);
    }
}

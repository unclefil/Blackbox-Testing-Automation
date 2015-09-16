using Presentation.Model;

namespace Presentation.Controller
{
    public interface ISettingsView
    {
        bool IsVisible { get; set; }

        void SetController(SettingsController controller);

        void ShowForm(SettingsModel model);

        void CloseForm();
    }
}

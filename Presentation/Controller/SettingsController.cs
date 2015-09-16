using System;
using Application;
using Presentation.Model;
using IoCNinja;

namespace Presentation.Controller
{
    public class SettingsController : IPresentation, IImplement<IPresentation>
    {
        #region variables
        private ISettingsView _view;
        private ISettingsView _View
        {
            get
            {
                if (_view == null)
                {
                    _view = IoC.Get<ISettingsView>();
                    _view.IsVisible = false;
                    _view.SetController(this);
                }

                return _view;
            }
            set
            {
                _view = value;
            }
        }

        private SettingsModel _model;
        private SettingsModel _Model
        {
            get
            {
                if (_model == null)
                    _model = new SettingsModel();

                return _model;
            }
            set
            {
                _model = value;
            }
        }
        #endregion variables

        #region IPresentation Members
        public void Show()
        {
            _View.ShowForm(_Model);
        }

        public void ShowMessage(string message)
        {
            UIMessages.ShowMessage(message);
        }

        public void TreatException(Exception e)
        {
            ShowMessage(e.Message);
        }
        #endregion

        public void SaveAndStartExecution()
        {
            _Model.SaveChanges();

            _View.IsVisible = false;
            _View.CloseForm();

            TryExecute();
        }

        private void TryExecute()
        {
            try
            {
                IoC.Get<ITestSetExecutor>().Execute();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
    }
}

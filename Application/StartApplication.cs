using IoCNinja;

namespace Application
{
    public class StartApplication :  IStartApplication, IImplement<IStartApplication>
    {
        #region IStartApplication Members
        public void Start()
        {
            var presentation = IoC.Get<IPresentation>();

            presentation.Show();
        }
        #endregion
    }
}

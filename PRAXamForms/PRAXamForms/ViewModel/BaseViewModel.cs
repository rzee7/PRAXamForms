using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Navigation


        public INavigation Navigation
        {
            get
            {
                var mainPage = Application.Current.MainPage;
                if (mainPage is NavigationPage)
                {
                    return (INavigation)mainPage;
                }
                return Application.Current.MainPage.Navigation;
            }
        }

        #endregion

        #region Property Changed Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}

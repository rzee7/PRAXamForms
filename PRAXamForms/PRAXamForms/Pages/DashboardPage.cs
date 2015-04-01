using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
    public class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            var lbl = new Label() { XAlign = TextAlignment.Center, YAlign = TextAlignment.Center };
            lbl.SetBinding(Label.TextProperty, "UserName");
            Content = lbl;
        }
    }
}

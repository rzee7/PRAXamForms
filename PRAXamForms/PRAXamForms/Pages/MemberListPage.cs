using PRAXamForms.Cell;
using PRAXamForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
    public class MemberListPage : ContentPage
    {
        public MemberViewModel ViewModel { get { return BindingContext as MemberViewModel; } }
        public MemberListPage()
        {

            BindingContext = new MemberViewModel();

            var list = new ListView();
            list.ItemTemplate = new DataTemplate(typeof(MemberCell));
            list.ItemsSource = ViewModel.Items;
            Content = list;
        }
    }
}

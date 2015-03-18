using PRAXamForms.Core;
using PRAXamForms.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms.ViewModel
{
    public class MemberViewModel : BaseListViewModel<MemberInfo>
    {
        public MemberViewModel()
        {
            MemberService.GetDataAsync(MemberService.MemberList, (members) =>
            {
                if (members != null)
                    Items.Add(members.Members);
            });

            SelectionChangedCommand = new Command(async () =>
            {
                if (SelectedItem != null)
                {
                    await Navigation.PushAsync(new MemberDetails()
                    {
                        BindingContext = SelectedItem
                    });
                    SelectedItem = null;
                }
            });
        }
    }
}

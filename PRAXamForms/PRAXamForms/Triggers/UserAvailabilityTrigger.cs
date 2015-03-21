using PRAXamForms.Core;
using PRAXamForms.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
    public class UserAvailabilityTrigger : TriggerAction<Entry>
    {

        public UserAvailabilityTrigger()
        {
        }
        protected override void Invoke(Entry sender)
        {
            if (!UserInfo.IsEmailValid(sender.Text)) return;

            MemberService.PostData<bool, string>(MemberService.UserAvailabale, HttpMethod.Put, sender.Text).ContinueWith(t =>
            {
                if (t.Result)
                {
                    sender.BackgroundColor = Color.Green;
                }
                else
                {
                    sender.BackgroundColor = Color.Red;
                }
            });
            }
    }
}

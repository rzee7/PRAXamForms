using PRAXamForms.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms
{
    public class EmailValidationTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            bool isValid = UserInfo.IsEmailValid(sender.Text);
            sender.TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}

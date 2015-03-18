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
            bool isValid = IsEmailValid(sender.Text);
            sender.TextColor = isValid ? Color.Default : Color.Red;
        }

        bool IsEmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
    }
}

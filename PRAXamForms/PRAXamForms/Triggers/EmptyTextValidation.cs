using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PRAXamForms 
{
    public class EmptyTextValidation : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            sender.TextColor = sender.Text.Length > 0 ? Color.Default : Color.Red;
        }
    }
}

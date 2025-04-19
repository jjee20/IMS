using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Views.IViews
{
    public interface IMessageBase
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Message");
        }
    }
}

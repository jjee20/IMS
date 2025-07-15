using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.ThinkEE;

namespace RavenTech_ERP.Helpers;
public class ChoiceSelectedEventArgs : EventArgs
{
    public Choice SelectedChoice
    {
        get; set;
    }
}

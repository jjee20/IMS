using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Presenters
{
    public interface ICrudView
    {
        event EventHandler AddNewEvent;
        event EventHandler SaveEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SearchEvent;
        event EventHandler PrintEvent;
        event EventHandler RefreshEvent;

        bool IsEdit { get; set; }
        string SearchValue { get; set; }
    }
}

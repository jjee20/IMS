using RavenTech_ERP.Presenters.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Views.IViews
{
    public interface ICrudView<TEntity> : IViewWithMessage
    {
        TEntity SelectedItem { get; }
        IEnumerable<TEntity> Items { set; }
        string SearchValue { get; }

        void ClearFields();
    }
}

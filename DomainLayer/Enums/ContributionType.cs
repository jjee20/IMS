using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum ContributionType
    {
        SSS,
        [Display(Name = "Pag-ibig")]
        PagIbig,
        PhilHealth
    }
}

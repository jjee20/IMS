using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.InventoryViewModels
{
    public class BillTypeViewModel
    {
        public int BillTypeId { get; set; }
        public string BillTypeName { get; set; }
        public string Description { get; set; }
        [Display(Name = "")]
        public byte[] Edit { get; set; }
        [Display(Name = "")]
        public byte[] Delete { get; set; }
    }
}

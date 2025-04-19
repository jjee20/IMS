using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.InventoryViewModels
{
    public class PurchaseTypeViewModel
    {
        public int PurchaseTypeId { get; set; }
        public string PurchaseTypeName { get; set; }
        public string Description { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}

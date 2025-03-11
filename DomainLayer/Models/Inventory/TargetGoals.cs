using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Inventory
{
    public class TargetGoals
    {
        [Key]
        public int TargetGoalsId { get; set; }
        public double MonthlyItemSold { get; set; }
        public double MonthlySales{ get; set; }
        public double AnnualSales{ get; set; }
    }
}

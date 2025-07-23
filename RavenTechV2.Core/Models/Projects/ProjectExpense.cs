using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Projects;
public class ProjectExpense
{
    [Key]
    public int ProjectExpenseId { get; set; }
    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public Project Project { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string ExpenseType { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
}
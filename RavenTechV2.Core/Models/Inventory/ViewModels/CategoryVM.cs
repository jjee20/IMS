using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.Inventory.ViewModels;
public class CategoryVM
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

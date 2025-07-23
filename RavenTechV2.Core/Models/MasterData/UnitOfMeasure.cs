using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.MasterData;
public class UnitOfMeasure
{
    [Key]
    public int UnitOfMeasureId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Symbol { get; set; }
}

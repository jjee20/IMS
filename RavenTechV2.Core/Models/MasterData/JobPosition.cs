using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.MasterData;
public class JobPosition
{
    [Key]
    public int JobPositionId { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
}


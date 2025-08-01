﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Models.MasterData;
public class Branch
{
    [Key]
    public int BranchId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactPerson { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

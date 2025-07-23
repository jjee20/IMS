﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RavenTechV2.Core.Models.UserManagement;
public class Role : IdentityRole
{
    public string Description { get; set; }
}

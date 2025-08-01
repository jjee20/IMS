﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModels.AccountViewModels
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string TaskRoles { get; set; }
        public byte[] Edit { get; set; }
        public byte[] Delete { get; set; }
    }
}

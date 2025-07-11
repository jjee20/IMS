using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CommonServices
{
    public static class AppUserHelper
    {
        public static List<TaskRoles> TaskRoles(string roles)
        {
            List<TaskRoles> retrievedRoles = roles
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(r => Enum.Parse<TaskRoles>(r))
                .ToList();
            return retrievedRoles;
        }



        public static bool AllowedToAdd(List<TaskRoles> roles)
        {
            return roles.Contains(DomainLayer.Enums.TaskRoles.Add) ? true : false;
        }
        public static bool AllowedToEdit(List<TaskRoles> roles)
        {
            return roles.Contains(DomainLayer.Enums.TaskRoles.Edit) ? true : false;
        }
        public static bool AllowedToDelete(List<TaskRoles> roles)
        {
            return roles.Contains(DomainLayer.Enums.TaskRoles.Delete) ? true : false;
        }
        public static bool AllowedToView(List<TaskRoles> roles)
        {
            return roles.Contains(DomainLayer.Enums.TaskRoles.View) ? true : false;
        }
        public static bool AllowedToOverride(List<TaskRoles> roles)
        {
            return roles.Contains(DomainLayer.Enums.TaskRoles.Override) ? true : false;
        }
    }
}

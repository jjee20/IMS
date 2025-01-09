using DomainLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ServiceLayer.Services.CommonServices
{
    public static class EnumHelper
    {
        public static IEnumerable<EnumItemViewModel> EnumToEnumerable<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .Select(e => new EnumItemViewModel
                       {
                           Id = Convert.ToInt32(e),
                           Name = GetDisplayNameOrDefault(e)
                       });
        }

        private static string GetDisplayNameOrDefault<T>(T enumValue) where T : Enum
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var displayNameAttribute = fieldInfo?.GetCustomAttribute<DisplayNameAttribute>();

            return displayNameAttribute?.DisplayName ?? enumValue.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Data;

namespace RavenTechV2.Helpers;
public class ValidationErrorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is ObservableValidator validator && parameter is string propertyName)
        {
            var errors = validator.GetErrors(propertyName);
            return errors is null ? null : string.Join("\n", errors);
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) => throw new NotImplementedException();
}

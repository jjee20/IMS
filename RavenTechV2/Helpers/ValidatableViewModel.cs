using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RavenTechV2.Helpers;

public abstract class ValidatableViewModel : ObservableValidator
{
    /// <summary>
    /// Gets all validation error messages for a given property as a single string (newline-separated).
    /// </summary>
    public string GetError(string propertyName)
    {
        var errors = GetErrors(propertyName);
        return errors != null
            ? string.Join(Environment.NewLine, errors.OfType<ValidationResult>().Select(e => e.ErrorMessage))
            : string.Empty;
    }

    /// <summary>
    /// Indexer for easy XAML binding: {Binding [PropertyName]}
    /// </summary>
    public string this[string propertyName] => GetError(propertyName);
}

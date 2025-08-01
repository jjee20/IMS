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

public abstract class ValidatableViewModel<TModel> : ObservableObject, INotifyDataErrorInfo
    where TModel : class, new()
{
    protected readonly Dictionary<string, List<string>> _errors = new();

    public TModel Model
    {
        get;
    }

    public ValidatableViewModel(TModel model = null)
    {
        Model = model ?? new TModel();
        // Optionally, validate all properties at start:
        ValidateAllProperties();
    }

    public bool HasErrors => _errors.Count > 0;
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    public IEnumerable GetErrors(string propertyName)
        => propertyName != null && _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;

    protected void ValidateProperty(object value, string propertyName)
    {
        if (_errors.ContainsKey(propertyName))
            _errors.Remove(propertyName);

        var results = new List<ValidationResult>();
        var context = new ValidationContext(Model) { MemberName = propertyName };
        Validator.TryValidateProperty(value, context, results);

        if (results.Any())
            _errors[propertyName] = results.Select(r => r.ErrorMessage).ToList();

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        OnPropertyChanged(nameof(HasErrors));
    }

    public bool ValidateAllProperties()
    {
        _errors.Clear();
        var properties = typeof(TModel).GetProperties();
        foreach (var prop in properties)
        {
            var value = prop.GetValue(Model);
            ValidateProperty(value, prop.Name);
        }
        return !HasErrors;
    }
}

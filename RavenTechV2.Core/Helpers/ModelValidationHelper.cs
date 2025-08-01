using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Core.Helpers;
public class ModelValidationHelper
{
    public string Validate(object model)
    {
        var errorMessage = "";
        List<ValidationResult> results = new List<ValidationResult>();
        ValidationContext context = new ValidationContext(model);
        var isValid = Validator.TryValidateObject(model, context, results, true);
        if (isValid == false)
        {
            foreach (var item in results)
                errorMessage += "- " + item.ErrorMessage + "\n";
        }

        return errorMessage.Trim();
    }
}

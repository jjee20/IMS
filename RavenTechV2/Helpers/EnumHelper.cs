using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTechV2.Helpers;
public class EnumHelper
{
    public static ObservableCollection<EnumDescriptionItem<T>> GetEnumDescriptionList<T>() where T : Enum
    {
        return new ObservableCollection<EnumDescriptionItem<T>>(
            Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new EnumDescriptionItem<T>
                {
                    Value = e,
                    Description = GetDescription(e)
                }));
    }

    private static string GetDescription<T>(T value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;
        return attr?.Description ?? value.ToString();
    }
}

public class EnumDescriptionItem<T>
{
    public string Description
    {
        get; set;
    }
    public T Value
    {
        get; set;
    }

    public override string ToString() => Description;
}


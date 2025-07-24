using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace RavenTechV2.Models;
public class NavMenuItem
{
    public string Title { get; set; }
    public string IconGlyph { get; set; }
    public string PageKey { get; set; } // A unique key or the View/Page class name
    public ObservableCollection<NavMenuItem> SubItems { get; set; } = new();
    public bool IsVisible { get; set; } = true; // Set false to hide for certain roles
    public RelayCommand Command { get; set; }
}

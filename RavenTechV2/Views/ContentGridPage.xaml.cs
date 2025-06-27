﻿using Microsoft.UI.Xaml.Controls;

using RavenTechV2.ViewModels;

namespace RavenTechV2.Views;

public sealed partial class ContentGridPage : Page
{
    public ContentGridViewModel ViewModel
    {
        get;
    }

    public ContentGridPage()
    {
        ViewModel = App.GetService<ContentGridViewModel>();
        InitializeComponent();
    }
}

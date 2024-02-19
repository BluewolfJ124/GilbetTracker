﻿using System;
using Assist.Models.Enums;
using Assist.ViewModels.Settings;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Assist.Views.Settings.Pages;

public partial class GeneralSettingsPageView : UserControl
{
    private readonly GeneralSettingsPageViewModel _viewModel;

    public GeneralSettingsPageView()
    {
        DataContext = _viewModel = new GeneralSettingsPageViewModel();
        InitializeComponent();
    }

    private async void General_Init(object? sender, EventArgs e)
    {
        if (Design.IsDesignMode)
            return; 

        await _viewModel.Setup();
    }

    private void ResolutionControl_Changed(object? sender, SelectionChangedEventArgs e)
    {
        if (Design.IsDesignMode)
            return;


        var num = Convert.ToInt32(_viewModel.ResolutionItems[_viewModel.ResolutionIndex].Tag);
        _viewModel.SetResolution((EResolution)num);
    }
}
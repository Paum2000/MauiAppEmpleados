using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppEmpleados.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        string title;
    }
}

using MauiAppEmpleados.ViewModels;

namespace MauiAppEmpleados.Views;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsViewModel _vm;
    public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }
}
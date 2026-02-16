using MauiAppEmpleados.ViewModels;

namespace MauiAppEmpleados.Views;

public partial class EmpleadosPage : ContentPage
{
    private readonly EmpleadosViewModel _vm;

    public EmpleadosPage(EmpleadosViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Carga automática al entrar
        if (_vm.GetEmpleadosCommand.CanExecute(null))
            _vm.GetEmpleadosCommand.Execute(null);
    }
}
using MauiAppEmpleados.ViewModels;

namespace MauiAppEmpleados.Views;

public partial class DepartamentosPage : ContentPage
{
    private DepartamentosViewModel _vm;
    public DepartamentosPage(DepartamentosViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.GetDepartamentosCommand.Execute(null);
    }
}
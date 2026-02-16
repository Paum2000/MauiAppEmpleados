using MauiAppEmpleados.ViewModels;

namespace MauiAppEmpleados.Views;

public partial class EmpleadoEditorPage : ContentPage
{
    private readonly EmpleadoEditorViewModel _vm;

    public EmpleadoEditorPage(EmpleadoEditorViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }
}
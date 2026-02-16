using MauiAppEmpleados.ViewModels;

namespace MauiAppEmpleados.Views;

public partial class DepartamentoEditorPage : ContentPage
{
    private readonly DepartamentoEditorViewModel _vm;
    public DepartamentoEditorPage(DepartamentoEditorViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }
}
using MauiAppEmpleados.Views;

namespace MauiAppEmpleados
{
    public partial class AppShell : Shell
    {
        public AppShell()
	{
		InitializeComponent();

        // Rutas de Empleados
        Routing.RegisterRoute(nameof(EmpleadoEditorPage), typeof(EmpleadoEditorPage));
        
        // Rutas de Departamentos (Añade esta línea)
        Routing.RegisterRoute(nameof(DepartamentoEditorPage), typeof(DepartamentoEditorPage));
	}
    }
}

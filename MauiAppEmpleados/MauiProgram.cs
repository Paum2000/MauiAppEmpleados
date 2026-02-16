
using MauiAppEmpleados.Services;
using MauiAppEmpleados.ViewModels;
using MauiAppEmpleados.Views;
using Microsoft.Extensions.Logging;

namespace MauiAppEmpleados
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // ==============================================
            // 1. SERVICIOS (Singleton: una única instancia para toda la app)
            // ==============================================
            builder.Services.AddSingleton<ApiService>();

            // ==============================================
            // 2. VIEWMODELS (Transient: se crean cada vez que se piden)
            // ==============================================

            // Empleados
            builder.Services.AddTransient<EmpleadosViewModel>();
            builder.Services.AddTransient<EmpleadoEditorViewModel>();

            // Home 
            builder.Services.AddTransient<HomeViewModel>();

            // Departamentos 
            builder.Services.AddTransient<DepartamentosViewModel>();
            builder.Services.AddTransient<DepartamentoEditorViewModel>();

            // Settings
            builder.Services.AddTransient<SettingsViewModel>();

            // ==============================================
            // 3. VISTAS (Pages)
            // ==============================================

            // Empleados
            builder.Services.AddTransient<EmpleadosPage>();
            builder.Services.AddTransient<EmpleadoEditorPage>();

            // Otras
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<DepartamentosPage>();
            builder.Services.AddTransient<DepartamentoEditorPage>();

            return builder.Build();
        }
    }
}

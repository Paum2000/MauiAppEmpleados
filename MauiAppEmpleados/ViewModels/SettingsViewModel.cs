using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MauiAppEmpleados.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        public List<string> Themes { get; } = new() { "Sistema", "Claro", "Oscuro" };

        [ObservableProperty]
        string selectedTheme;

        public SettingsViewModel()
        {
            Title = "Ajustes";
            // Cargar estado actual (comprueba null en Application.Current)
            var current = Application.Current?.UserAppTheme ?? AppTheme.Unspecified;
            SelectedTheme = current == AppTheme.Unspecified ? "Sistema" :
                            current == AppTheme.Light ? "Claro" : "Oscuro";
        }

        partial void OnSelectedThemeChanged(string value)
        {
            var app = Application.Current;
            if (app == null)
                return;

            switch (value)
            {
                case "Claro":
                    app.UserAppTheme = AppTheme.Light;
                    break;
                case "Oscuro":
                    app.UserAppTheme = AppTheme.Dark;
                    break;
                default:
                    app.UserAppTheme = AppTheme.Unspecified;
                    break;
            }
            // Aquí podrías guardar la preferencia usando Preferences.Set(...)
        }

        [RelayCommand]
        async Task OpenAbout()
        {
            var shell = Shell.Current;
            if (shell != null)
            {
                await shell.DisplayAlert("Acerca de", "Gestión Empleados v1.0 con MAUI y FastAPI", "OK");
                return;
            }

            var main = Application.Current?.MainPage;
            if (main != null)
            {
                await main.DisplayAlert("Acerca de", "Gestión Empleados v1.0 con MAUI y FastAPI", "OK");
            }
            // Si tampoco hay MainPage, simplemente no mostrar nada.
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppEmpleados.Models;
using MauiAppEmpleados.Services;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace MauiAppEmpleados.ViewModels
{
    [QueryProperty(nameof(Empleado), "Empleado")]
    public partial class EmpleadoEditorViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        [ObservableProperty]
        Empleado empleado;

        public EmpleadoEditorViewModel(ApiService apiService)
        {
            _apiService = apiService;
            // Inicializamos uno vacío por si entramos en modo "Crear"
            Empleado = new Empleado();
        }

        // Método que salta cuando recibimos datos de navegación
        partial void OnEmpleadoChanged(Empleado value)
        {
            if (value == null)
            {
                Title = "Nuevo Empleado";
                Empleado = new Empleado();
            }
            else
            {
                Title = "Editar Empleado";
                // Ya tenemos los datos cargados
            }
        }

        [RelayCommand]
        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(Empleado.Name))
            {
                await Shell.Current.DisplayAlert("Error", "El nombre es obligatorio", "OK");
                return;
            }

            IsBusy = true;
            bool exito;

            if (Empleado.Id == 0)
                exito = await _apiService.AddEmpleadoAsync(Empleado);
            else
                exito = await _apiService.UpdateEmpleadoAsync(Empleado);

            IsBusy = false;

            if (exito)
            {
                await Shell.Current.DisplayAlert("Éxito", "Guardado correctamente", "OK");
                await Shell.Current.GoToAsync(".."); // Volver atrás
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo guardar", "OK");
            }
        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

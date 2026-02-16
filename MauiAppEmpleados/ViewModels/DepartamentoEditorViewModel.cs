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
    [QueryProperty(nameof(Departamento), "Departamento")]
    public partial class DepartamentoEditorViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        [ObservableProperty]
        Departamento departamento;

        public DepartamentoEditorViewModel(ApiService apiService)
        {
            _apiService = apiService;
            // Inicializar por defecto para creación
            Departamento = new Departamento();
        }

        partial void OnDepartamentoChanged(Departamento value)
        {
            if (value == null)
            {
                Title = "Nuevo Departamento";
                Departamento = new Departamento();
            }
            else
            {
                Title = "Editar Departamento";
            }
        }

        [RelayCommand]
        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(Departamento.Name))
            {
                await Shell.Current.DisplayAlert("Error", "El nombre es obligatorio", "OK");
                return;
            }

            IsBusy = true;
            bool exito;

            if (Departamento.Id == 0)
                exito = await _apiService.AddDepartamentoAsync(Departamento);
            else
                exito = await _apiService.UpdateDepartamentoAsync(Departamento);

            IsBusy = false;

            if (exito)
            {
                await Shell.Current.GoToAsync(".."); // Volver atrás
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Hubo un problema al guardar", "OK");
            }
        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

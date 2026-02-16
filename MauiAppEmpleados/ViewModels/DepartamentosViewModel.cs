using CommunityToolkit.Mvvm.Input;
using MauiAppEmpleados.Models;
using MauiAppEmpleados.Services;
using MauiAppEmpleados.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static System.Net.WebRequestMethods;

namespace MauiAppEmpleados.ViewModels
{
    public partial class DepartamentosViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Departamento> Departamentos { get; } = new();

        public DepartamentosViewModel(ApiService apiService)
        {
            _apiService = apiService;
            Title = "Departamentos";
        }

        [RelayCommand]
        async Task GetDepartamentos()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                var lista = await _apiService.GetDepartamentosAsync();
                Departamentos.Clear();
                foreach (var item in lista) Departamentos.Add(item);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Navegar a CREAR (Sin parámetros)
        [RelayCommand]
        async Task GoToCreate()
        {
            await Shell.Current.GoToAsync(nameof(DepartamentoEditorPage));
        }

        // Navegar a EDITAR (Pasando el objeto)
        [RelayCommand]
        async Task GoToEdit(Departamento depto)
        {
            if (depto == null) return;

            var navParam = new Dictionary<string, object>
        {
            { "Departamento", depto }
        };
            await Shell.Current.GoToAsync(nameof(DepartamentoEditorPage), navParam);
        }

        // BORRAR
        [RelayCommand]
        async Task Delete(Departamento depto)
        {
            bool confirm = await Shell.Current.DisplayAlert("Eliminar", $"¿Borrar el departamento {depto.Name}?", "Sí", "No");
            if (confirm)
            {
                bool success = await _apiService.DeleteDepartamentoAsync(depto.Id);
                if (success)
                {
                    Departamentos.Remove(depto);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo eliminar (puede que tenga empleados asignados)", "OK");
                }
            }
        }
    }
}

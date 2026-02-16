using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppEmpleados.Models;
using MauiAppEmpleados.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static System.Net.WebRequestMethods;

namespace MauiAppEmpleados.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private List<Empleado> _todosLosEmpleados = new();

        public HomeViewModel(ApiService apiService)
        {
            _apiService = apiService;
            Title = "Panel de Control";
        }

        [ObservableProperty]
        int totalEmpleados;

        [ObservableProperty]
        int totalDepartamentos;

        [ObservableProperty]
        ObservableCollection<Departamento> departamentos = new();

        [ObservableProperty]
        ObservableCollection<Empleado> empleadosFiltrados = new();

        [ObservableProperty]
        Departamento? selectedDepartment;

        // Cuando se selecciona un departamento en el Picker/ComboBox
        partial void OnSelectedDepartmentChanged(Departamento? value)
        {
            if (value == null)
            {
                EmpleadosFiltrados = new ObservableCollection<Empleado>(_todosLosEmpleados);
                return;
            }

            var filtrados = _todosLosEmpleados.Where(e => e.DepartmentId == value.Id);
            EmpleadosFiltrados = new ObservableCollection<Empleado>(filtrados);
        }

        [RelayCommand]
        async Task RefreshStats()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                // 1. Cargar datos de la API
                var deps = await _apiService.GetDepartamentosAsync();
                var emps = await _apiService.GetEmpleadosAsync();

                _todosLosEmpleados = emps;

                // 2. Actualizar contadores
                TotalDepartamentos = deps.Count;
                TotalEmpleados = emps.Count;

                // 3. Actualizar listas
                Departamentos = new ObservableCollection<Departamento>(deps);

                // Si hay un departamento seleccionado, filtramos, si no, mostramos todos
                if (SelectedDepartment != null)
                    OnSelectedDepartmentChanged(SelectedDepartment);
                else
                    EmpleadosFiltrados = new ObservableCollection<Empleado>(emps);
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

        // Inicializar al entrar
        public async Task InitializeAsync()
        {
            await RefreshStats();
        }
    }
}

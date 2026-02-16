using CommunityToolkit.Mvvm.Input;
using MauiAppEmpleados.Models;
using MauiAppEmpleados.Services;
using MauiAppEmpleados.Views;
using System.Collections.ObjectModel;
using static System.Net.WebRequestMethods;

namespace MauiAppEmpleados.ViewModels
{
    public partial class EmpleadosViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Empleado> Empleados { get; } = new();

        public EmpleadosViewModel(ApiService apiService)
        {
            _apiService = apiService;
            Title = "Directorio de Empleados";
        }

        [RelayCommand]
        async Task GetEmpleados()
        {
            if (IsBusy) return;
            IsBusy = true;

            var lista = await _apiService.GetEmpleadosAsync();
            Empleados.Clear();
            foreach (var emp in lista) Empleados.Add(emp);

            IsBusy = false;
        }

        [RelayCommand]
        async Task SearchById(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                await GetEmpleados(); // Si borran el texto, recargamos todo
                return;
            }

            if (int.TryParse(query, out int id))
            {
                IsBusy = true;
                var emp = await _apiService.GetEmpleadoByIdAsync(id);
                Empleados.Clear();
                if (emp != null) Empleados.Add(emp);
                else await Shell.Current.DisplayAlert("Info", "No encontrado", "OK");
                IsBusy = false;
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Introduce un ID numérico válido", "OK");
            }
        }

        // Navegar para CREAR (sin parámetros)
        [RelayCommand]
        async Task GoToCreate()
        {
            await Shell.Current.GoToAsync(nameof(EmpleadoEditorPage));
        }

        // Navegar para EDITAR (pasando el empleado seleccionado)
        [RelayCommand]
        async Task GoToEdit(Empleado empleado)
        {
            if (empleado == null) return;

            var navParam = new Dictionary<string, object>
        {
            { "Empleado", empleado }
        };
            await Shell.Current.GoToAsync(nameof(EmpleadoEditorPage), navParam);
        }

        // Eliminar desde la lista (Swipe)
        [RelayCommand]
        async Task Delete(Empleado empleado)
        {
            bool answer = await Shell.Current.DisplayAlert("Borrar", $"¿Eliminar a {empleado.Name}?", "Sí", "No");
            if (answer)
            {
                await _apiService.DeleteEmpleadoAsync(empleado.Id);
                Empleados.Remove(empleado);
            }
        }
    }
}

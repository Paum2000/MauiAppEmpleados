using MauiAppEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;

namespace MauiAppEmpleados.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        // Android Emulator usa 10.0.2.2, Windows usa localhost.
        private const string BaseUrlAndroid = "http://10.0.2.2:8081";
        private const string BaseUrlWindows = "http://localhost:8081";

        public ApiService()
        {
            _httpClient = new HttpClient();

            // Detectar plataforma para asignar la URL base correcta
#if ANDROID
        _httpClient.BaseAddress = new Uri(BaseUrlAndroid);
#else
            _httpClient.BaseAddress = new Uri(BaseUrlWindows);
#endif
        }

        // =========================================================
        // SECCIÓN: EMPLEADOS
        // =========================================================

        // 1. OBTENER TODOS (Lista)
        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Empleado>>("/empleados/");
                return response ?? new List<Empleado>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleados: {ex.Message}");
                return new List<Empleado>();
            }
        }

        // 2. BUSCAR POR ID (Detalle)
        public async Task<Empleado?> GetEmpleadoByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Empleado>($"/empleados/{id}");
            }
            catch (HttpRequestException)
            {
                // Devuelve null si no existe (404)
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar empleado: {ex.Message}");
                return null;
            }
        }

        // 3. CREAR (POST)
        public async Task<bool> AddEmpleadoAsync(Empleado empleado)
        {
            try
            {
                // Enviamos el objeto a /empleados/
                var response = await _httpClient.PostAsJsonAsync("/empleados/", empleado);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear empleado: {ex.Message}");
                return false;
            }
        }

        // 4. ACTUALIZAR (PATCH)
        public async Task<bool> UpdateEmpleadoAsync(Empleado empleado)
        {
            try
            {
                // Para editar, la URL debe incluir el ID: /empleados/{id}
                var response = await _httpClient.PatchAsJsonAsync($"/empleados/{empleado.Id}", empleado);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empleado: {ex.Message}");
                return false;
            }
        }

        // 5. ELIMINAR (DELETE)
        public async Task<bool> DeleteEmpleadoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/empleados/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar empleado: {ex.Message}");
                return false;
            }
        }

        // =========================================================
        // SECCIÓN: DEPARTAMENTOS
        // =========================================================

        // 1. OBTENER TODOS
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Departamento>>("/departamentos/");
                return response ?? new List<Departamento>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener departamentos: {ex.Message}");
                return new List<Departamento>();
            }
        }

        // 2. BUSCAR POR ID
        public async Task<Departamento?> GetDepartamentoByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Departamento>($"/departamentos/{id}");
            }
            catch
            {
                return null;
            }
        }

        // 3. CREAR (POST)
        public async Task<bool> AddDepartamentoAsync(Departamento departamento)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/departamentos/", departamento);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear departamento: {ex.Message}");
                return false;
            }
        }

        // 4. ACTUALIZAR (PATCH)
        public async Task<bool> UpdateDepartamentoAsync(Departamento departamento)
        {
            try
            {
                var response = await _httpClient.PatchAsJsonAsync($"/departamentos/{departamento.Id}", departamento);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar departamento: {ex.Message}");
                return false;
            }
        }

        // 5. ELIMINAR (DELETE)
        public async Task<bool> DeleteDepartamentoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/departamentos/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar departamento: {ex.Message}");
                return false;
            }
        }
    }
}

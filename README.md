# MauiAppEmpleados

[![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/maui/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

**MauiAppEmpleados** es una aplicación multiplataforma moderna diseñada para la **gestión de personal**. Este proyecto consume una **API REST** para realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar), demostrando la integración de servicios externos en aplicaciones móviles y de escritorio.

---

## Capturas de Pantalla

| Home Page | Menú Desplegable |
|---|---|
| <img src="https://github.com/user-attachments/assets/44812edb-f272-4b31-8038-1908c19e54f0" width="450"> | <img src="https://github.com/user-attachments/assets/30de354b-a039-4524-bb71-567227243937" width="220"> |

| Departamentos | Empleados | Configuración |
|---|---|---|
| <img src="https://github.com/user-attachments/assets/8121d78f-1cde-4d70-9652-c695178e55c6" width="280"> | <img src="https://github.com/user-attachments/assets/29490350-e635-415a-8e94-f44867bb8a75" width="280"> | <img src="https://github.com/user-attachments/assets/1e188604-a5f2-4684-9eef-ac46920781f3" width="280"> |

---

## Características Principales

* **Gestión de Empleados:** Registro completo, edición de perfiles y visualización de listas desde el servidor.
* **Gestión de Departamentos:** Organización por áreas mediante formularios dinámicos.
* **Consumo de API REST:** Sincronización de datos en tiempo real con un servicio backend.
* **Interfaz Adaptable:** Experiencia de usuario optimizada para Android, iOS y Windows.
* **Arquitectura Robusta:** Uso estricto del patrón MVVM para facilitar el mantenimiento.

---

## Tecnologías y Librerías

* **Framework:** [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/) (.NET 8.0).
* **Patrón de Diseño:** **MVVM** (Model-View-ViewModel).
* **Comunicación:** `HttpClient` para el consumo de servicios web JSON.
* **Librerías Clave:**
    * **CommunityToolkit.Mvvm:** Para el manejo de comandos y observabilidad.
    * **Newtonsoft.Json / System.Text.Json:** Procesamiento de datos recibidos de la API.
    * **MAUI Community Toolkit:** Diálogos, validaciones y elementos visuales.

---

## Estructura del Proyecto

```text
MauiAppEmpleados/
├── Models/         # Clases que representan los objetos de la API (Empleado, Departamento).
├── ViewModels/     # Lógica de negocio y manejo de estados de la UI.
├── Views/          # Archivos XAML (Páginas y componentes visuales).
├── Services/       # Servicios de comunicación con la API (Lógica de red).
├── Resources/      # Recursos multimedia, fuentes y estilos globales.
└── AppShell.xaml   # Configuración de la navegación principal.
```

## Instalación y Ejecución

1. **Clonar el repositorio:**
   ```bash
   git clone [https://github.com/Paum2000/MauiAppEmpleados.git](https://github.com/Paum2000/MauiAppEmpleados.git)
   ```
2.  **Abrir el proyecto:**
    Busca y abre el archivo `MauiAppEmpleados.sln` utilizando **Visual Studio 2022** (con la carga de trabajo de .NET MAUI instalada).

3.  **Restaurar paquetes NuGet:**
    Visual Studio debería restaurar las dependencias automáticamente al abrirse. Si no es así, haz clic derecho sobre la **Solución** en el Explorador de Soluciones y selecciona **"Restaurar paquetes NuGet"**.

4.  **Ejecutar:**
    * Selecciona el dispositivo de destino en la barra de herramientas superior (Emulador de Android, Simulador de iOS o Windows Machine).
    * Presiona `F5` o el botón de **Play** para compilar y depurar.

---

## Licencia

Este proyecto está bajo la licencia **MIT**.

---

## Desarrollado por

**Paum2000** _¡Gracias por visitar este repositorio!_

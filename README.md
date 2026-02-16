# MauiAppEmpleados 

Una aplicación móvil multiplataforma desarrollada con **.NET MAUI** para la gestión de empleados. Este proyecto demuestra el uso de operaciones CRUD (Crear, Leer, Actualizar y Eliminar) utilizando una arquitectura moderna y patrones de diseño recomendados.
## Home page
<img width="1411" height="711" alt="image" src="https://github.com/user-attachments/assets/44812edb-f272-4b31-8038-1908c19e54f0" />

## Menú desplegable
<img width="396" height="635" alt="image" src="https://github.com/user-attachments/assets/30de354b-a039-4524-bb71-567227243937" />

## Departapentos Page
<img width="1406" height="248" alt="image" src="https://github.com/user-attachments/assets/8121d78f-1cde-4d70-9652-c695178e55c6" />

## Formulario Departamentos
<img width="1417" height="407" alt="image" src="https://github.com/user-attachments/assets/308bcef8-3e09-4c8c-bedf-3539a3b32ff1" />

## Empleados Page
<img width="1411" height="420" alt="image" src="https://github.com/user-attachments/assets/29490350-e635-415a-8e94-f44867bb8a75" />

## Formulario Empleados
<img width="1407" height="711" alt="image" src="https://github.com/user-attachments/assets/22a3c4c1-0eea-4fb6-91c7-7d8b62107f7d" />

## Settings Page
<img width="1407" height="541" alt="image" src="https://github.com/user-attachments/assets/1e188604-a5f2-4684-9eef-ac46920781f3" />

## Características

- **Gestión de Empleados:** Registro, edición, visualización y eliminación de personal.
- **Interfaz Moderna:** Diseño adaptable y optimizado para dispositivos móviles (Android/iOS) y escritorio (Windows/macOS).
- **Patrón MVVM:** Separación limpia de la lógica de negocio y la interfaz de usuario.

## Tecnologías Utilizadas

- **[.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/):** Framework para aplicaciones nativas multiplataforma.
- **C# / XAML:** Lenguaje de programación y marcado.
- **CommunityToolkit.Mvvm:** Para simplificar la implementación del patrón Model-View-ViewModel.
- **SQLite-net-pcl:** (Si aplica) Para el manejo de la base de datos local.

## Requisitos Previos

Antes de ejecutar la aplicación, asegúrate de tener instalado:

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (versión 17.3 o superior) con la carga de trabajo de **Desarrollo de interfaz de usuario de aplicaciones multiplataforma de .NET**.
- SDK de .NET 7.0 o 8.0 (según la versión del proyecto).

## 💻 Instalación y Ejecución

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

## Estructura del Proyecto

El proyecto está organizado siguiendo las mejores prácticas de separación de responsabilidades:

* **Models:** Contiene las clases de datos y entidades de negocio (ej. `Empleado.cs`).
* **ViewModels:** Contiene la lógica de la interfaz de usuario y los comandos que vinculan la Vista con los Modelos.
* **Views:** Archivos XAML que definen la interfaz visual y la experiencia del usuario.
* **Services:** Lógica encargada del acceso a datos, persistencia local (SQLite) o consumo de APIs externas.

---

## Licencia

Este proyecto está bajo la licencia **MIT**.

---

## Desarrollado por

**Paum2000** _¡Gracias por visitar este repositorio!_

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MauiAppEmpleados.Models
{
    public class Empleado
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")] 
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("image_uri")] 
        public string? ImageUri { get; set; }

        [JsonPropertyName("department_id")]
        public int DepartmentId { get; set; }

        // Esta propiedad es solo visual para C#, la ignoramos al enviar el JSON
        [JsonIgnore]
        public string FullImageUrl
        {
            get
            {
                // CASO 1: Si es nulo (como el usuario "juan"), devolvemos la imagen por defecto
                if (string.IsNullOrEmpty(ImageUri))
                {
                    return "dotnet_bot.png"; // Asegúrate de tener esta imagen en Resources/Images
                }

                // CASO 2: Si ya es una URL absoluta (empieza por http), la devolvemos tal cual
                if (ImageUri.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    return ImageUri;
                }

                // CASO 3: Es una ruta relativa (ej: "/static/uploads/...")
                // Definimos la IP base dependiendo de dónde se ejecuta la App

                // IMPORTANTE: Cambia "8000" por tu puerto real si usas otro (ej. 8081)
                string port = "8081";

                string baseUrl = (DeviceInfo.Platform == DevicePlatform.Android)
                    ? $"http://10.0.2.2:{port}"  // Android Emulator ve al PC como 10.0.2.2
                    : $"http://localhost:{port}"; // Windows ve al PC como localhost

                return $"{baseUrl}{ImageUri}";
            }
        }
    }
}

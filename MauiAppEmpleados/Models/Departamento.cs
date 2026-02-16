using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MauiAppEmpleados.Models
{
    public class Departamento
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")] 
        public string Name { get; set; }
    }
}

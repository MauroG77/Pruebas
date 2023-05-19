using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Quind_Bank_Domain.Dtos.Clientes
{
    public class ClienteCreateDto
    {
        public string TipoIdentificacion { get; set; } = null!;

        public string NumeroIdentificacion { get; set; } = null!;
        //[StringLength(100, MinimumLength = 2, ErrorMessage = "El numero de caracteres es muy largo o demaciado corto")]
        public string Nombre { get; set; } = null!;
        //[StringLength(100, MinimumLength = 2, ErrorMessage = "El numero de caracteres es muy largo o demaciado corto")]
        public string Apellido { get; set; } = null!;
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

    }
}

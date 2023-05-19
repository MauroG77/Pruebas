using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Quind_Bank_Domain.Dtos.Clientes
{
    public class ClienteGetDto
    {

        public string TipoIdentificacion { get; set; } = null!;

        public string NumeroIdentificacion { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Age { get; set; } = null!;

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Quind_Bank_Domain
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string TipoIdentificacion { get; set; } = null!;

        public string NumeroIdentificacion { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;
        
        public DateTime FechaNacimiento { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cuenta> Cuenta { get; } = new List<Cuenta>();
    }
}

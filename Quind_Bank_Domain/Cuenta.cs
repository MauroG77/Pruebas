using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Quind_Bank_Domain
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }

        public string TipoCuenta { get; set; } = null!;

        public string NumCuenta { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public decimal Saldo { get; set; }

        public bool ExentaGmf { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Transaccion> Transacciones { get; } = new List<Transaccion>();

    }
}

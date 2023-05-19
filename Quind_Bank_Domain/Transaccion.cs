using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Domain
{
    public class Transaccion
    {
        public int IdTransaccion { get; set; }

        public string TipoTransaccion { get; set; } = null!;

        public decimal Monto { get; set; }

        public string NumCuentaDestino { get; set; } = null!;

        public DateTime? Fecha { get; set; }

        public int IdCuenta { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Domain.Dtos.Transacciones
{
    public class TransaccionCreateDto
    {
        public string TipoTransaccion { get; set; } = null!;

        public decimal Monto { get; set; }

        public string NumCuentaDestino { get; set; } = null!;

        public int IdCuenta { get; set; }

    }
}

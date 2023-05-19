using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Quind_Bank_Domain.Dtos.Cuentas
{
    public class CuentasGetDto
    {       
        public string TipoCuenta { get; set; } = null!;

        public string NumCuenta { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public decimal Saldo { get; set; }

        public bool ExentaGmf { get; set; }

    }
}

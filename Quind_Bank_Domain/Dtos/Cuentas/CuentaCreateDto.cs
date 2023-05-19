using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Quind_Bank_Domain.Dtos.Cuentas
{
    public class CuentaCreateDto
    {

        public string TipoCuenta { get; set; } = null!;
        //[Range(1, double.MaxValue, ErrorMessage = "El valor no puede ser 0")]
        public decimal Saldo { get; set; }

        public bool ExentaGmf { get; set; }

        public int IdCliente { get; set; }

    }
}

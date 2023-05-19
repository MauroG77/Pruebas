using Quind_Bank_Aplication.Interfaces;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Aplication.Servicios
{
    public class ServicioCuenta : IServicioCuenta<Cuenta, int>
    {
        private readonly IRepositorioCuenta<Cuenta, int> repoCuenta;

        public ServicioCuenta(IRepositorioCuenta<Cuenta, int> _repoCuenta)
        {
            this.repoCuenta = _repoCuenta;
        }

        public void Generar_Numero_Cuenta(Cuenta entidad)
        {
            const int MIN_NUMERO_CUENTA = 10000000;
            const int MAX_NUMERO_CUENTA = 99999999;
            const int TIPO_AHORROS = 53;
            const int TIPO_CORRIENTE = 33;

            Random rnd = new Random();
            int num = (rnd.Next(MIN_NUMERO_CUENTA, MAX_NUMERO_CUENTA + 1));

            switch (entidad.TipoCuenta)
            {
                case "ahorros":
                    entidad.NumCuenta = TIPO_AHORROS.ToString() + num.ToString();
                    break;
                case "corriente":
                    entidad.NumCuenta = TIPO_CORRIENTE.ToString() + num.ToString();
                    break;
            }
        }

        public bool Validar_Saldo_Cuenta_Ahorros(Cuenta entidad)
        {
            return entidad.TipoCuenta != "ahorros" || entidad.Saldo != 0;
        }
        public Cuenta Agregar(Cuenta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La 'cuenta' es requerido");

            if (!(Validar_Saldo_Cuenta_Ahorros(entidad)))
            {
                throw new Exception("No puedes crear una cuenta de ahorros con un saldo menor a 0");
            }
            Generar_Numero_Cuenta(entidad);
            var resultCuenta = repoCuenta.Agregar(entidad);
            repoCuenta.GuardarCambios();
            return resultCuenta;
        }

        public void Editar(Cuenta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Producto' es requerido para editar");

            repoCuenta.Editar(entidad);
            repoCuenta.GuardarCambios();
        }

        public void Eliminar(int entidadId)
        {
            repoCuenta.Eliminar(entidadId);
            repoCuenta.GuardarCambios();
        }

        public List<Cuenta> Listar()
        {
            return repoCuenta.Listar();
        }
    }
}

using Quind_Bank_Aplication.Interfaces;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Aplication.Servicios
{
    public class ServicioTransaccion : IServicioTransaccion<Transaccion, int>
    {
        private readonly IRepositorioTransaccion<Transaccion, int> repoTransaccion;

        public ServicioTransaccion(IRepositorioTransaccion<Transaccion, int> _repoTransaccion)
        {
            this.repoTransaccion = _repoTransaccion;
        }

        public Transaccion Agregar(Transaccion entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Producto' es requerido");

            var resultCuenta = repoTransaccion.Agregar(entidad);
            repoTransaccion.GuardarCambios();
            return resultCuenta;
        }              

        public void Eliminar(int entidadId)
        {
            repoTransaccion.Eliminar(entidadId);
            repoTransaccion.GuardarCambios();
        }

        public List<Transaccion> Listar()
        {
            return repoTransaccion.Listar();
        }
    }
}

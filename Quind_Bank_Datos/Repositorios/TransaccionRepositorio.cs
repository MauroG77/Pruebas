using Microsoft.EntityFrameworkCore;
using Quind_Bank_Datos.Modelos;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quind_Bank_Datos.Repositorios
{
    public class TransaccionRepositorio : IRepositorioTransaccion<Transaccion, int>
    {
        private QuindBankContext db;

        public TransaccionRepositorio(QuindBankContext _db)
        {
            this.db = _db;
        }

        public void Actualizar_Saldo(Transaccion entidad)
        {
            var cuentaSeleccionada = db.Cuentas.Where(c => c.IdCuenta == entidad.IdCuenta).FirstOrDefault();
            if(entidad.TipoTransaccion == "transferencia")
            {
                cuentaSeleccionada.Saldo -= entidad.Monto;
                db.Cuentas.Update(cuentaSeleccionada);
                var cuentaDestino = db.Cuentas.Where(c => c.NumCuenta == entidad.NumCuentaDestino).FirstOrDefault();
                cuentaDestino.Saldo += entidad.Monto;
                db.Cuentas.Update(cuentaDestino);
            }
            else
            {
                if (entidad.TipoTransaccion == "retiro")
                {
                    entidad.Monto = entidad.Monto * -1;
                }
                cuentaSeleccionada.Saldo += entidad.Monto;
                db.Cuentas.Update(cuentaSeleccionada);
            }                        
        }
        public Transaccion Agregar(Transaccion entidad)
        {
            Actualizar_Saldo(entidad);
            db.Transacciones.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public void Editar(Transaccion entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int entidadId)
        {
            Transaccion oTransaccion = db.Transacciones.Find(entidadId);
            db.Transacciones.Remove(oTransaccion);
            db.SaveChanges();
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Transaccion> Listar()
        {
            return db.Transacciones.Include(t => t.IdCuentaNavigation).ToList();
        }
    }
}

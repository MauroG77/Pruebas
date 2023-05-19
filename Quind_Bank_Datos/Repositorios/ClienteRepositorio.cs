using Microsoft.EntityFrameworkCore;
using Quind_Bank_Datos.Modelos;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Dtos;
using Quind_Bank_Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quind_Bank_Datos.Repositorios
{
    public class ClienteRepositorio : IRepositorioCliente<Cliente, int>
    {
        public QuindBankContext db;

        public ClienteRepositorio(QuindBankContext _db)
        {
            this.db = _db;
        }
        public Cliente Agregar(Cliente entidad)
        {        
            db.Clientes.Add(entidad);
            return entidad;  
        }

        public void Editar(Cliente entidad)
        {
            Cliente oCliente = db.Clientes.Find(entidad.IdCliente);

            if (oCliente != null)
            {                
                oCliente.TipoIdentificacion = entidad.TipoIdentificacion is null ? oCliente.TipoIdentificacion : entidad.TipoIdentificacion;
                oCliente.NumeroIdentificacion = entidad.NumeroIdentificacion is null ? oCliente.NumeroIdentificacion : entidad.NumeroIdentificacion;
                oCliente.Nombre = entidad.Nombre is null ? oCliente.Nombre : entidad.Nombre;
                oCliente.Apellido = entidad.Apellido is null ? oCliente.Apellido : entidad.Apellido;
                oCliente.Email = entidad.Email is null ? oCliente.Email : entidad.Email;
                oCliente.FechaNacimiento = entidad.FechaNacimiento == DateTime.MinValue ? oCliente.FechaNacimiento : entidad.FechaNacimiento;
                oCliente.FechaModificacion = DateTime.Now;

                db.Clientes.Update(oCliente);
            }
        }

        public void Eliminar(int entidadId)
        {

            Cliente oCliente = db.Clientes.Find(entidadId);
            if (oCliente.Cuenta == null) { 
                db.Clientes.Remove(oCliente);
                Console.WriteLine("el cliente sera borrado");
            }
            else
            {
                Console.WriteLine("no se borro");
            }
            //db.Clientes.Select(c => c.Cuenta);
            //db.Clientes.Remove(oCliente);
        }

        public List<Cliente> Listar()
        {
            return db.Clientes.ToList();            
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }
    }
}

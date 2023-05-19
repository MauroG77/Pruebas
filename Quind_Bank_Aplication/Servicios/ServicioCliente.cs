using AppVenta.Dominio.Interfaces;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Dtos;
using Quind_Bank_Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Quind_Bank_Aplication.Servicios
{
    public class ServicioCliente: IServicioCliente<Cliente, int>
    {
        private readonly IRepositorioCliente<Cliente, int> repoCliente;
        public static bool Validar_Edad(Cliente entidad)
        {
            DateTime fecha_nacimiento = entidad.FechaNacimiento;
            DateTime edad_legal = DateTime.Now.AddYears(-18); // Fecha de cumplir 18 años
            if (fecha_nacimiento < edad_legal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Validar_Correo(Cliente entidad)
        {
            string email = "example@example.com";
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            bool isValid = Regex.IsMatch(email, pattern);
            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ServicioCliente(IRepositorioCliente<Cliente, int> _repoCliente)
        {
            this.repoCliente = _repoCliente;
        }

        public Cliente Agregar(Cliente entidad)
        {          
            if (!(Validar_Edad(entidad)))
            {
                throw new Exception("El cliente no es mayor de edad");
            }
            if (!(Validar_Correo(entidad)))
            {
                throw new Exception("El correo es invalido");
            }
            var resultCliente = repoCliente.Agregar(entidad);
            repoCliente.GuardarCambios();
            return resultCliente;
        }

        public void Editar(Cliente entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El 'Producto' es requerido para editar");

            repoCliente.Editar(entidad);
            repoCliente.GuardarCambios();
        }

        public void Eliminar(int entidadId)
        {            
            repoCliente.Eliminar(entidadId);
            repoCliente.GuardarCambios();
        }

        public List<Cliente> Listar()
        {
            return repoCliente.Listar();
        }
    }
}

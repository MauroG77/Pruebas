using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quind_Bank_Datos.Modelos;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Dtos.Clientes;
using Quind_Bank_Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quind_Bank_Datos.Repositorios
{
    public class CuentaRepositorio : IRepositorioCuenta<Cuenta, int>
    {
        
        private readonly QuindBankContext db;

        public CuentaRepositorio(QuindBankContext _db)
        {
            this.db = _db;
        }              

        public async Task<bool> Validar_Gfm(Cuenta entidad)
        {
            using (var client = new HttpClient())
            {
                // Establecer la URL base para hacer solicitudes
                client.BaseAddress = new Uri("http://localhost:5104/");

                // Realizar la solicitud GET y esperar la respuesta
                var response = await client.GetAsync("api/Cedulas");

                var cuentaSeleccionada = db.Clientes.Where(c => c.IdCliente == entidad.IdCliente).FirstOrDefault();

                // Verificar si la respuesta fue exitosa
                if ((cuentaSeleccionada != null) && (response.IsSuccessStatusCode))
                {
                    // Lee el contenido de la respuesta
                    var content = response.Content.ReadAsStringAsync().Result;

                    // Deserializa el contenido a una lista de objetos 
                    var data = JsonConvert.DeserializeObject<List<string>>(content);

                    // Almacena la lista en una variable
                    //var dataList = data;

                    if (data.Contains(cuentaSeleccionada.NumeroIdentificacion))
                    {
                        Console.WriteLine("La cedula esta reportada");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                    return false;

                }
            }
        }

        public Cuenta Agregar(Cuenta entidad)
        {
            //Task<bool> task = Validar_Gfm(entidad);            
            //bool result = task.Result;
            //if (result)
            //{
            //    entidad.ExentaGmf = false;
            //}
            //else
            //{
            //    entidad.ExentaGmf = true;
            //}            
            db.Cuentas.Add(entidad);
            return entidad;
        }

        public void Editar(Cuenta entidad)
        {
            Cuenta oCuenta = db.Cuentas.Find(entidad.IdCuenta);

            if (oCuenta != null)
            {
                oCuenta.TipoCuenta = entidad.TipoCuenta is null ? oCuenta.TipoCuenta : entidad.TipoCuenta;
                oCuenta.NumCuenta = entidad.NumCuenta is null ? oCuenta.NumCuenta : entidad.NumCuenta;
                oCuenta.Estado = entidad.Estado is null ? oCuenta.Estado : entidad.Estado;
                //oCuenta.ExentaGmf = entidad.ExentaGmf is null ? oCuenta.ExentaGmf : entidad.ExentaGmf;
                oCuenta.FechaModificacion = DateTime.Now;

                db.Cuentas.Update(oCuenta);
            }
        }

        public void Eliminar(int entidadId)
        {
            Cuenta oCuenta = db.Cuentas.Find(entidadId);
            db.Cuentas.Remove(oCuenta);
        }

        public List<Cuenta> Listar()
        {
            return db.Cuentas.Include(c => c.IdClienteNavigation).ToList();
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }
    }
}

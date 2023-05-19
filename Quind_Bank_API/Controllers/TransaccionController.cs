using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quind_Bank_Aplication.Servicios;
using Quind_Bank_Datos.Modelos;
using Quind_Bank_Datos.Repositorios;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Dtos.Cuentas;
using Quind_Bank_Domain.Dtos.Transacciones;

namespace Quind_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        ServicioTransaccion CrearServicio()
        {
            QuindBankContext db = new QuindBankContext();
            TransaccionRepositorio repo = new TransaccionRepositorio(db);
            ServicioTransaccion servicio = new ServicioTransaccion(repo);
            return servicio;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<TransaccionesGetDto>> Get()
        {
            var servicio = CrearServicio();
            //return Ok(servicio.Listar());

            var transacciones = servicio.Listar();
            var transaccionesDTO = transacciones.Select(c => new TransaccionesGetDto
            {
                TipoTransaccion = c.TipoTransaccion,
                Monto = c.Monto,
                NumCuentaDestino = c.NumCuentaDestino,
                Fecha = c.Fecha
            }).ToList();
            return transaccionesDTO;
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] TransaccionCreateDto objetoDto)
        {
            var transaccion = new Transaccion();

            transaccion.TipoTransaccion = objetoDto.TipoTransaccion;
            transaccion.Monto = objetoDto.Monto;
            transaccion.NumCuentaDestino = objetoDto.NumCuentaDestino;
            transaccion.IdCuenta = objetoDto.IdCuenta;
             
            var servicio = CrearServicio();
            servicio.Agregar(transaccion);
            return Ok("Transaccion realizada correctamente!!!!");
        }               

        [HttpDelete]
        [Route("Eliminar/{idCliente:int}")]
        public IActionResult Eliminar(int idTransaccion)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(idTransaccion);
            return Ok("Transaccion eliminada correctamente!!!!!");
        }
    }
}

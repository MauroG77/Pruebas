using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quind_Bank_Aplication.Servicios;
using Quind_Bank_Datos.Modelos;
using Quind_Bank_Datos.Repositorios;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Dtos.Cuentas;

namespace Quind_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        ServicioCuenta CrearServicio()
        {
            QuindBankContext db = new QuindBankContext();
            CuentaRepositorio repo = new CuentaRepositorio(db);
            ServicioCuenta servicio = new ServicioCuenta(repo);
            return servicio;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<CuentasGetDto>> Get()
        {
            var servicio = CrearServicio();
            //return Ok(servicio.Listar());

            var cuentas = servicio.Listar();
            var cuentasDTO = cuentas.Select(c => new CuentasGetDto
            {
                TipoCuenta = c.TipoCuenta,
                NumCuenta = c.NumCuenta,
                Estado = c.Estado,
                Saldo = c.Saldo,
                ExentaGmf = c.ExentaGmf
            }).ToList();
            return cuentasDTO;
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] CuentaCreateDto objetoDto)
        {
            var cuenta = new Cuenta();

            cuenta.TipoCuenta = objetoDto.TipoCuenta;
            cuenta.Saldo = objetoDto.Saldo;
            cuenta.IdCliente = objetoDto.IdCliente;
            cuenta.Estado = "activa";
            var servicio = CrearServicio();

            try
            {
                servicio.Agregar(cuenta);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Cuenta agregada exitosamente " });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }           
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Cuenta objeto)
        {
            var servicio = CrearServicio();
            servicio.Editar(objeto);
            return Ok("Cuenta editada correctamente!!!!");

        }

        [HttpDelete]
        [Route("Eliminar/{idCliente:int}")]
        public IActionResult Eliminar(int idCuenta)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(idCuenta);
            return Ok("Cuenta eliminada correctamente!!!!!");
        }
    }
}

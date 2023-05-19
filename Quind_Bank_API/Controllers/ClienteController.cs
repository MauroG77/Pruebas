using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quind_Bank_Aplication.Servicios;
using Quind_Bank_Datos.Modelos;
using Quind_Bank_Datos.Repositorios;
using Quind_Bank_Domain;
using Quind_Bank_Domain.Dtos.Clientes;
using Microsoft.Extensions.Logging;
using NLog;
using Microsoft.AspNetCore.Authorization;
using API_CONVERSION;
using SharpCompress.Common;

namespace Quind_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClienteController : ControllerBase
    {
        //private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        //private readonly ILogger<ClienteController> _logger;

        //public ClienteController(ILogger<ClienteController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    _logger.LogInformation("Hello, this is the index!");
        //    return View();
        //}
        ServicioCliente CrearServicio()
        {
            QuindBankContext db = new QuindBankContext();
            ClienteRepositorio repo = new ClienteRepositorio(db);
            ServicioCliente servicio = new ServicioCliente(repo);
            return servicio;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ClienteGetDto>>> GetAsync()
        {
            var servicio = CrearServicio();
            var clientes = servicio.Listar();
            var clientesDTO = new List<ClienteGetDto>();
            foreach (var c in clientes)
            {
                clientesDTO.Add(new ClienteGetDto
                {
                    TipoIdentificacion = c.TipoIdentificacion,
                    NumeroIdentificacion = c.NumeroIdentificacion,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Email = c.Email,
                    Age = await CalcularEdad(c.FechaNacimiento)
                });
            }
            return clientesDTO;
        }

        private async Task<string> CalcularEdad(DateTime fechaNacimiento)
        {
            //int edad = DateTime.Now.Year - fechaNacimiento.Year;
            //if (DateTime.Now.Month < fechaNacimiento.Month || (DateTime.Now.Month == fechaNacimiento.Month && DateTime.Now.Day < fechaNacimiento.Day))
            //{
            //    edad--;
            //}
            var edad = (int)((DateTime.Now - fechaNacimiento).TotalDays / 365);
            NumberConversionSoapTypeClient client = new NumberConversionSoapTypeClient(NumberConversionSoapTypeClient.EndpointConfiguration.NumberConversionSoap12);
            ulong num = (ulong)edad;
            var respuesta = await client.NumberToWordsAsync(num);
            return respuesta.Body.NumberToWordsResult;
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] ClienteCreateDto objetoDto)
        {            
            var cliente = new Cliente();
            cliente.TipoIdentificacion = objetoDto.TipoIdentificacion;
            cliente.NumeroIdentificacion = objetoDto.NumeroIdentificacion;
            cliente.Nombre = objetoDto.Nombre;
            cliente.Apellido = objetoDto.Apellido;
            cliente.Email = objetoDto.Email;
            cliente.FechaNacimiento = objetoDto.FechaNacimiento;

            var servicio = CrearServicio();
            
            try
            {
                servicio.Agregar(cliente);
                return Ok("Cliente guardado");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
            
                       
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Cliente objeto)
        {
            var servicio = CrearServicio();
            servicio.Editar(objeto);
            return Ok("Cliente editado correctamente!!!!");
        }

        [HttpDelete]
        [Route("Eliminar/{idCliente:int}")]
        public IActionResult Eliminar(int idCliente)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(idCliente);
            return Ok("Cliente eliminado correctamente!!!!!");
        }
    }
}

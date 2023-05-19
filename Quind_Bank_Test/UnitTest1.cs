//using Microsoft.VisualStudio.TestTools.UnitTesting;

using Quind_Bank_API.Controllers;
using Quind_Bank_Datos.Repositorios;
using Quind_Bank_Domain;

namespace Quind_Bank_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Cliente cliente1 = new Cliente();
            cliente1.FechaNacimiento = new DateTime(2010, 12, 31);

            //Act
            bool result = Quind_Bank_Aplication.Servicios.ServicioCliente.Validar_Edad(cliente1);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            Cliente cliente = new Cliente();
            int IdCliente = 1;
            string TipoIdentificacion = "cedula";
            string NumeroIdentificacion = "1087494008";
            string Nombre = "Mauro";
            string Apellido = "Posada";
            string Email = "mauro@gmail.com";
            DateTime FechaNacimiento = new DateTime(1998, 12, 31);
            DateTime FechaCreacion = DateTime.Now;
            DateTime FechaModificacion = DateTime.Now;

            //Act
            cliente.IdCliente= IdCliente;
            cliente.TipoIdentificacion= TipoIdentificacion;
            cliente.NumeroIdentificacion= NumeroIdentificacion;
            cliente.Nombre= Nombre;
            cliente.Apellido= Apellido;
            cliente.Email= Email;   
            cliente.FechaNacimiento= FechaNacimiento;
            cliente.FechaCreacion= FechaCreacion;
            cliente.FechaModificacion= FechaModificacion;

            //Assert
            Assert.AreEqual(IdCliente, cliente.IdCliente);
            Assert.AreEqual(TipoIdentificacion, cliente.TipoIdentificacion);
            Assert.AreEqual(NumeroIdentificacion, cliente.NumeroIdentificacion);
            Assert.AreEqual(Nombre, cliente.Nombre);
            Assert.AreEqual(Apellido, cliente.Apellido);
            Assert.AreEqual(Email, cliente.Email);
            Assert.AreEqual(FechaNacimiento, cliente.FechaNacimiento);
            Assert.AreEqual(FechaCreacion, cliente.FechaCreacion);
            Assert.AreEqual(FechaModificacion, cliente.FechaModificacion);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            ClienteController api = new ClienteController();

            //Asert
            var result = api.Get();

            // Assert
            //Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            //Cliente client = new Cliente();
            //ClienteRepositorio repo;

            //Asert           
            //Quind_Bank_Datos.Repositorios.ClienteRepositorio.Eliminar(client.IdCliente);

            // Assert
            //Assert.AreEqual(expectedResult, result);
        }
    }
}
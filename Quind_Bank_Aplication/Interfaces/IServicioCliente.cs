using Quind_Bank_Domain.Dtos;
using Quind_Bank_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces {
	public interface IServicioCliente <Cliente, Integer>
		: IAgregar<Cliente>, IEditar<Cliente>, IEliminar<Integer>, IListar<Cliente>
	{
		
	}
}

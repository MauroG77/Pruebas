using Quind_Bank_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Domain.Repositorios
{
    public interface IRepositorioCliente <Cliente, Integer> 
        : IAgregar<Cliente>, IEditar<Cliente>, IEliminar<Integer>, IListar<Cliente>, IOperacion
    {
    }
}

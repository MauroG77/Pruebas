using Quind_Bank_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Domain.Repositorios
{
    public interface IRepositorioTransaccion<Transaccion, Integer> 
        : IAgregar<Transaccion>, IEliminar<Integer>, IListar<Transaccion>, IOperacion
    {
    }
}

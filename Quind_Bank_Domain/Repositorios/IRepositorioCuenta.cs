using Quind_Bank_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Domain.Repositorios
{
    public interface IRepositorioCuenta<Cuenta, Integer> 
        : IAgregar<Cuenta>, IEditar<Cuenta>, IEliminar<Integer>, IListar<Cuenta>, IOperacion
    {
    }
}

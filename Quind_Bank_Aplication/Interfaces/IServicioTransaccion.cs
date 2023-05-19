using Quind_Bank_Domain.Interfaces;
using Quind_Bank_Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Aplication.Interfaces
{
    public interface IServicioTransaccion<Transaccion, Integer>
        : IAgregar<Transaccion>, IEliminar<Integer>, IListar<Transaccion>
    {
    }
}

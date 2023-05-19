using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Domain.Interfaces
{
	public interface IAgregar<TEntidad> {
		TEntidad Agregar(TEntidad entidad);
	}
}

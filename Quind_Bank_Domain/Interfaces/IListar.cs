using System;
using System.Collections.Generic;
using System.Text;

namespace Quind_Bank_Domain.Interfaces
{
	public interface IListar<TEntidad> {
		List<TEntidad> Listar();

	}
}

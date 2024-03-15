using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SystemTest.DTO;

namespace SystemTest.BLL.Servicios.Contrato
{
    public interface IServicesService
    {
        Task<List<ServicioDTO>> Lista();
        Task<ServicioDTO> Crear(ServicioDTO cliente);
        Task<bool> Editar(ServicioDTO cliente);
        Task<bool> Eliminar(int id);
    }
}

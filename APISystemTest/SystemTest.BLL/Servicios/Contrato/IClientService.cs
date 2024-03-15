using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SystemTest.DTO;

namespace SystemTest.BLL.Servicios.Contrato
{
    public interface IClientService
    {
        Task<List<ClienteDTO>> Lista();
        Task<ClienteDTO> Crear(ClienteDTO cliente);
        Task<bool> Editar(ClienteDTO cliente);
        Task<bool> Eliminar(int id);
    }
}

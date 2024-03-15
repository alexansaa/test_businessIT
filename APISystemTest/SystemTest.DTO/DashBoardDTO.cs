using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTest.DTO
{
    public class DashBoardDTO
    {
        public List<ClienteDTO> clientes { get; set; }
        public List<ServicioDTO> servicios { get; set; }
    }
}

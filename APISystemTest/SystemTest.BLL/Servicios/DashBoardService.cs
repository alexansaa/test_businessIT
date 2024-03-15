using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SystemTest.BLL.Servicios.Contrato;
using SystemTest.DAL.Repositorios.Contrato;
using SystemTest.DTO;
using SystemTest.Model;

namespace SystemTest.BLL.Servicios
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IGenericRepository<Cliente> clienteRepository;
        private readonly IMapper mapper;

        public DashBoardService(IGenericRepository<Cliente> clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        private async Task<List<Cliente>> AllClients()
        {
            List<Cliente> resultado = new List<Cliente> ();

            IQueryable<Cliente> clientesQuery = await clienteRepository.Consultar();

            if(clientesQuery.Count() > 0)
            {
                resultado = clientesQuery.OrderBy(g => g.Name).ToList();
            }

            return resultado;
        }

        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO vmDashBoard = new DashBoardDTO();
            try
            {
                List<Cliente> resultado = await AllClients();

                List<ClienteDTO> listaClientes = new List<ClienteDTO>();

                foreach(Cliente cl in resultado)
                {
                    listaClientes.Add(new ClienteDTO()
                    {
                        Name = cl.Name,
                        Email = cl.Email
                    });
                }

                vmDashBoard.clientes = listaClientes;
            }
            catch
            {
                throw;
            }

            return vmDashBoard;
        }
    }
}

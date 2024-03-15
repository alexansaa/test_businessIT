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
        private readonly IGenericRepository<Servicio> servicioRepository;
        private readonly IMapper mapper;

        public DashBoardService(IGenericRepository<Cliente> clienteRepository, IGenericRepository<Servicio> servicioRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.servicioRepository = servicioRepository;
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

        private async Task<List<Servicio>> AllServicios()
        {
            List<Servicio> resultado = new List<Servicio> ();

            IQueryable<Servicio> serviciosQuery = await servicioRepository.Consultar();

            if(serviciosQuery.Count() > 0)
            {
                resultado = serviciosQuery.OrderBy(s => s.Name).ToList();
            }

            return resultado;
        }

        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO vmDashBoard = new DashBoardDTO();
            try
            {
                List<Cliente> resultadoClientes = await AllClients();

                List<ClienteDTO> listaClientes = new List<ClienteDTO>();

                foreach(Cliente cl in resultadoClientes)
                {
                    listaClientes.Add(new ClienteDTO()
                    {
                        Name = cl.Name,
                        Email = cl.Email
                    });
                }

                vmDashBoard.clientes = listaClientes;

                List<Servicio> resultadoServicios = await AllServicios();

                List<ServicioDTO> listaServicios = new List<ServicioDTO>();

                foreach(Servicio sr in  resultadoServicios)
                {
                    listaServicios.Add(new ServicioDTO()
                    {
                        Name= sr.Name,
                        Description = sr.Description
                    });
                }

                vmDashBoard.servicios = listaServicios;
            }
            catch
            {
                throw;
            }

            return vmDashBoard;
        }
    }
}

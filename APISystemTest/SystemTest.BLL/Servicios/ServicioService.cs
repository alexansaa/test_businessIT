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
    public class ServicioService:IServicesService
    {
        private readonly IGenericRepository<Servicio> servicioRepository;
        private readonly IMapper mapper;

        public ServicioService(IGenericRepository<Servicio> servicioRepository, IMapper mapper)
        {
            this.servicioRepository = servicioRepository;
            this.mapper = mapper;
        }

        public async Task<ServicioDTO> Crear(ServicioDTO servicio)
        {
            try
            {
                var servicioCreado = await servicioRepository.Crear(mapper.Map<Servicio>(servicio));
                if(servicioCreado.Id == 0)
                {
                    throw new TaskCanceledException("No se pudo crear servicio!");
                }
                var query = await servicioRepository.Consultar(s => s.Id == servicioCreado.Id);
                servicioCreado = query.First();
                return mapper.Map<ServicioDTO>(servicioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ServicioDTO servicio)
        {
            try
            {
                var servicioModelo = mapper.Map<Servicio>(servicio);
                var servicioEncontrado = await servicioRepository.Obtener(s => s.Id == servicioModelo.Id);

                if(servicioEncontrado == null)
                {
                    throw new TaskCanceledException("El servicio no existe!");
                }

                servicioEncontrado.Name = servicioModelo.Name;
                servicioEncontrado.Description = servicioModelo.Description;

                bool respuesta = await servicioRepository.Editar(servicioEncontrado);

                if(!respuesta)
                {
                    throw new TaskCanceledException("No se pudo editar servicio!");
                }

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var servicioEncontrado = await servicioRepository.Obtener(s => s.Id == id);

                if(servicioEncontrado == null)
                {
                    throw new TaskCanceledException("El servicio no existe!");
                }

                bool respuesta = await servicioRepository.Delete(servicioEncontrado);

                if (!respuesta)
                {
                    throw new TaskCanceledException("No se puedo eliminar servicio");
                }

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ServicioDTO>> Lista()
        {
            try
            {
                var listaServicio = await servicioRepository.Consultar();
                return mapper.Map<List<ServicioDTO>>(listaServicio.ToList());
            }
            catch
            {
                throw;
            }
        }
    }
}

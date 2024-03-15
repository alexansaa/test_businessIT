using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SystemTest.BLL.Servicios.Contrato;
using SystemTest.DAL.Repositorios.Contrato;
using SystemTest.DTO;
using SystemTest.Model;

namespace SystemTest.BLL.Servicios
{
    public class ClienteService:IClientService
    {
        private readonly IGenericRepository<Cliente> clienteRepositorio;
        private readonly IMapper myMapper;

        public ClienteService(IGenericRepository<Cliente> clienteRepositorio, IMapper myMapper)
        {
            this.clienteRepositorio = clienteRepositorio;
            this.myMapper = myMapper;
        }

        public async Task<ClienteDTO> Crear(ClienteDTO cliente)
        {
            try
            {
                var usuarioCreado = await clienteRepositorio.Crear(myMapper.Map<Cliente>(cliente));
                if(usuarioCreado.Id == 0)
                {
                    throw new TaskCanceledException("No se pudo crear usuario");
                }
                var query = await clienteRepositorio.Consultar(u => u.Id == usuarioCreado.Id);
                usuarioCreado = query.First();
                return myMapper.Map<ClienteDTO>(usuarioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ClienteDTO cliente)
        {
            try
            {
                var usuarioModelo = myMapper.Map<Cliente>(cliente);
                var usuarioEncontrado = await clienteRepositorio.Obtener(u => u.Id == usuarioModelo.Id);

                if(usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe!");
                }

                usuarioEncontrado.Name = usuarioModelo.Name;
                usuarioEncontrado.Email = usuarioModelo.Email;

                bool respuesta = await clienteRepositorio.Editar(usuarioEncontrado);

                if (!respuesta)
                {
                    throw new TaskCanceledException("No se pudo editar cliente");
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
                var usuarioEncontrado = await clienteRepositorio.Obtener(u => u.Id == id);

                if(usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe!");
                }

                bool respuesta = await clienteRepositorio.Delete(usuarioEncontrado);

                if(!respuesta)
                {
                    throw new TaskCanceledException("No se pudo eliminar usuario");
                }

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ClienteDTO>> Lista()
        {
            try
            {
                var queryUsuario = await clienteRepositorio.Consultar();
                var listaUsuarios = queryUsuario.ToList();

                return myMapper.Map<List<ClienteDTO>>(listaUsuarios);
            }
            catch
            {
                throw;
            }
        }
    }
}

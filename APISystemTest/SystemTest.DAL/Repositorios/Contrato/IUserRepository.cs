using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SystemTest.Model;

namespace SystemTest.DAL.Repositorios.Contrato
{
    public interface IUserRepository:IGenericRepository<Cliente>
    {
        Task<Cliente> Registrar(Cliente cliente);
    }
}

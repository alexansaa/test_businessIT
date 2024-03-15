using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SystemTest.DAL.DBContext;
using SystemTest.DAL.Repositorios.Contrato;
using SystemTest.Model;

namespace SystemTest.DAL.Repositorios
{
    public class ClienteRepository:GenericRepository<Cliente>, IUserRepository
    {
        private readonly DbtestContext dbtestContext;

        public ClienteRepository(DbtestContext dbtestContext):base(dbtestContext)
        {
            this.dbtestContext = dbtestContext;
        }

        public async Task<Cliente> Registrar(Cliente cliente)
        {
            Cliente nuevoCliente = new Cliente();

            using(var transaction = dbtestContext.Database.BeginTransaction())
            {
                try
                {
                    await dbtestContext.Clientes.AddAsync(cliente);
                    await dbtestContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return nuevoCliente;
            }
        }
    }
}

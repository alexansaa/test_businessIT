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
    public class ServiceRepository:GenericRepository<Servicio>, IServiceRepository
    {
        private readonly DbtestContext dbtestContext;

        public ServiceRepository(DbtestContext dbtestContext) : base(dbtestContext)
        {
            this.dbtestContext = dbtestContext;
        }

        public async Task<Servicio> Registrar(Servicio servicio)
        {
            Servicio newServicio = new Servicio();

            using(var transaction = dbtestContext.Database.BeginTransaction())
            {
                try
                {
                    await dbtestContext.Servicios.AddAsync(servicio);
                    await dbtestContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                return newServicio;
            }
        }
    }
}

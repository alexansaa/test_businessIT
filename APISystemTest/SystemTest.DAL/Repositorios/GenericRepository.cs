using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SystemTest.DAL.Repositorios.Contrato;
using SystemTest.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SystemTest.DAL.Repositorios
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbtestContext dbtestContext;

        public GenericRepository(DbtestContext dbtestContext)
        {
            this.dbtestContext = dbtestContext;
        }

        public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModel> queryModelo = filtro == null? dbtestContext.Set<TModel>(): dbtestContext.Set<TModel>().Where(filtro);
                return queryModelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Crear(TModel modelo)
        {
            try
            {
                dbtestContext.Set<TModel>().Add(modelo);
                await dbtestContext.SaveChangesAsync();
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TModel modelo)
        {
            try
            {
                dbtestContext.Set<TModel>().Remove(modelo);
                await dbtestContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModel modelo)
        {
            try
            {
                dbtestContext.Set<TModel>().Update(modelo);
                await dbtestContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel model = await dbtestContext.Set<TModel>().FirstOrDefaultAsync(filtro);
                return model;
            }
            catch
            {
                throw;
            }
        }
    }
}

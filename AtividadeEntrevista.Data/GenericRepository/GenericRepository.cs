using AtividadeEntrevista.Data.DataContext;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace AtividadeEntrevista.Data.GenericRepository
{
    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {

        DBDataContext Contexto = new DBDataContext();

        public IQueryable<T> ListarTodos()
        {
            IQueryable<T> query = Contexto.Set<T>();
            return query;
        }
        public IQueryable<T> Buscar(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = Contexto.Set<T>().Where(expression);
            return query;
        }

        public void Adicionar(T entity)
        {
            Contexto.Set<T>().Add(entity);
            this.Salvar();
        }

        public void Excluir(T entity)
        {
            Contexto.Set<T>().Remove(entity);
            this.Salvar();
        }
        public void Editar(T entity)
        {
            Contexto.Entry(entity).State = EntityState.Modified;
            this.Salvar();
        }

        public void Salvar()
        {
            Contexto.SaveChanges();
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }
    }
}

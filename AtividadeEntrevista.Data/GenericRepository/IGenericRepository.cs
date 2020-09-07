using System;
using System.Linq;
using System.Linq.Expressions;

namespace AtividadeEntrevista.Data.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> ListarTodos();
        IQueryable<T> Buscar(Expression<Func<T, bool>> expression);
        void Adicionar(T entity);
        void Excluir(T entity);
        void Editar(T entity);
        void Salvar();
        void Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgentApp.DataAccess.Interfaces
{   
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetBy(Expression<Func<T, bool>> predicate);
        int GetCount(Expression<Func<T, bool>> predicate);
        void AddList(List<T> entity);
        void Add(T entity);
        void Delete(T entity);
        void DeleteList(List<T> entity);
        void DeleteAll(List<T> entity);

        void Edit(T entity);
        void Save();
        //IQueryable<T> GetJoin(Expression<Func<T, bool>> predicate);

        Task SaveAsyn();
        IQueryable<T> GetAllQueryable();
        Task<T> GetByAsnc(Expression<Func<T, bool>> predicate);

    }
}

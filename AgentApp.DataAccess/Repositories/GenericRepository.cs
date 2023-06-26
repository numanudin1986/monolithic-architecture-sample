using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AgentApp.DataAccess.Entity;
using AgentApp.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace AgentApp.DataAccess.Repositories
{
    //GenericRepository<T> : IGenericRepository<T> where T : class
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //private C _context = new C();
        protected readonly AgentAppContext _context;
        public GenericRepository(AgentAppContext context)
        {
            _context = context;
        }

        public List<T> GetAll()
        {
            try
            {
                List<T> result = _context.Set<T>().ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public List<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                List<T> result = _context.Set<T>().Where(predicate).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            try
            {
                int result = _context.Set<T>().Count(predicate);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddList(List<T> entity)
        {
            try
            {
                _context.Set<T>().AddRange(entity);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public virtual void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public virtual void DeleteList(List<T> entity)
        {
            try
            {
                _context.Set<T>().RemoveRange(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public virtual void Edit(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveAsyn()
        {
            try
            {
              await  _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<T> GetAllQueryable()
        {
            try
            {
                IQueryable<T> result = _context.Set<T>().AsQueryable();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAll(List<T> entity)
        {
            try
            {
                _context.Set<T>().RemoveRange(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetByAsnc(Expression<Func<T, bool>> predicate)
        {
            T result = await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
            return result;
        }



        //public IQueryable<T> GetJoin()
        //{
        //    try
        //    {
        //        IQueryable<T> result = _context.Set<T>();
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public IQueryable<T> GetJoin(Expression<Func<T, bool>> predicate)
        //{
        //    try
        //    {
        //        IQueryable<T> result = _context.Set<T>().Where(predicate);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }

}

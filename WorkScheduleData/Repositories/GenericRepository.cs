using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkScheduleData.Data;
using WorkScheduleData.Models;

namespace WorkScheduleData.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> FindAll();
        T FindByPrimaryKey(int id);
        T Insert(T entity);
        T Update(T entity);
        T Delete(int id);
    }

    public class GenericRepository<T> where T : BaseEntity
    {
        public GenericRepository(WorkScheduleContext context)
        {
            this.Context = context;
        }

        public WorkScheduleContext Context { get; set; }

        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindByPrimaryKey(int id)
        {
            var entity = this.Context.Find<T>(id);
            if (entity is object)
            {
                this.Context.Entry<T>(entity).State = EntityState.Detached;
                return entity;
            }

            throw new Exception($"Entity does not exist {id}");
        }

        public T Insert(T entity)
        {
            Context.Add<T>(entity);
            Context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {

            this.Context.Attach<T>(entity);


            this.Context.Entry<T>(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
            return entity;
        }

        public T Delete(int id)
        {
            var entity = this.FindByPrimaryKey(id);
            this.Context.Remove<T>(entity);
            this.Context.SaveChanges();
            return entity;
        }
    }
}

using ConsoleApp1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Third_task.Models;

namespace ConsoleApp1.Repo
{
    public abstract class RepoBase<T> : IRepositoryBase<T> where T : class
    {
        protected APISHOP2Context RepositoryContext { get; set; }
        public RepoBase(APISHOP2Context aPISHOP2Context)
        {
            RepositoryContext = aPISHOP2Context;
        }

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}

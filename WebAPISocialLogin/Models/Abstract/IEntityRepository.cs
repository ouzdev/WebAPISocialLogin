using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities.Abstract;

namespace WebAPISocialLogin.Models.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //generic constraint
        //class : referans tip
        //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
        //new() : new'lenebilir olmalı

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entity);
        T Update(T entity);
        void Delete(T entity);
    }
}

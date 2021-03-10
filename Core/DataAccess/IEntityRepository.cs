using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    /// <summary>
    /// Base of CRUD operations
    /// </summary>
    /// <typeparam name="T">Your entity</typeparam>
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //Expression yapısı, EF'nin veritabanına sorgu atarken filtre uygulayabilmesini sağlar.
        T Get(Expression<Func<T, bool>> filter); //Burada filtre vermek zorunludur. Eğer =null dersek filtre vermeyedebilirsin anlamına gelir.
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}

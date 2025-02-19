using System.Linq.Expressions;
using Core.Entities; 

namespace Core.DataAccess;
 
// generic constraint yapalım
// class : referens tip
// Ya IEntity ya da onu implemente eden bir nesne olmalı
// new() : new yazarak IEntity olmasını istemiyorum, newlenebilir bir IEntity den implemente elebilen bir nesne olmalı 
public interface IEntityRepository<T> where T : class, IEntity, new()
{
    // burada filtre null verilme sebebi kullanıcı filtre verilmeden tüm veriyi de çekebilm imkanı için.
    List<T> GetAll(Expression<Func<T, bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
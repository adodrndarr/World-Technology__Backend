using System.Collections.Generic;


namespace Data.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Insert(List<T> entities);

        void Update(T entity);
        void DeleteById(int id);
        void DeleteEntities(List<T> entities);
        void Save();
    }
}
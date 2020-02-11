using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBL.Models.Repositories
{
    /// <summary>
    /// Интерфейс репозиториев
    /// </summary>
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
    }
}

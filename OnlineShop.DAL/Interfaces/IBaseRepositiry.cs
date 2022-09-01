using OnlineShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Interfaces
{
    public interface IBaseRepositiry<T>
    {
        Task<bool> CreateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllItems();
        T Update(T entity);
        //TODO: delete by id??
        Task<bool> Delete(T entity);

    }
}

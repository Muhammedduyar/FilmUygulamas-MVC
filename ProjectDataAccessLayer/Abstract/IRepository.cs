using ProjectEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDataAccessLayer.Abstract
{
    public interface IRepository <T> where T : class
    {
        Task<T> GetAllById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T t);
        Task Delete(int id);
        Task Update(T t);
        Task<IEnumerable<T>> Search(string searchterm);
    }
}

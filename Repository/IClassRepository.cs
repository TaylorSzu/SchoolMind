using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Models;

namespace School_Mind.Repository
{
    public interface IClassRepository
    {
        Task<Class> create(Class classe);
        Task<ICollection<Class>> listAll();
        Task<Class> findById(int id);
        Task<Class> update(Class classe);
        Task<Class> delete(int id);
    }
}
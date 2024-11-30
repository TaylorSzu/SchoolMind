using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Models;

namespace School_Mind.Repository
{
    public interface IAccountRepository
    {
        Task<Account> register(Account account);
        Task<ICollection<Account>> view();
        Task<Account> findById(int id);
        Task<Account> update(Account account);
        Task<Account> delete(int id);

    }
}
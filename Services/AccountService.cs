using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using School_Mind.Data;
using School_Mind.Models;
using School_Mind.Repository;

namespace School_Mind.Services
{
    public class AccountService : IAccountRepository
    {
        private readonly SchoolMindContext schoolMindContext;

        public AccountService(SchoolMindContext schoolMindContext)
        {
            this.schoolMindContext = schoolMindContext;
        }

        public async Task<Account> register(Account account)
        {
            if (account == null)
            {
                throw new ArgumentException("Objeto esta vazio");
            }
            else
            {
                await schoolMindContext.AddAsync(account);
                await schoolMindContext.SaveChangesAsync();
            }
            return account;
        }

        public async Task<Account> update(Account account)
        {
            if (account == null)
            {
                throw new ArgumentException("Objeto esta vazio");
            }
            else
            {
                schoolMindContext.Update(account);
                await schoolMindContext.SaveChangesAsync();
            }
            return account;
        }

        public async Task<ICollection<Account>> view()
        {
            return await schoolMindContext.Account.Include(a => a.Class).ToListAsync();
        }

        public async Task<Account> findById(int id){
            return await schoolMindContext.Account.Include(a => a.Class).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account> delete(int id)
        {
            var account = await findById(id);
            if (account == null)
            {
                throw new ArgumentException("Id não pode ser vazio");
            }
            else
            {
                schoolMindContext.Account.Remove(account);
                await schoolMindContext.SaveChangesAsync(); 
            }
            return account;
        }
    }
}

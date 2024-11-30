using Microsoft.EntityFrameworkCore;
using School_Mind.Data;
using School_Mind.Models;
using School_Mind.Repository;

namespace School_Mind.Services
{
    public class ClassService : IClassRepository
    {
        private readonly SchoolMindContext schoolMindContext;

        public ClassService(SchoolMindContext schoolMindContext)
        {
            this.schoolMindContext = schoolMindContext;
        }

        public async Task<Class> create(Class classe)
        {
            if (classe == null)
            {
                throw new ArgumentNullException("O objeto não pode ser vazio");
            }
            else
            {
                await schoolMindContext.AddAsync(classe);
                await schoolMindContext.SaveChangesAsync();
            }
            return classe;
        }

        public async Task<Class> delete(int id)
        {
            var classe = await findById(id);
            if (classe == null)
            {
                throw new ArgumentException("O objeto não pode ser vazio");
            }
            else
            {
                schoolMindContext.Remove(classe);
                await schoolMindContext.SaveChangesAsync();
            }
            return classe;
        }
        
        public async Task<ICollection<Class>> listAll()
        {
            return await schoolMindContext.Class.Include(c => c.Creator).Include(c => c.Students).ThenInclude(sp => sp.Account).ToListAsync();
        }

        public async Task<Class> findById(int id)
        {
            return await schoolMindContext.Class.Include(c => c.Creator).FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<Class> update(Class classe)
        {
            if (classe == null)
            {
                throw new ArgumentNullException("O objeto não pode ser vazio");
            }
            else
            {
                schoolMindContext.Update(classe);
                await schoolMindContext.SaveChangesAsync();
            }
            return classe;
        }
    }
}

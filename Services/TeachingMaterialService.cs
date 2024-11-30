using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_Mind.Data;
using School_Mind.Models;
using School_Mind.Repository;

namespace School_Mind.Services
{
    public class TeachingMaterialService : ITeachingMaterialRepository
    {
        private readonly SchoolMindContext schoolMindContext;

        public TeachingMaterialService(SchoolMindContext schoolMindContext)
        {
            this.schoolMindContext = schoolMindContext;
        }

        public async Task deleteMaterial(int id)
        {
            var teachingMaterial = await findById(id);
            if (teachingMaterial == null)
            {
                throw new ArgumentException("O objeto não pode ser vazio");
            }
            else
            {
                schoolMindContext.Remove(teachingMaterial);
                await schoolMindContext.SaveChangesAsync();
            }
        }

        public async Task<TeachingMaterial> findById(int id)
        {
            return await schoolMindContext.TeachingMaterial.Include(t=>t.Creator).Include(t=>t.Class).FirstOrDefaultAsync(t=>t.Id == id);
        }

        public async Task<ICollection<TeachingMaterial>> listAllMaterial()
        {
            return await schoolMindContext.TeachingMaterial.Include(t=>t.Creator).Include(t=>t.Class).ToListAsync();
        }

        public async Task<TeachingMaterial> newMaterial(TeachingMaterial teachingMaterial)
        {
            if (teachingMaterial == null)
            {
                throw new ArgumentException("O objeto não pode ser vazio");
            }
            else
            {
                await schoolMindContext.AddAsync(teachingMaterial);
                await schoolMindContext.SaveChangesAsync();
            }
            return teachingMaterial;
        }

        public async Task<TeachingMaterial> updateMaterial(TeachingMaterial teachingMaterial)
        {
            if (teachingMaterial == null)
            {
                throw new ArgumentException("O objeto não pode ser vazio");
            }
            else
            {
                schoolMindContext.Update(teachingMaterial);
                await schoolMindContext.SaveChangesAsync();
            }
            return teachingMaterial;
        }
    }
}

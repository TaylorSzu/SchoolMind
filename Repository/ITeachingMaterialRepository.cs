using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Models;

namespace School_Mind.Repository
{
    public interface ITeachingMaterialRepository
    {
        Task<TeachingMaterial> newMaterial(TeachingMaterial teachingMaterial);
        Task<TeachingMaterial> updateMaterial(TeachingMaterial teachingMaterial);
        Task<ICollection<TeachingMaterial>> listAllMaterial();
        Task<TeachingMaterial> findById(int id);
        Task deleteMaterial(int id);
    }
}
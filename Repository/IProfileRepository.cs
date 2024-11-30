using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Models;

namespace School_Mind.Repository
{
    public interface IProfileRepository
    {
        Task<StudentProfile> getStudentProfile();
        Task<bool> IsStudent(int accountId);
    }
}
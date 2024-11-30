using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Models;

namespace School_Mind.Repository
{
    public interface IStudentProfileRepository
    {
        Task<StudentProfile> addStudent(StudentProfile sp);
        Task<StudentProfile> updateStudent(StudentProfile sp);
        Task<Class> addStudentToClass(int classId, int studentId);
        Task<ICollection<StudentProfile>> listStudentToClass();
        Task<StudentProfile> findStudentById(int id);
        Task deleteStudent(int id);
    }
}
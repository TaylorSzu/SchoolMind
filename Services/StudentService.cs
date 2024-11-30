using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_Mind.Data;
using School_Mind.Enum;
using School_Mind.Models;
using School_Mind.Repository;

namespace School_Mind.Services
{
    public class StudentService : IStudentProfileRepository
    {
        private readonly SchoolMindContext schoolMindContext;

        public StudentService(SchoolMindContext schoolMindContext)
        {
            this.schoolMindContext = schoolMindContext;
        }

        public async Task<StudentProfile> addStudent(StudentProfile sp)
        {
            if (sp == null)
            {
                throw new ArgumentNullException("O objeto não pode ser vazio");
            }
            else
            {
                await schoolMindContext.Student.AddAsync(sp);
                await schoolMindContext.SaveChangesAsync();
            }
            return sp;
        }

        public async Task<Class> addStudentToClass(int classId, int accountId)
        {
            Console.WriteLine(
                $"Iniciando o método addStudentToClass com classId: {classId} e accountId: {accountId}"
            );

            // Verificando se a turma existe
            var classEntity = await schoolMindContext
                .Class.Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == classId);
            if (classEntity == null)
            {
                Console.WriteLine("Classe não encontrada");
                throw new ArgumentException("Classe não encontrada");
            }

            // Verificando se a conta do estudante existe e é do tipo Student
            var studentAccount = await schoolMindContext.Account.FirstOrDefaultAsync(a =>
                a.Id == accountId && a.Type == UserType.Student
            );
            if (studentAccount == null)
            {
                Console.WriteLine(
                    "Conta de estudante não encontrada ou a conta não é do tipo Student"
                );
                throw new ArgumentException(
                    "Conta de estudante não encontrada ou a conta não é do tipo Student"
                );
            }

            // Verificando se o perfil do estudante existe
            var studentProfile = await schoolMindContext.Student.FirstOrDefaultAsync(sp =>
                sp.AccountId == accountId
            );
            if (studentProfile == null)
            {
                Console.WriteLine("Perfil de estudante não encontrado");
                throw new ArgumentException("Perfil de estudante não encontrado");
            }

            // Associando o estudante à turma
            studentProfile.ClassId = classId;
            if (!classEntity.Students.Contains(studentProfile))
            {
                classEntity.Students.Add(studentProfile);
            }

            await schoolMindContext.SaveChangesAsync();

            Console.WriteLine("Estudante adicionado à classe com sucesso");
            return classEntity;
        }

        public async Task deleteStudent(int id)
        {
            var student = await findStudentById(id);
            if (student == null)
            {
                throw new ArgumentException("O objeto não pode ser vazio");
            }
            else
            {
                schoolMindContext.Student.Remove(student);
                await schoolMindContext.SaveChangesAsync();
            }
        }

        public async Task<StudentProfile> findStudentById(int id)
        {
            return await schoolMindContext
                .Student.Include(sp => sp.Account)
                .Include(sp => sp.Class)
                .FirstOrDefaultAsync(sp => sp.Id == id);
        }

        public async Task<ICollection<StudentProfile>> listStudentToClass()
        {
            return await schoolMindContext
                .Student.Include(sp => sp.Account)
                .Include(sp => sp.Class)
                .ToListAsync();
        }

        public async Task<StudentProfile> updateStudent(StudentProfile sp)
        {
            if (sp == null)
            {
                throw new ArgumentNullException("O objeto não pode ser vazio");
            }
            else
            {
                schoolMindContext.Student.Update(sp);
                await schoolMindContext.SaveChangesAsync();
            }
            return sp;
        }
    }
}

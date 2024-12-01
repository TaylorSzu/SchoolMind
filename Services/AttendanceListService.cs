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
    public class AttendanceListService : IAttendanceListRepository
    {
        private readonly SchoolMindContext schoolMindContext;

        public AttendanceListService(SchoolMindContext schoolMindContext)
        {
            this.schoolMindContext = schoolMindContext;
        }

        public async Task<AttendanceList> AddAttendanceAsync(AttendanceList attendance)
        {
            if (attendance == null)
            {
                throw new ArgumentNullException("O objeto não pode ser vazio");
            }
            else
            {
                await schoolMindContext.AddAsync(attendance);
                await schoolMindContext.SaveChangesAsync();
            }
            return attendance;
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendance = await schoolMindContext.Attendances.FindAsync(id);
            if (attendance != null)
            {
                schoolMindContext.Attendances.Remove(attendance);
                await schoolMindContext.SaveChangesAsync();
            }
        }

        public async Task<AttendanceList> GetAttendanceByIdAsync(int id)
        {
            return await schoolMindContext.Attendances
                .Include(a => a.Student)
                .Include(a => a.Class)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<ICollection<AttendanceList>> GetAttendancesByStudentAndClassAsync(int studentId, int classId)
        {
            return await schoolMindContext.Attendances
                .Where(a => a.StudentId == studentId && a.ClassId == classId)
                .Include(a => a.Student)
                .Include(a => a.Class)
                .ToListAsync();
        }

        public async Task<ICollection<AttendanceList>> GetAttendancesByStudentIdAsync(int studentId)
        {
            return await schoolMindContext.Attendances
                .Where(a => a.StudentId == studentId)
                .Include(a => a.Class)
                .ToListAsync();
        }

        public async Task<AttendanceList> UpdateAttendanceAsync(AttendanceList attendance)
        {
            if (attendance == null)
            {
                throw new ArgumentNullException("O objeto não pode ser vazio");
            }
            else
            {
                schoolMindContext.Update(attendance);
                await schoolMindContext.SaveChangesAsync();
            }
            return attendance;
        }
    }
}
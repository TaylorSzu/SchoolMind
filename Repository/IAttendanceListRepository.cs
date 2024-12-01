using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Models;

namespace School_Mind.Repository
{
    public interface IAttendanceListRepository
    {
        Task<AttendanceList> AddAttendanceAsync(AttendanceList attendance);
        Task<AttendanceList> UpdateAttendanceAsync(AttendanceList attendance);
        Task DeleteAttendanceAsync(int id);
        Task<AttendanceList> GetAttendanceByIdAsync(int id);
        Task<ICollection<AttendanceList>> GetAttendancesByStudentIdAsync(int studentId);
        Task<ICollection<AttendanceList>> GetAttendancesByStudentAndClassAsync(int studentId, int classId);
    }
}
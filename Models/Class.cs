using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mind.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string Serie { get; set; }
        public string Discipline { get; set; }

        //Relacionamento
        public int AccountId { get; set; }
        public Account Creator { get; set; }
        public ICollection<Calendar> Calendars { get; set;} = new List<Calendar>();
        public ICollection<TeachingMaterial> TeachingMaterials { get; set; } = new List<TeachingMaterial>();
        public ICollection<StudentProfile> Students { get; set; } = new List<StudentProfile>();
        public ICollection<AttendanceList> AttendanceLists { get; set; } = new List<AttendanceList>();
    }
}
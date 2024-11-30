using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Enum;

namespace School_Mind.Models
{
    public class Account
    {
        [Required]
        public int Id { get; set;}

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserType Type { get; set; }

        //Relação de um para muitos
        public ICollection<Class> Class { get; set; } = new List<Class>();

        // Relacionamento com materiais de ensino (se necessário)
        public ICollection<TeachingMaterial> TeachingMaterials { get; set; } = new List<TeachingMaterial>();

        // Relacionamento com calendário (se necessário)
        public ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

        // Relacionamento com a lista de presença (se necessário)
        public ICollection<AttendanceList> AttendanceLists { get; set; } = new List<AttendanceList>();

        //teste por enqunato
        public ICollection<StudentProfile> Students { get; set; } = new List<StudentProfile>();
    }
}
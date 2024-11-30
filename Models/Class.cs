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

        //Relacionamento com a conta do criador
        public int AccountId { get; set; }
        public Account Creator { get; set; }

        //Relacionamento com Calendar 
        public ICollection<Calendar> Calendars { get; set;} = new List<Calendar>();

        //Relacionamento com TeachingMaterial
        public ICollection<TeachingMaterial> TeachingMaterials { get; set; } = new List<TeachingMaterial>();

        //Relacionamento com as contas relacionadas com aos estudantes
        public ICollection<StudentProfile> Students { get; set; } = new List<StudentProfile>();
    }
}
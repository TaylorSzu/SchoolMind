using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mind.Models
{
    public class AttendanceList
    {
        public int Id { get; set; }
        public Boolean isPresent { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }

        //Relacionamento com turma
        public int AccountId { get; set; }
        public Account Creator { get; set; }

        //Relacionamento com conta
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
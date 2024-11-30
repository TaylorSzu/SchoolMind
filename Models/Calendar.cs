using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mind.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public DateTime Day { get; set; }

        //Relacionamento com turma
        public int ClassId { get; set; }
        public Class Class { get; set; }

        //Relacionamento com a conta
        public int AccountId { get; set; }
        public Account Creator { get; set; }
    }
}
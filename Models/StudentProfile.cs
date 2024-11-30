using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School_Mind.Enum;

namespace School_Mind.Models
{
    public class StudentProfile 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string RegisterNumber { get; set; }

        //Relacionamento com a classe e a conta
        public int AccountId { get; set; }
        public Account Account { get; set; }

        //Relacionamento com a turma e o estudante
        public int? ClassId { get; set; }
        public Class Class { get; set; }
    }
}
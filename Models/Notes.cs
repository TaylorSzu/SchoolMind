using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mind.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public float Note { get; set; }

        //Relacionamento com turma
        public int AccountId { get; set; }
        public Account Creator { get; set; }

        //Relacionamento com conta
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
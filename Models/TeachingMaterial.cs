using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mind.Models
{
    public class TeachingMaterial
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TypeFile { get; set; }
        public string Description { get; set; }
        public string? ContextText { get; set; }
        public string? RouteFile { get; set; }
        public string? Url { get; set; }

        //Relacionamento com turma
        public int ClassId { get; set; }
        public Class Class { get; set; }

        //Relacionamento com conta
        public int AccountId { get; set; }
        public Account Creator { get; set; }
    }
}
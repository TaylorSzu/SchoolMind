using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mind.Models
{
    public class AttendanceList
    {
    public int Id { get; set; } // Identificador único para a presença.

    public DateTime Date { get; set; } // Data e hora da aula.
    public bool IsPresent { get; set; }

    public int ClassId { get; set; } // Relacionamento com a turma.
    public Class? Class { get; set; }

    public int StudentId { get; set; } // Relacionamento com o aluno.
    public StudentProfile? Student { get; set; }

    }
}
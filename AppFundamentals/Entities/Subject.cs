using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppFundamentals.Entities
{
    public class Subject
    {
        public int IdSubject { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<SubjectStudent> SubjectStudents { get; private set; }
        public virtual IEnumerable<SubjectTeacher> SubjectTeachers { get; private set; }
    }
}

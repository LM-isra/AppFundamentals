using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppFundamentals.Entities
{
    public class Student
    {
        public int IdStudent { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Enrollment { get; set; }

        public virtual IEnumerable<SubjectStudent> SubjectStudents { get; private set; }
    }
}

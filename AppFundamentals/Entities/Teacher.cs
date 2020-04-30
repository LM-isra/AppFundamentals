using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppFundamentals.Entities
{
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Schedule { get; set; }
        [Required]
        public decimal Salary { get; set; }

        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    }
}

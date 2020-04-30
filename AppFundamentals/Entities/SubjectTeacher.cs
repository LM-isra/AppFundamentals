using System.ComponentModel.DataAnnotations;

namespace AppFundamentals.Entities
{
    public class SubjectTeacher
    {
        [Required]
        public int IdSubject { get; set; }
        [Required]
        public int IdTeacher { get; set; }
        public virtual Subject Subject { get; private set; }
        public virtual Teacher Teacher { get; private set; }
    }
}

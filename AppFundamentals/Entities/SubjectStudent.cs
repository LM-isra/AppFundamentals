using System.ComponentModel.DataAnnotations;

namespace AppFundamentals.Entities
{
    public class SubjectStudent
    {
        [Required]
        public int IdSubject { get; set; }
        [Required]
        public int IdStudent { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public decimal Note { get; set; }
        public virtual Subject Subject { get; private set; }
        public virtual Student Student { get; private set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace AppFundamentals.Entities
{
    public class HostedServiceLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
    }
}

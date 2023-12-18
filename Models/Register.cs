using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Btl.Models
{
    public class Register
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserPassword { get; set; }
        [Required]
        public string? ConfirmUserPassword { get; set; }
    }
}

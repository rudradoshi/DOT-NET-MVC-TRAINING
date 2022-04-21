

using System.ComponentModel.DataAnnotations;


namespace MVC.Models
{
    public class UserAccount
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string? CreatedAt { get; set; }

        public string ?EditedAt { get; set; }

        public string? DeletedAt { get; set; }


        [Required]
        public string ?FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string ?ContactNo { get; set; }

        [Required]
        public string ?EmailId { get; set; }
        [Required]
        public string ?Password { get; set; }

        [Required]
        public char ?Gender { get; set; }

        [Required]
        public char Status { get; set; }

    }
   
}

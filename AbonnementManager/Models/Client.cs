using System.ComponentModel.DataAnnotations;

namespace AbonnementManager.Models
{
    public class Client
    {
        [Key]
        public int Id_Client { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string Description { get; set; }

    }
}

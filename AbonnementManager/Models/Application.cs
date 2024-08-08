using System.ComponentModel.DataAnnotations;

namespace AbonnementManager.Models
{
    public class Application
    {
        [Key]
        public int Id_App { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }


    }
}

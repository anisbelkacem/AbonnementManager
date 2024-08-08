using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbonnementManager.Models
{
    public class Abonnement
    {
        [Key]
        public int Id_Abon { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        
        public int IdClient { get; set; }
        [ForeignKey("IdClient")]
        [ValidateNever]
        public Client Client { get; set; }


        [Required]
        

        public int IdApp { get; set; }
        [ForeignKey("IdApp")]
        [ValidateNever]
        public  Application Application { get; set; }
        [Required]
        public DateOnly DateDebut { get; set; }
        [Required]
        public DateOnly DateFin { get; set; }


    }
}

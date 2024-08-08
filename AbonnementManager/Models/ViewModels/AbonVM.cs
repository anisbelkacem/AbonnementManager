
using AbonnementManager.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ApplicationManager.Models.ViewModels
{
    public class AbonVM
    {
        public Abonnement Abonnement { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ApplicationList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ClientList { get; set; }
    }
}
using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class AnimalDetailsModel : PageModel
    {
        public Animal? animal;
        private readonly IAnimalsService animalsService;

        public AnimalDetailsModel(IAnimalsService animalsService)
        {
            this.animalsService = animalsService;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Query["id"].ToString());
            animal = animalsService.Get(id);
        }
    }
}

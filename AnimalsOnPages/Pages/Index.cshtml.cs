using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class IndexModel : PageModel
    {
        public List<Animal>? animals;
        private readonly IAnimalsService animalsService;

        public IndexModel(IAnimalsService animalsService)
        {
            this.animalsService = animalsService;
        }

        public void OnGet()
        {
            animals = animalsService.GetAll();
        }

    }
}

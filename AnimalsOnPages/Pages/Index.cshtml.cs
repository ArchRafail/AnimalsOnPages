using AnimalsOnPages.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ViewAnimals? View { get; set; }
        private readonly IAnimalsService animalsService;

        public IndexModel(IAnimalsService animalsService)
        {
            this.animalsService = animalsService;
        }

        public void OnGet()
        {
            View = new ViewAnimals();
            View.Animals = animalsService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (View == null)
            {
                return BadRequest();
            }
            var id = int.Parse(View.ButtonPressed!);
            animalsService.Delete(id);
            View.Animals = animalsService.GetAll();
            return Page();
        }
    }
}

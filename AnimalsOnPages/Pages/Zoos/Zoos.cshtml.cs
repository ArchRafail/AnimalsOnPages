using AnimalsOnPages.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages.Zoos
{
    public class ZoosModel : PageModel
    {
        [BindProperty]
        public ViewZoos? View { get; set; }
        private readonly IZoosService zoosService;

        public ZoosModel(IZoosService zoosService)
        {
            this.zoosService = zoosService;
        }

        public void OnGet()
        {
            View = new ViewZoos();
            View.Zoos = zoosService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (View == null)
            {
                return BadRequest();
            }
            var id = int.Parse(View.ButtonPressed!);
            zoosService.Delete(id);
            View.Zoos = zoosService.GetAll();
            return Page();
        }
    }
}

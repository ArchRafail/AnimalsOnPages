using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class ZooDetailsModel : PageModel
    {
        public Zoo? zoo;
        private readonly IZoosService zoosService;

        public ZooDetailsModel(IZoosService zoosService)
        {
            this.zoosService = zoosService;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Query["id"].ToString());
            zoo = zoosService.Get(id);
        }
    }
}

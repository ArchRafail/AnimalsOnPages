using AnimalsOnPages.Dtos;
using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class AddAnimalModel : PageModel
    {
        private readonly IAnimalsService _animalsService;

        public Animal? animal { get; set; }

        [BindProperty]
        public AnimalDto? Input { get; set; }

        [BindProperty]
        public string? AnimalClass { get; set; }

        [BindProperty]
        public string? Button { get; set; }

        public AddAnimalModel(IAnimalsService animalsService)
        {
            _animalsService = animalsService;
        }

        public void OnGet()
        {
            var id = GetId();
            if (id != -1)
            {
                animal = _animalsService.Get(id!);
            }
            else
            {
                animal = null;
            }
        }

        public IActionResult OnPost()
        {
            if (Button == "cancel")
            {
                return RedirectToPage("/Index");
            }

            if (Button == "create")
            {
                if (string.IsNullOrEmpty(Input.Name) || Input.Name.Length < 3 || Input.CoverColor.Length > 20)
                {
                    return Page();
                }
                if (string.IsNullOrEmpty(Input.Sound) || Input.Sound.Split( new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries).Length is not 3)
                {
                    return Page();
                }
                if (string.IsNullOrEmpty(Input.CoverColor) || Input.CoverColor.Length < 3 || Input.CoverColor.Length > 20)
                {
                    return Page();
                }

                if (Input.Id == 0)
                {
                    _animalsService.Add(AnimalClass!, Input);
                }
                else
                {
                    _animalsService.Update(AnimalClass!, Input);
                }
            }

            return RedirectToPage("/Index");
        }

        private int GetId()
        {
            string? idString = Request.Query["id"].ToString();
            var id = -1;
            if (idString.Length > 0)
            {
                id = Convert.ToInt32(idString);
            }
            return id;
        }
    }
}

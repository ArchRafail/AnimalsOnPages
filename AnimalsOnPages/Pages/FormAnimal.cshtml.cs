using AnimalsOnPages.Dtos;
using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class FormAnimalModel : PageModel
    {
        private readonly IAnimalsService animalsService;
        private readonly IZoosService zoosService;

        public Animal? Animal { get; set; }
        public List<Zoo>? Zoos { get; set; }

        [BindProperty]
        public AnimalDto? Input { get; set; }

        [BindProperty]
        public string? AnimalClass { get; set; }

        [BindProperty]
        public List<int>? PickedZoosId { get; set; }

        [BindProperty]
        public string? Button { get; set; }

        public FormAnimalModel(IAnimalsService animalsService, IZoosService zoosService)
        {
            this.animalsService = animalsService;
            this.zoosService = zoosService;
        }

        public void OnGet()
        {
            var id = GetId();
            if (id != -1)
            {
                Animal = animalsService.Get(id!);
            }
            else
            {
                Animal = null;
            }
            Zoos = zoosService.GetAll();
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
                if (string.IsNullOrEmpty(Input.Sound) || Input.Sound.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries).Length is not 3)
                {
                    return Page();
                }
                if (!string.IsNullOrEmpty(Input.CoverColor) && (Input.CoverColor.Length < 3 || Input.CoverColor.Length > 20))
                {
                    return Page();
                }

                if (PickedZoosId != null && PickedZoosId.Count != 0)
                {
                    Animal.Zoos = new List<Zoo>();
                    List<Zoo> zoos = zoosService.GetAll();
                    foreach (var zooId in PickedZoosId)
                    {
                        Zoo? zoo = zoos.Where(a => a.Id == zooId).FirstOrDefault();
                        if (zoo != null)
                        {
                            Animal.Zoos.Add(zoo);
                        }
                    }
                }

                if (Input.Id == 0)
                {
                    animalsService.Add(AnimalClass!, Input);
                }
                else
                {
                    animalsService.Update(AnimalClass!, Input);
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

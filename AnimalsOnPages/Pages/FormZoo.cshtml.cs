using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class FormZooModel : PageModel
    {
        private readonly IZoosService zoosService;
        private readonly IAddressesService addressesService;
        private readonly IAnimalsService animalsService;

        [BindProperty]
        public Zoo? Zoo { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<Animal>? Animals { get; set; }

        [BindProperty]
        public List<int>? PickedAnimalsId { get; set; }

        [BindProperty]
        public string? Button { get; set; }

        public FormZooModel(IZoosService zoosService,
            IAddressesService addressesService,
            IAnimalsService animalsService)
        {
            this.zoosService = zoosService;
            this.addressesService = addressesService;
            this.animalsService = animalsService;
        }

        public void OnGet()
        {
            var id = GetId();
            if (id != -1)
            {
                Zoo = zoosService.Get(id!);
            }
            else
            {
                Zoo = null;
            }
            Addresses = addressesService.GetAll();
            Animals = animalsService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (Button == "cancel")
            {
                return RedirectToPage("/Zoos/Zoos");
            }

            if (Button == "create")
            {
                if (string.IsNullOrEmpty(Zoo.Name) || Zoo.Name.Length < 3 || Zoo.Name.Length > 40)
                {
                    return Page();
                }

                if (PickedAnimalsId != null && PickedAnimalsId.Count != 0)
                {
                    Zoo.Animals = new List<Animal>();
                    List<Animal> animals = animalsService.GetAll();
                    foreach (var animalId in PickedAnimalsId)
                    {
                        Animal? animal = animals.Where(a => a.Id == animalId).FirstOrDefault();
                        if (animal != null)
                        {
                            Zoo.Animals.Add(animal);
                        }
                    }
                }

                if (Zoo.Id == 0)
                {
                    zoosService.Add(Zoo);
                }
                else
                {
                    zoosService.Update(Zoo);
                }
            }

            return RedirectToPage("/Zoos/Zoos");
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

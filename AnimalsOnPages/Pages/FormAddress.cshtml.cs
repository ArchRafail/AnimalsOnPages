using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class FormAddressModel : PageModel
    {
        private readonly IAddressesService addressesService;

        [BindProperty]
        public Address? Address { get; set; }

        [BindProperty]
        public string? Button { get; set; }

        public FormAddressModel(IAddressesService addressesService)
        {
            this.addressesService = addressesService;
        }

        public void OnGet()
        {
            var id = GetId();
            if (id != -1)
            {
                Address = addressesService.Get(id!);
            }
            else
            {
                Address = null;
            }
        }

        public IActionResult OnPost()
        {
            if (Button == "cancel")
            {
                return RedirectToPage("/Addresses/Addresses");
            }

            if (Button == "create")
            {
                if (Address.PostalCode != null && (Address.PostalCode < 100 || Address.PostalCode > 999999))
                {
                    return Page();
                }
                if (string.IsNullOrEmpty(Address.Country) || Address.Country.Length < 3 || Address.Country.Length > 20)
                {
                    return Page();
                }
                if (string.IsNullOrEmpty(Address.City) || Address.City.Length < 3 || Address.City.Length > 20)
                {
                    return Page();
                }
                if (string.IsNullOrEmpty(Address.Street) || Address.Street.Length < 3 || Address.Street.Length > 20)
                {
                    return Page();
                }
                if (Address.Building < 1 || Address.Building > 10000)
                {
                    return Page();
                }

                if (Address.Id == 0)
                {
                    addressesService.Add(Address);
                }
                else
                {
                    addressesService.Update(Address);
                }
            }

            return RedirectToPage("/Addresses/Addresses");
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

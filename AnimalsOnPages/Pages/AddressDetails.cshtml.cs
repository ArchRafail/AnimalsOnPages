using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages
{
    public class AddressDetailsModel : PageModel
    {
        public Address? address;
        private readonly IAddressesService addressesService;

        public AddressDetailsModel(IAddressesService addressesService)
        {
            this.addressesService = addressesService;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Query["id"].ToString());
            address = addressesService.Get(id);
        }
    }
}

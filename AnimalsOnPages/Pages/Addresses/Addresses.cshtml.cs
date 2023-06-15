using AnimalsOnPages.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalsOnPages.Pages.Addresses
{
    public class AddressesModel : PageModel
    {
        [BindProperty]
        public ViewAddresses? View { get; set; }
        private readonly IAddressesService addressesService;

        public AddressesModel(IAddressesService addressesService)
        {
            this.addressesService = addressesService;
        }

        public void OnGet()
        {
            View = new ViewAddresses();
            View.Addresses = addressesService.GetAll();
        }

        public IActionResult OnPost()
        {
            if (View == null)
            {
                return BadRequest();
            }
            var id = int.Parse(View.ButtonPressed!);
            addressesService.Delete(id);
            View.Addresses = addressesService.GetAll();
            return Page();
        }
    }
}

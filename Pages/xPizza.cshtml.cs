using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza.Models;
using Pizza.Service;

namespace Pizza.Pages
{
    public class xPizzaModel : PageModel
    {
        [BindProperty]
        public PizzaW NewPizza { get; set; }= new();

        public void OnGet()
        {
            pizzas = Services.GetAll();
        }
        public List<PizzaW> pizzas = new();
        public string GlutenFreeText(PizzaW pizza)
        {
            if (pizza.IsGlutenFree)
                return "Gluten Free";
            return "Not Gluten Free";
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Services.Add(NewPizza);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            Services.Delete(id);
            return RedirectToAction("Get");
        }
    }
}


using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//[BindProperties] // binds everything to be used later on
namespace AbbyWeb.Pages.Admin.FoodTypes
{

    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // can use later on
        public FoodType FoodType { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id) // fetched from asp-route-id
        {
            FoodType = _db.FoodType.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.FoodType.Update(FoodType);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category was successfully edited.";

                return RedirectToPage("Index");
            }
            return Page();
    } // use iactionresult when you want a direction after completing the task

    }

}

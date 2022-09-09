
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//[BindProperties] // binds everything to be used later on
namespace AbbyWeb.Pages.Admin.FoodTypes
{

    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // can use later on
        public FoodType FoodType { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            FoodType = _db.FoodType.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {

            var foodTypeFromDb = _db.FoodType.Find(FoodType.Id);
            if (foodTypeFromDb != null)
            {
                _db.FoodType.Remove(foodTypeFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Food Type was successfully deleted.";

                return RedirectToPage("Index");
            }
            return Page();
        } // use iactionresult when you want a direction after completing the task
    }
}

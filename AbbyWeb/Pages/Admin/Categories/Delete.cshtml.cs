
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//[BindProperties] // binds everything to be used later on
namespace AbbyWeb.Pages.Admin.Categories
{

    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // can use later on
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {

            var categoryFromDb = _db.Category.Find(Category.Id);
            if (categoryFromDb != null)
            {
                _db.Category.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category was successfully deleted.";

                return RedirectToPage("Index");
            }
            return Page();
        } // use iactionresult when you want a direction after completing the task
    }
}


using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//[BindProperties] // binds everything to be used later on
namespace AbbyWeb.Pages.Admin.Categories
{

    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // can use later on
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id) // fetched from asp-route-id
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            // if statements for validation if wanted/needed
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Name cannot be identical to the DisplayOrder");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category was successfully edited.";

                return RedirectToPage("Index");
            }
            return Page();
    } // use iactionresult when you want a direction after completing the task

    }

}

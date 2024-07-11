using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _conext;

        public CreateModel(ApplicationDbContext conext)
        {
            _conext = conext;
        }

        public Category Category { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            // Custom server error
            //if (Category.Name == Category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Custom", "The Display Order cannot exactly match the name");
            //}

            // You can add custom error to a field that already exists
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the name");
            }


            if (ModelState.IsValid) 
            { 
                await _conext.Categories.AddAsync(Category);
                await _conext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}


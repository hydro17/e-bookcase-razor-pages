using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBookcase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eBookcase.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Book = await _db.Books.FindAsync(id);
        }
    
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                //return RedirectToPage();
            }

            _db.Books.Update(Book);

            //Book bookFromDb = _db.Books.Find(Book.Id);
            //bookFromDb.Name = Book.Name;
            //bookFromDb.Author = Book.Author;
            //bookFromDb.ISBN = Book.ISBN;

            await _db.SaveChangesAsync();

            Message = "The book was updated succesfully";

            return RedirectToPage("Index");
        }
    }
}
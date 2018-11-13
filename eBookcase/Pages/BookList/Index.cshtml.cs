using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eBookcase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eBookcase.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            Book book = await _db.Books.FindAsync(id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            Message = "Book deleted successfully";

            return RedirectToPage("Index");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task02.Data;
using Task02.Models;
using Microsoft.AspNetCore.Http;

namespace Task02.Controllers
{
    public class HomeController : Controller
    {

        public ApplicationDbContext dbContext { get; }

        public HomeController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveBook([FromBody] Book book)
        {
            if(book != null)
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
                return Json(new { success = true, message = "Book added successfully" });
            }
            var abc= Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
        [HttpPost]
        public IActionResult SaveBookFromForm([FromForm] Book book)
        {
            if(!string.IsNullOrEmpty(book.Title))
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
                return Json(new { success = true, message = "Book added successfully" });
            }
            var abc= Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var AllBooks = dbContext.Books.ToList();
            return Json(AllBooks);
        }
        [HttpGet]
        public IActionResult GetBookByAuthorID([FromQuery] int authorID)
        {
            var AllBooks = dbContext.Books.Where(x=>x.AuthorId==authorID).ToList();
            return Json(AllBooks);
        }
        [HttpDelete]
        public IActionResult DeleteBookByID([FromRoute] int id)
        {
            var isExist = dbContext.Books.FirstOrDefault(x => x.BookId == id);
            if (isExist != null)
            {
                dbContext.Books.Remove(isExist);
                dbContext.SaveChanges();
                return Json(new { success = true, message = "Book deleted successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Failed to delete the book OR No book Found with ID" });
            }
            
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
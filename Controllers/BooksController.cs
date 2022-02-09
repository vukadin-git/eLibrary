using eLibrary.Data;
using eLibrary.Data.Services;
using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _service;
        public BooksController(IBooksService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllAsync();
            return View(allBooks);
        }

        //Search a book
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allBooks.Where(n => n.Title.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allBooks);
        }

        //Get: Books/details/1
        public async Task<IActionResult> Details(int id)
        {
            var bookDetail = await _service.GetBookByIdAsync(id);
            return View(bookDetail);
        }

        //Get: Books/Create
        public async Task<IActionResult> Create()
        {
            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.WriterId = new SelectList(bookDropdownsData.Writers, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.WriterId = new SelectList(bookDropdownsData.Writers, "Id", "FullName");
                return View(book);
            }
            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        //Get: Books/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Description = bookDetails.Description,
                ImageURL = bookDetails.ImageURL,
                WriterId = bookDetails.WriterId,
                Price = bookDetails.Price,
                BookCategory = bookDetails.BookCategory,
                ReleaseDate = bookDetails.ReleaseDate
            };

            var bookDropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.WriterId = new SelectList(bookDropdownsData.Writers, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id != book.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.WriterId = new SelectList(bookDropdownsData.Writers, "Id", "FullName");
                return View(book);
            }
            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
    }
}

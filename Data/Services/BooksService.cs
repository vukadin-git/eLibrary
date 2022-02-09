using eLibrary.Data.Base;
using eLibrary.Data.ViewModels;
using eLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Data.Services
{
    public class BooksService : EntityBaseRepository<Book>, IBooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var NewBook = new Book()
            {
                Title = data.Title,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ReleaseDate = data.ReleaseDate,
                BookCategory = data.BookCategory,
                WriterId = data.WriterId
            };
            await _context.Books.AddAsync(NewBook);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = _context.Books
                .Include(w => w.Writer)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await bookDetails;
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Writers = await _context.Writers.OrderBy(n => n.FullName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbBook != null)
            {
                dbBook.Title = data.Title;
                dbBook.Description = data.Description;
                dbBook.Price = data.Price;
                dbBook.ImageURL = data.ImageURL;
                dbBook.ReleaseDate = data.ReleaseDate;
                dbBook.BookCategory = data.BookCategory;
                dbBook.WriterId = data.WriterId;
                await _context.SaveChangesAsync();
            }
        }
    }
}


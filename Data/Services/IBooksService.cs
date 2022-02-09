using eLibrary.Data.Base;
using eLibrary.Data.ViewModels;
using eLibrary.Models;
using System.Threading.Tasks;

namespace eLibrary.Data.Services
{
    public interface IBooksService:IEntityBaseRepository<Book>
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<NewBookDropdownsVM> GetNewBookDropdownsValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
    }
}

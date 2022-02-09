using eLibrary.Data;
using eLibrary.Data.Services;
using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Controllers
{
    public class WritersController : Controller
    {
        private readonly IWritersService _service;
        public WritersController(IWritersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allWriters = await _service.GetAllAsync();
            return View(allWriters);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return View(writer);
            }
            await _service.AddAsync(writer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Writers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var writerDetails = await _service.GetByIdAsync(id);
            if (writerDetails == null) return View("NotFound");
            return View(writerDetails);
        }

        //Writers edit
        public async Task<IActionResult> Edit(int id)
        {
            var writerDetails = await _service.GetByIdAsync(id);
            if (writerDetails == null) return View("NotFound");
            return View(writerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Writer writer)
        {
            if (!ModelState.IsValid)
            {
                return View(writer);
            }
            await _service.UpdateAsync(id, writer);
            return RedirectToAction(nameof(Index));
        }

        //Writers delete
        public async Task<IActionResult> Delete(int id)
        {
            var writerDetails = await _service.GetByIdAsync(id);
            if (writerDetails == null) return View("NotFound");
            return View(writerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

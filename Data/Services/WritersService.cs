using eLibrary.Data.Base;
using eLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Data.Services
{    

    public class WritersService : EntityBaseRepository<Writer>, IWritersService
    {
        public WritersService(AppDbContext context) : base(context) { }
    }
}

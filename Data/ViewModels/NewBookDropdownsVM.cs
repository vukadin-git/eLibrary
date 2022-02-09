using eLibrary.Models;
using System.Collections.Generic;

namespace eLibrary.Data.ViewModels
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM()
        {
            Writers = new List<Writer>();
        }
        public List<Writer> Writers { get; set; }
    }
}

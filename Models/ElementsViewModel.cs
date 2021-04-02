using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLAdd.Models
{
    public enum Elements
    {
        Name,
        Author,
        ISBN,
        Price,
        Description,
        Page,
        Year,
        Publication,
        Language
    }
    public class ElementsViewModel
    {
        public Elements Element { get; set; }
    }
}

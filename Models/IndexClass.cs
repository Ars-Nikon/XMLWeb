using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLAdd.Models
{
    public class IndexClass
    {
        public IEnumerable<Book> Books { get; set; }
        public ElementsViewModel ElementsViewModel { get; set; }
        public string text { get; set; }
    }
}

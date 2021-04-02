using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLAdd.Models
{
    public interface IXMLRepository
    {
        public void Add(Book book);
        public IEnumerable<Book> Books();
        public void Delete(Book book);
        public void Edit(Book book);
    }
}

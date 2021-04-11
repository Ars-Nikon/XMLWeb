using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLAdd.Models
{
    public class RepositiryXML : IXMLRepository
    {
        private List<Book> books;

        private  void Save()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream(@"XMLFile.xml", FileMode.Create))
            {
                formatter.Serialize(fs, this.books);
            }
        }


        public  RepositiryXML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream(@"XMLFile.xml", FileMode.OpenOrCreate))
            {
                books = (List<Book>)formatter.Deserialize(fs);
            }
        }

        public void Add(Book book)
        {
            Random random = new Random();
            while (true)
            {
                int id = random.Next();
                if (books.Find(x=>x.Id == id) == null)
                {
                    book.Id = id;
                    break;
                }
            }
            books.Add(book);
            Save();
        }

        public IEnumerable<Book> Books()
        {
            return books;
        }

        public void Edit(Book book)
        {
            Book bookRemove = books.First(x=>x.Id==book.Id);
            books.Remove(bookRemove);
            books.Add(book);
            Save();
        }

        public void Delete(Book book)
        {
            Book bookRemove = books.First(x => x.Id == book.Id);
            books.Remove(bookRemove);
            Save();
        }
    }
}

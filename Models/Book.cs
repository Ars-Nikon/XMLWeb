using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLAdd.Models
{

    [Serializable]
    public class Book
    {
        public Book()
        {

        }

        [XmlAttribute]
        public int Id { get; set; } = -1;

        public string Name { get; set; }
        public Authors Authors { get; set; }
        public long ISBN { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Number_Page { get; set; }
        public int Year { get; set; }
        public string Publication { get; set; }
        public string Language { get; set; }

    }

    [Serializable]
    public class Authors
    {
        public Authors()
        {

        }
        public string Author { get; set; }
    }
}

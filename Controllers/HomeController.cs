using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLAdd.Models;

namespace XMLAdd.Controllers
{
    public class HomeController : Controller
    {
        private IXMLRepository repositiryXML;

        public HomeController(IXMLRepository repositiryXML)
        {
            this.repositiryXML = repositiryXML;
        }

        public IActionResult Product(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            return View(repositiryXML.Books().First(x => x.Id == Id));
        }


        public IActionResult Search(ElementsViewModel elementsViewModel, string text)
        {
            List<Book> books = null;
            if (text == null)
            {
                return View(books);
            }
            switch (elementsViewModel.Element.ToString())
            {
                case ("Name"):
                    {
                        books.AddRange(repositiryXML.Books().Where(x=>x.Name==text.Trim()));
                        break;
                    }

                case ("Author"):
                    {
                        books.AddRange(repositiryXML.Books().Where(x => x.Authors.Author == text.Trim()));
                        break;
                    }
                case ("ISBN"):
                    {
                        int ISBM;
                        if (int.TryParse(text.Trim(), out ISBM))
                        {
                            books.AddRange(repositiryXML.Books().Where(x => x.ISBN ==  ISBM));
                        }
                       
                        break;
                    }
                case ("Price"):
                    {
                        int Price;
                        if (int.TryParse(text.Trim(), out Price))
                        {
                            books.AddRange(repositiryXML.Books().Where(x => x.Price == Price));
                        }
                        break;
                    }
                case ("Description"):
                    {
                        books.AddRange(repositiryXML.Books().Where(x => x.Description == text.Trim()));
                        break;
                    }
                case ("Page"):
                    {
                        int Page;
                        if (int.TryParse(text.Trim(), out Page))
                        {
                            books.AddRange(repositiryXML.Books().Where(x => x.Number_Page == Page));
                        }
                        break;
                    }
                case ("Year"):
                    {
                        int Year;
                        if (int.TryParse(text.Trim(), out Year))
                        {
                            books.AddRange(repositiryXML.Books().Where(x => x.Year == Year));
                        }
                        break;
                    }
                case ("Publication"):
                    {
                        books.AddRange(repositiryXML.Books().Where(x => x.Publication == text.Trim()));
                        break;
                    }
                case ("Language"):
                    {
                        books.AddRange(repositiryXML.Books().Where(x => x.Language == text.Trim()));
                        break;
                    }
                default:
                    break;
            }

            return View(books);
        }

        public IActionResult Index()
        {
            return View(new IndexClass { Books = repositiryXML.Books() });
        }


        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            return View(repositiryXML.Books().First(x => x.Id == Id));
        }


        [HttpPost]
        public IActionResult Edit(Book book)
        {
            repositiryXML.Edit(book);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            repositiryXML.Delete(book);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            repositiryXML.Add(book);
            return RedirectToAction("Index");
        }
    }
}

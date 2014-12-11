using System.Linq;
using System.Web.Mvc;
using Ninject;
using PagedList;
using Rb.Common;
using Rb.Data;
using Rb.Data.Entities;
using Rb.Web.Models;

namespace Rb.Web.Controllers
{
    public class BookController : Controller
    {
        private const int c_pageSize = 10;

        [Inject]
        public IRepository<Book> BookRepository { get; set; }

        [HttpGet]
        public ActionResult Details(int id, int internalId)
        {
            var book = BookRepository.GetById(id, internalId);
            var model = new BookDetailsModel
            {
                Annotation = book.Annotation,
                Author = book.Author,
                HathitrustDetails = book.HathitrustResults.Select(h => new BookDetailsModel.HathitrustDetailsModel
                {
                    Author = h.Author,
                    Description = h.Description,
                    Language = h.Language,
                    Links = h.Links.Select(i => i.Url).ToList(),
                    Publisher = h.Publisher,
                    Url = h.Url
                }).ToList(),
                Language = book.LanguageCode.GetDescription(),
                PublishPlace = book.PublishPlace,
                PublishYear = book.PublishYear,
                Publisher = book.Publisher,
                Size = book.Size,
                Title = book.Title,
                WorlcatDetails = book.WorldcatResults.Select(w => new BookDetailsModel.WorlcatDetailsModel
                {
                    Contents = w.Contents,
                    Description = w.Description,
                    Genre = w.Genre,
                    Notes = w.Notes,
                    OtherTitles = w.OtherTitles,
                    Url = w.Url
                }).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var books = BookRepository.Items
                .OrderBy(i => i.Title)
                .Select(i => new BookModel
                {
                    Author = i.Author,
                    Id = i.Id,
                    InternalId = i.InternalId,
                    PublishYear = i.PublishYear,
                    Title = i.Title,
                });

            var model = new PagedList<BookModel>(books, pageNumber, c_pageSize);

            return View(model);
        }
    }
}
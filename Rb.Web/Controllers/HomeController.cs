using System.Linq;
using System.Web.Mvc;
using Ninject;
using Rb.Data;
using Rb.Data.Entities;
using Rb.Web.Models;

namespace Rb.Web.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IRepository<Book> BookRepository { get; set; }

        [Inject]
        public IRepository<HathitrustResult> HathitrustResultRepository { get; set; }

        [Inject]
        public IRepository<WorldcatResult> WorldcatResultRepository { get; set; }

        public ActionResult Index()
        {
            var model = BookRepository.Items
                .Select(i => new BookModel
                {
                    Author = i.Author,
                    HathitrustResult = HathitrustResultRepository.Items.FirstOrDefault(h => h.BookId == i.InternalId),
                    PublishPlace = i.PublishPlace,
                    PublishYear = i.PublishYear,
                    Publisher = i.Publisher,
                    Size = i.Size,
                    Title = i.Title,
                    WorldcatResult = WorldcatResultRepository.Items.FirstOrDefault(w => w.BookId == i.InternalId)
                })
                .ToList();
            return View();
        }
    }
}
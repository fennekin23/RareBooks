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
        private const int c_pageSize = 10;

        [Inject]
        public IRepository<Book> BookRepository { get; set; }

        [Inject]
        public IRepository<HathitrustResult> HathitrustResultRepository { get; set; }

        [Inject]
        public IRepository<WorldcatResult> WorldcatResultRepository { get; set; }

        public ActionResult Index()
        {
            var model = BookRepository.Items
                .OrderBy(i => i.Title)
                .Skip(c_pageSize*0)
                .Take(c_pageSize)
                .Select(i => new BookModel
                {
                    Author = i.Author,
                    HathitrustResults = i.HathitrustResults.ToList(),
                    PublishPlace = i.PublishPlace,
                    PublishYear = i.PublishYear,
                    Publisher = i.Publisher,
                    Size = i.Size,
                    Title = i.Title,
                    WorldcatResults = i.WorldcatResults.ToList()
                })
                .ToList();

            return View(model);
        }
    }
}
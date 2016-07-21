using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models.Context;
using WeatherApp.Models.HistoryModels;
using PagedList;

namespace WeatherApp.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index(string search, string currentFilter, int? page)
        {
            using (WeatherContext db = new WeatherContext())
            {
                var viewHistory = (from w in db.WeatherHistories
                                   join c in db.CityHistories on w.CityHistoryId equals c.Id
                                   orderby c.CityName
                                   select new HistoryViewModel { WeatherHistory = w, CityHistory = c }).ToList();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    viewHistory = new List<HistoryViewModel>(viewHistory.Where(c => c.CityHistory.CityName.Contains(search.Trim())));
                }

                //For PagedList
                if (search != null)
                {
                    page = 1;
                }
                else
                {
                    search = currentFilter;
                }

                ViewBag.CurrentFilter = search;
                const int pageSize = 100;
                int pageNumber = page ?? 1;

                return View(viewHistory.ToPagedList(pageNumber, pageSize));
            }
        }
    }
}
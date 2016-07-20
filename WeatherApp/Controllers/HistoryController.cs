using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models.Context;
using WeatherApp.Models.HistoryModels;

namespace WeatherApp.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index(string search)
        {
            using (WeatherContext db = new WeatherContext())
            {
                var history = (from w in db.WeatherHistories
                                   join c in db.CityHistories on w.CityHistoryId equals c.Id
                                   select new HistoryViewModel() { WeatherHistory = w, CityHistory = c }).ToList();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    history = new List<HistoryViewModel>(history.Where(c => c.CityHistory.CityName.Contains(search.Trim())));
                }

                return View(history);
            }
        }
    }
}
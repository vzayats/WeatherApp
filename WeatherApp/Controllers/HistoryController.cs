using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models.Context;
using WeatherApp.Models.HistoryModels;

namespace WeatherApp.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index()
        {
            using (WeatherContext db = new WeatherContext())
            {
                var viewHistory = (from w in db.WeatherHistories
                    join c in db.CityHistories on w.CityHistoryId equals c.Id
                    select new HistoryViewModel() {WeatherHistory = w, CityHistory = c}).ToList();

                return View(viewHistory);
            }
        }
    }
}
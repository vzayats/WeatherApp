using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList.EntityFramework;
using WeatherApp.Models;
using WeatherApp.Models.Context;

namespace WeatherApp.Controllers
{
    public class CityController : Controller
    {
        private WeatherContext db = new WeatherContext();

        // GET: City
        public async Task<ActionResult> Index(string search, string currentFilter, int? page)
        {
            var city = from c in db.SelectedCities
                       orderby c.Name
                       select c;

            if (!string.IsNullOrWhiteSpace(search))
            {
                city = (IOrderedQueryable<SelectedCity>)city.Where(c => c.Name.Contains(search.Trim()));
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
            const int pageSize = 5;
            int pageNumber = page ?? 1;

            return View(await city.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: City/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SelectedCity selectedCity)
        {
            if (ModelState.IsValid)
            {
                db.SelectedCities.Add(selectedCity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(selectedCity);
        }

        // GET: City/Delete/1
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SelectedCity selectedCity = await db.SelectedCities.FindAsync(id);

            if (selectedCity == null)
            {
                return HttpNotFound();
            }
            return View(selectedCity);
        }

        // POST: City/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SelectedCity selectedCity = await db.SelectedCities.FindAsync(id);

            if (selectedCity == null)
            {
                return HttpNotFound();
            }

            db.SelectedCities.Remove(selectedCity);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: City/Edit/1
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SelectedCity selectedCity = await db.SelectedCities.FindAsync(id);

            if (selectedCity == null)
            {
                return HttpNotFound();
            }
            return View(selectedCity);
        }

        // POST: City/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SelectedCity selectedCity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selectedCity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(selectedCity);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
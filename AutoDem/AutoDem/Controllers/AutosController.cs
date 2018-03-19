using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoDem.DAL;
using AutoDem.Models;

namespace AutoDem.Controllers
{
    public class AutosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Autos
        public async Task<ActionResult> Index()
        {
            return View(await db.Autos.ToListAsync());
        }

        // GET: Autos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = await db.Autos.FindAsync(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Autos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,YearOfManufacture,Description,Price,Color,DatePublication,Mileage,EngineCapacity,Drive,Transmission,SoldOut")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Autos.Add(auto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(auto);
        }

        // GET: Autos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = await db.Autos.FindAsync(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Autos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,YearOfManufacture,Description,Price,Color,DatePublication,Mileage,EngineCapacity,Drive,Transmission,SoldOut")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(auto);
        }

        // GET: Autos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = await db.Autos.FindAsync(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Auto auto = await db.Autos.FindAsync(id);
            db.Autos.Remove(auto);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

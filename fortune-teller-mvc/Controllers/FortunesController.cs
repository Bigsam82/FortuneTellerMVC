using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fortune_teller_mvc.Models;

namespace fortune_teller_mvc.Controllers
{
    public class FortunesController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Fortunes
        public ActionResult Index()
        {
            return View(db.Fortunes.ToList());
        }

        // GET: Fortunes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fortune fortune = db.Fortunes.Find(id);
            if (fortune == null)
            {
                return HttpNotFound();
            }
            return View(fortune);
        }

        // GET: Fortunes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fortunes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FortuneID,RetireYears,VacHome,Transportation,RetirementFunds")] Fortune fortune)
        {
            if (ModelState.IsValid)
            {
                db.Fortunes.Add(fortune);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fortune);
        }

        // GET: Fortunes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fortune fortune = db.Fortunes.Find(id);
            if (fortune == null)
            {
                return HttpNotFound();
            }
            return View(fortune);
        }

        // POST: Fortunes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FortuneID,RetireYears,VacHome,Transportation,RetirementFunds")] Fortune fortune)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fortune).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fortune);
        }

        // GET: Fortunes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fortune fortune = db.Fortunes.Find(id);
            if (fortune == null)
            {
                return HttpNotFound();
            }
            return View(fortune);
        }

        // POST: Fortunes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fortune fortune = db.Fortunes.Find(id);
            db.Fortunes.Remove(fortune);
            db.SaveChanges();
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

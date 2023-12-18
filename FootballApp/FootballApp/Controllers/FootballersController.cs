using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballApp.Data;
using FootballApp.Models;

namespace FootballApp.Controllers
{
    public class FootballersController : Controller
    {
        private FootballAppContext db = new FootballAppContext();

        // GET: Footballers
        public ActionResult Index()
        {
            var footballers = db.Footballers.Include(f => f._team);
            return View(footballers.ToList());
        }

        // GET: Footballers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footballer footballer = db.Footballers.Find(id);
            if (footballer == null)
            {
                return HttpNotFound();
            }
            return View(footballer);
        }

        // GET: Footballers/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name");
            return View();
        }

        // POST: Footballers/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,Surname,DateOfBirth,Role,TeamID")] Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                db.Footballers.Add(footballer);
                db.SaveChanges();
                footballer._team = db.Teams.Find(footballer.TeamID);
                return RedirectToAction("Index");
                
            }

            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", footballer.TeamID);
            return View(footballer);
        }

        // GET: Footballers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footballer footballer = db.Footballers.Find(id);
            if (footballer == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", footballer.TeamID);
            return View(footballer);
        }

        // POST: Footballers/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,Surname,DateOfBirth,Role,TeamID")] Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footballer).State = EntityState.Modified;
                db.SaveChanges();
                footballer._team = db.Teams.Find(footballer.TeamID);
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", footballer.TeamID);
            return View(footballer);
        }

        // GET: Footballers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footballer footballer = db.Footballers.Find(id);
            if (footballer == null)
            {
                return HttpNotFound();
            }
            return View(footballer);
        }

        // POST: Footballers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Footballer footballer = db.Footballers.Find(id);
            db.Footballers.Remove(footballer);
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

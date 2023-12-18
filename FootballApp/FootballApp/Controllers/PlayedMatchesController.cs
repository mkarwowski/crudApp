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
    public class PlayedMatchesController : Controller
    {
        private FootballAppContext db = new FootballAppContext();

        // GET: PlayedMatches
        public ActionResult Index()
        {
            var playedMatches = db.PlayedMatches.Include(p => p._team);
            return View(playedMatches.ToList());
        }

        // GET: PlayedMatches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayedMatch playedMatch = db.PlayedMatches.Find(id);
            if (playedMatch == null)
            {
                return HttpNotFound();
            }
            return View(playedMatch);
        }

        // GET: PlayedMatches/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name");
            return View();
        }

        // POST: PlayedMatches/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TeamID,_result,GoalsScored,GoalsConceded")] PlayedMatch playedMatch)
        {
            if (ModelState.IsValid)
            {
                db.PlayedMatches.Add(playedMatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", playedMatch.TeamID);
            return View(playedMatch);
        }

        // GET: PlayedMatches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayedMatch playedMatch = db.PlayedMatches.Find(id);
            if (playedMatch == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", playedMatch.TeamID);
            return View(playedMatch);
        }

        // POST: PlayedMatches/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TeamID,_result,GoalsScored,GoalsConceded")] PlayedMatch playedMatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playedMatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "Name", playedMatch.TeamID);
            return View(playedMatch);
        }

        // GET: PlayedMatches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayedMatch playedMatch = db.PlayedMatches.Find(id);
            if (playedMatch == null)
            {
                return HttpNotFound();
            }
            return View(playedMatch);
        }

        // POST: PlayedMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayedMatch playedMatch = db.PlayedMatches.Find(id);
            db.PlayedMatches.Remove(playedMatch);
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

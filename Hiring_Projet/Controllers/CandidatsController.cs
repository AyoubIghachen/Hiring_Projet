using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hiring_Projet.Models;

namespace Hiring_Projet.Controllers
{
    public class CandidatsController : Controller
    {
        private Hiring_DBEntities db = new Hiring_DBEntities();

        // GET: Candidats
        public ActionResult Index()
        {
            return View(db.Candidat.ToList());
        }

        // GET: Candidats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidat candidat = db.Candidat.Find(id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            return View(candidat);
        }

        // GET: Candidats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidats/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_candidat,nom_candidat,prénom_candidat,âge,titre,diplôme,nombre_année_expérience,CV")] Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                db.Candidat.Add(candidat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidat);
        }

        // GET: Candidats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidat candidat = db.Candidat.Find(id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            return View(candidat);
        }

        // POST: Candidats/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_candidat,nom_candidat,prénom_candidat,âge,titre,diplôme,nombre_année_expérience,CV")] Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidat);
        }

        // GET: Candidats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidat candidat = db.Candidat.Find(id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            return View(candidat);
        }

        // POST: Candidats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidat candidat = db.Candidat.Find(id);
            db.Candidat.Remove(candidat);
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

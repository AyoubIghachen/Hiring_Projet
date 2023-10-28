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
    public class RecruteursController : Controller
    {
        private Hiring_DBEntities db = new Hiring_DBEntities();

        // GET: Recruteurs
        public ActionResult Index()
        {
            return View(db.Recruteur.ToList());
        }

        // GET: Recruteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruteur recruteur = db.Recruteur.Find(id);
            if (recruteur == null)
            {
                return HttpNotFound();
            }
            return View(recruteur);
        }

        // GET: Recruteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recruteurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_recruteur,nom_recruteur,Tel,Mail")] Recruteur recruteur)
        {
            if (ModelState.IsValid)
            {
                db.Recruteur.Add(recruteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recruteur);
        }

        // GET: Recruteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruteur recruteur = db.Recruteur.Find(id);
            if (recruteur == null)
            {
                return HttpNotFound();
            }
            return View(recruteur);
        }

        // POST: Recruteurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_recruteur,nom_recruteur,Tel,Mail")] Recruteur recruteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recruteur);
        }

        // GET: Recruteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recruteur recruteur = db.Recruteur.Find(id);
            if (recruteur == null)
            {
                return HttpNotFound();
            }
            return View(recruteur);
        }

        // POST: Recruteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recruteur recruteur = db.Recruteur.Find(id);
            db.Recruteur.Remove(recruteur);
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

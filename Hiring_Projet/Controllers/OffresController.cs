﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Hiring_Projet.Models;

namespace Hiring_Projet.Controllers
{
    public class OffresController : Controller
    {
        private Hiring_DBEntities db = new Hiring_DBEntities();

        // GET: Offres
        public ActionResult Index()
        {
            return View(db.Offre.ToList());
        }

        // GET: Offres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offre.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // GET: Offres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_offre,id_recruteur,type_contrat,secteur,profil,poste,rémunération")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                db.Offre.Add(offre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offre);
        }

        // GET: Offres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offre.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_offre,id_recruteur,type_contrat,secteur,profil,poste,rémunération")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offre);
        }

        // GET: Offres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offre.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offre offre = db.Offre.Find(id);
            db.Offre.Remove(offre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public async Task<ActionResult> Index(string Offresearch)
        {
            ViewData["GetOffredetails"] = Offresearch;

            var offrequery = from x in db.Offre select x;

            if (!String.IsNullOrEmpty(Offresearch))
            {
                offrequery = offrequery.Where(x => x.secteur.Contains(Offresearch) || x.profil.Contains(Offresearch) || x.rémunération.Contains(Offresearch));
            }
            return View(await offrequery.AsNoTracking().ToListAsync());
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

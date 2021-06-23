using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_OSM.DataContext;
using MVC_OSM.Models;
using NLog;

namespace MVC_OSM.Controllers
{
    public class PlaceController : Controller
    {
        private static Logger _logger = LogManager.GetLogger("MYAPPLogerrule");
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Place
        public ActionResult Index()
        {
            _logger.Info("Now listing the all places");
            return View(db.PlaceClasses.ToList());
        }

        // GET: Place/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                _logger.Error("BadRequest request  ApiController.BadRequest Method");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceClass placeClass = db.PlaceClasses.Find(id);
            if (placeClass == null)
            {
                _logger.Error("Error HttpNotFound");

                return HttpNotFound();
            }
            return View(placeClass);
        }

        // GET: Place/Create
        public ActionResult Create()
        {
            _logger.Info("Successfuly We view the places ");

            return View();
        }

        // POST: Place/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "placeid,placname,plactype,placaddress")] PlaceClass placeClass)//,created_on
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.Info("Successfuly We added the Place [ " + placeClass.placname + " ]");
                    db.PlaceClasses.Add(placeClass);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    _logger.Error("Error in adding the Place [ " + placeClass.placname + " ]");
                }

                return View(placeClass);
            }
            catch (Exception e)
            {
                _logger.Error("Error in adding the Place [ " + e.Message + " ]");
                throw;
            }
            
        }

        // GET: Place/Edit/5
        public ActionResult Edit(int? id)
        {
            try 
            { 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceClass placeClass = db.PlaceClasses.Find(id);
            _logger.Info("we search for the Plcae [ " + placeClass.placname + " ]");

            if (placeClass == null)
            {
                _logger.Error(" Place [ " + placeClass.placname + " ] NotFounded");

                return HttpNotFound();
            }
            return View(placeClass);
            }
            catch (Exception e)
            {
                _logger.Error("Error in Editing the Place [ " + e.Message + " ]");
                throw;
            }
        }

        // POST: Place/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "placeid,placname,plactype,placaddress")] PlaceClass placeClass)//,created_on
        {
            try
            { 
            if (ModelState.IsValid)
            {
                db.Entry(placeClass).State = EntityState.Modified;
                db.SaveChanges();
                _logger.Info("we search for the Plcae [ " + placeClass.placname + " ]");
                                return RedirectToAction("Index");
            }
            _logger.Error(" Place [ " + placeClass.placname + " ] NotFounded");
            return View(placeClass);
            }
            catch (Exception e)
            {
                _logger.Error("Error in editing the Place [ " + e.Message + " ]");
                throw;
            }
}

        // GET: Place/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceClass placeClass = db.PlaceClasses.Find(id);
            if (placeClass == null)
            {
                return HttpNotFound();
            }
            return View(placeClass);
        }

        // POST: Place/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaceClass placeClass = db.PlaceClasses.Find(id);
            db.PlaceClasses.Remove(placeClass);
            _logger.Info("we Removed Plcae [ " + placeClass.placname + " ]");
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _logger.Info("we Dispose Databse Contex and Close the Connection ");

                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

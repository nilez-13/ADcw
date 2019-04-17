using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementCourseWork.Models;

namespace StudentManagementCourseWork.Controllers
{
    [Authorize (Roles ="Admin")]
    public class FacultiesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Faculties
        public ActionResult Index()
        {
            return View(db.DbFaculty.ToList());
        }

        // GET: Faculties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.DbFaculty.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // GET: Faculties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyId,Name,Code,Description")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                // db.DbFaculty.Add(faculty);
                // db.SaveChanges();

                string Sql = "Insert into Faculties(Name, Code, Description) values(" + "'" + faculty.Name + "','" + faculty.Code + "','" + faculty.Description + "')";
                db.Create(Sql);

                return RedirectToAction("Index");
            }

            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.DbFaculty.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyId,Name,Code,Description")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(faculty).State = EntityState.Modified;
                //db.SaveChanges();

                string Sql = "Update Faculties Set Name='"+faculty.Name + "',Code='"+faculty.Code +"',Description='"+faculty.Description+"'where FacultyId="+faculty.FacultyId+";";
                db.Edit(Sql);

                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.DbFaculty.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = db.DbFaculty.Find(id);
            //db.DbFaculty.Remove(faculty);
            //db.SaveChanges();
            string Sql = "Delete from Faculties where FacultyId=" + faculty.FacultyId + ";";
            db.Delete(Sql);
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

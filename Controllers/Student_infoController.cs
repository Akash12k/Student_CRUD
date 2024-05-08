using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_CRUD.Models;

namespace Student_CRUD.Controllers
{
    public class Student_infoController : Controller
    {
        private StudentEntities4 db = new StudentEntities4();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, Address address, Subject subject)
        {
            if (ModelState.IsValid)
            {
                int newStudentID = (int)db.CreateStudent(student.S_Name, student.S_Age, address.S_Address, subject.Subject_opted).SingleOrDefault();

                return RedirectToAction("Index", new { id = newStudentID });
            }
            else
            {
                return View(student);
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student, Address address, Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.UpdateStudent(student.S_id, student.S_Name, student.S_Age, address.S_Address, subject.Subject_opted);

                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]        
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteStudent(id);

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

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
        public ActionResult Create([Bind(Include = "S_Name,S_Age")] Student student, [Bind(Prefix = "Address")] Address address, [Bind(Prefix = "Subject")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                student.Address = address;
                student.Subject = subject;

                db.Students.Add(student);
                db.SaveChanges();

                student = db.Students.Single(s => s.S_Name == student.S_Name && s.S_Age == student.S_Age);

                return RedirectToAction("Index", new { id = student.S_id });
            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {

                    }
                }

                return View(student);
            }
            return View(student);
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
        public ActionResult Edit([Bind(Include = "S_id,S_Name,S_Age")] Student student, [Bind(Prefix = "Address")] Address address, [Bind(Prefix = "Subject")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = db.Students.Find(student.S_id);
                var existingAddress = db.Addresses.FirstOrDefault(a => a.S_id == student.S_id); 
                var existingSubject = db.Subjects.FirstOrDefault(s => s.S_id == student.S_id);

                if (existingStudent != null)
                {
                    existingStudent.S_Name = student.S_Name;
                    existingStudent.S_Age = student.S_Age;
                }

                if (existingAddress != null)
                {
                    existingAddress.S_Address = address.S_Address;
                }

                if (existingSubject != null)
                {
                    existingSubject.Subject_opted = subject.Subject_opted;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(student);
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
            Student student = db.Students.Find(id);
            
            var address = student.Address;
            db.Addresses.Remove(address);

            var subject = student.Subject;
            db.Subjects.Remove(subject);
            db.Students.Remove(student);
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

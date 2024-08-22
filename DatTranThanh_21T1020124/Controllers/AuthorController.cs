using DatTranThanh_21T1020124.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Net;

namespace DatTranThanh_21T1020124.Controllers
{
    public class AuthorController : Controller
    {

        // Hiển thị danh sách tác giả
        public ActionResult Index()
        {
            return View(db.Authors.ToList());
        }

        // Hiển thị form thêm mới tác giả
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Authorld,Name,BirthDate")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // Hiển thị form chỉnh sửa thông tin tác giả
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Authorld,Name,BirthDate")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // Xóa tác giả và xử lý sách liên quan
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Include(a => a.Books).FirstOrDefault(a => a.Authorld == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Include(a => a.Books).FirstOrDefault(a => a.Authorld == id);
            if (author != null)
            {
                foreach (var book in author.Books.ToList())
                {
                    db.Books.Remove(book); 
                }

                db.Authors.Remove(author);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}

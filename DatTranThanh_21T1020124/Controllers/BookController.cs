using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Data.Entity;
using System.Net;

namespace DatTranThanh_21T1020124.Controllers
{
    public class BookController : Controller
    {

        // Hiển thị danh sách sách
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author);
            return View(books.ToList());
        }

        // Hiển thị form thêm sách mới
        public ActionResult Create()
        {
            ViewBag.Authorld = new SelectList(db.Authors, "Authorld", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bookld,Title,PublicationDate,PublishHouse,Authorld")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Authorld = new SelectList(db.Authors, "Authorld", "Name", book.Authorld);
            return View(book);
        }

        // Hiển thị form chỉnh sửa thông tin sách
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Authorld = new SelectList(db.Authors, "Authorld", "Name", book.Authorld);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bookld,Title,PublicationDate,PublishHouse,Authorld")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authorld = new SelectList(db.Authors, "Authorld", "Name", book.Authorld);
            return View(book);
        }

        // Xóa sách
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(b => b.Author).FirstOrDefault(b => b.Bookld == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult BooksByAuthor(int? authorId)
        {
            if (authorId == null)
            {
                return Book();
            }

            var books = db.Books.Where(b => b.Authorld == authorId).Include(b => b.Author).ToList();

            if (books == null || books.Count == 0)
            {
                return HttpNotFound("Không có sách nào cho tác giả này.");
            }

            ViewBag.Authors = new SelectList(db.Authors, "Authorld", "Name", authorId);
            return View(books);
        }

        private ActionResult HttpNotFound(string v)
        {
            throw new NotImplementedException();
        }

        private static HttpStatusCodeResult Book()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}

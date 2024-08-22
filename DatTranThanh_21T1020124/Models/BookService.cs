using global::Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatTranThanh_21T1020124.Models


{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService()
        {
            _context = new LibraryContext();
        }

        // Create
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        // Read
        public Book GetBook(int bookId, int authorId)
        {
            return _context.Books.SingleOrDefault(b => b.Bookld == bookId && b.Authorld == authorId);
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        // Update
        public void UpdateBook(Book book)
        {
            var existingBook = _context.Books.SingleOrDefault(b => b.Bookld == book.Bookld && b.Authorld == book.Authorld);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.PublicationDate = book.PublicationDate;
                existingBook.PublishHouse = book.PublishHouse;
                _context.SaveChanges();
            }
        }

        // Delete
        public void DeleteBook(int bookId, int authorId)
        {
            var book = _context.Books.SingleOrDefault(b => b.Bookld == bookId && b.Authorld == authorId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}


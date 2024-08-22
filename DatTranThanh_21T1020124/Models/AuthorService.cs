using global::Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DatTranThanh_21T1020124.Models

{
    public class AuthorService
    {
        private readonly LibraryContext _context;

        public AuthorService()
        {
            _context = new LibraryContext();
        }

        // Create
        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        // Read
        public Author GetAuthor(int id)
        {
            return _context.Authors.Find(id);
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        // Update
        public void UpdateAuthor(Author author)
        {
            var existingAuthor = _context.Authors.Find(author.Authorld);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
                existingAuthor.BirthDate = author.BirthDate;
                _context.SaveChanges();
            }
        }

        // Delete
        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}

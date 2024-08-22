using global::Models;
using System.Data.Entity;

namespace DatTranThanh_21T1020124.Models


{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryContext") 
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

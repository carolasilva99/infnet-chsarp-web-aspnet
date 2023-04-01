using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using AT.Models;
using Microsoft.EntityFrameworkCore;

namespace AT.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(p => p.Authors)
                .WithMany(p => p.Books)
                .UsingEntity<BookAuthor>(
                    j => j
                        .HasOne(pt => pt.Author)
                        .WithMany(t => t.BookAuthors)
                        .HasForeignKey(pt => pt.AuthorId),
                    j => j
                        .HasOne(pt => pt.Book)
                        .WithMany(p => p.BookAuthors)
                        .HasForeignKey(pt => pt.BookId),
                    j =>
                    {
                        j.HasKey(t => new { t.BookId, t.AuthorId });
                    });
        }
    }
}

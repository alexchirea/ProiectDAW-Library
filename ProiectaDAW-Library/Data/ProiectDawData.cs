using System;
using Microsoft.EntityFrameworkCore;
using ProiectaDAW_Library.Models;

namespace ProiectaDAW_Library.Data
{
    public class ProiectDawData: DbContext
    {
        public ProiectDawData(DbContextOptions<ProiectDawData> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<MemberCard >MemberCards { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // 1:n
            builder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author);
            builder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books);
            // 1:1
            builder.Entity<MemberCard>()
                .HasOne(u => u.User)
                .WithOne(m => m.MemberCard)
                .HasForeignKey<MemberCard>(m => m.UserId);
            // n:n
            builder.Entity<Activity>()
                .HasKey(act => new { act.BookId, act.UserId });
            builder.Entity<Activity>()
                .HasOne<Book>(act => act.Book)
                .WithMany(b => b.Activities)
                .HasForeignKey(act => act.BookId);
            builder.Entity<Activity>()
                .HasOne<User>(act => act.User)
                .WithMany(u => u.Activities)
                .HasForeignKey(act => act.UserId);
        }
    }
}

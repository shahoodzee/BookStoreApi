using BookStore.DAL.Model.Book;
using BookStore.DAL.Model.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookStore.Common.Dto.BookDtos;


namespace BookStore.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<long>>().HasNoKey();
            builder.Entity<IdentityUserRole<long>>().HasNoKey();
            builder.Entity<IdentityUserToken<long>>().HasNoKey();

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroups { get; set; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
    }
}

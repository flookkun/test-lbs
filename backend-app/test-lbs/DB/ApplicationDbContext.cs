using System;
using Microsoft.EntityFrameworkCore;

namespace test_lbs.DB
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users { Id = 1, username = "Change can" },
                new Users { Id = 2, username = "Blend 285" }
            );

            modelBuilder.Entity<PostDetail>().HasData(
                new PostDetail
                {
                    Id = 1,
                    comment = "have a good day",
                    createBy = 2, 
                    createDate = new DateTime(2021, 10, 16, 16, 0, 0)
                }
            );
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<WallPost> WallPost { get; set; }
        public DbSet<PostDetail> PostDetail { get; set; }
    }
}


using Microsoft.EntityFrameworkCore;
using System;
namespace quizartsocial_backend.Models
{
    public class efmodel : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments{get; set;}
        public DbSet<Post> Posts{get; set;}
        public DbSet<User> Users{get; set;}

      public efmodel(DbContextOptions<efmodel> options): base(options){
          this.Database.EnsureCreated();
      }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=QuizRTSocialDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Topic>().HasMany(n => n.posts).WithOne().HasForeignKey(c => c.TopicForeignKey);
            modelBuilder.Entity<Post>().HasMany(n=>n.comment_data).WithOne().HasForeignKey(c=> c.PostForeignKey);
            
            modelBuilder.Entity<User>().HasMany(n => n.posts).WithOne().HasForeignKey(c => c.UserForeignKey).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasMany(n=>n.comment_data).WithOne().HasForeignKey(c => c.UsercomForeignKey).OnDelete(DeleteBehavior.Restrict);



        } 
    }
}
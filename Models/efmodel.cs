using Microsoft.EntityFrameworkCore;
using System;
namespace quizartsocial_backend.Models
{
    public class efmodel : DbContext
    {
        public DbSet<TopicC> TopicT { get; set; }
        public DbSet<CommentC> CommentT{get; set;}
        public DbSet<PostC> PostT{get; set;}
        public DbSet<UserC> UserT{get; set;}


      public efmodel(DbContextOptions<efmodel> options): base(options){
          this.Database.EnsureCreated();
      }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ToDoNotes_5;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<TopicC>().HasMany(n => n.posts).WithOne().HasForeignKey(c => c.TopicForeignKey);
            modelBuilder.Entity<PostC>().HasMany(n=>n.comment_data).WithOne().HasForeignKey(c=> c.PostForeignKey);
            
            modelBuilder.Entity<UserC>().HasMany(n => n.posts).WithOne().HasForeignKey(c => c.UserForeignKey).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserC>().HasMany(n=>n.comment_data).WithOne().HasForeignKey(c => c.UsercomForeignKey).OnDelete(DeleteBehavior.Restrict);



        } 
    }
}
﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using quizartsocial_backend.Models;

namespace backEnd.Migrations
{
    [DbContext(typeof(efmodel))]
    partial class efmodelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("quizartsocial_backend.Models.category", b =>
                {
                    b.Property<int>("topic_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("topic_image");

                    b.Property<string>("topic_name");

                    b.HasKey("topic_id");

                    b.ToTable("category_table");
                });

            modelBuilder.Entity("quizartsocial_backend.Models.comments", b =>
                {
                    b.Property<int>("comment_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("comment");

                    b.Property<int>("post_id");

                    b.Property<int>("user_id");

                    b.HasKey("comment_id");

                    b.HasIndex("post_id");

                    b.HasIndex("user_id");

                    b.ToTable("comments_table");
                });

            modelBuilder.Entity("quizartsocial_backend.Models.post", b =>
                {
                    b.Property<int>("post_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("posts");

                    b.Property<int>("topic_id");

                    b.Property<int>("user_id");

                    b.HasKey("post_id");

                    b.HasIndex("topic_id");

                    b.HasIndex("user_id");

                    b.ToTable("post_table");
                });

            modelBuilder.Entity("quizartsocial_backend.Models.user", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("user_image");

                    b.Property<string>("user_name");

                    b.HasKey("user_id");

                    b.ToTable("user_table");
                });

            modelBuilder.Entity("quizartsocial_backend.Models.comments", b =>
                {
                    b.HasOne("quizartsocial_backend.Models.post")
                        .WithMany("comment_data")
                        .HasForeignKey("post_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("quizartsocial_backend.Models.user")
                        .WithMany("comment_data")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("quizartsocial_backend.Models.post", b =>
                {
                    b.HasOne("quizartsocial_backend.Models.category")
                        .WithMany("posts")
                        .HasForeignKey("topic_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("quizartsocial_backend.Models.user")
                        .WithMany("posts")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

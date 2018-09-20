﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int>("BookshelvesId");

                    b.Property<int>("NumPages");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("BookshelvesId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Repository.Model.Bookshelves", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Height");

                    b.Property<int>("Lane");

                    b.Property<int>("Rack");

                    b.HasKey("Id");

                    b.ToTable("Bookshelves");
                });

            modelBuilder.Entity("Repository.Model.Disk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookshelvesId");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("BookshelvesId");

                    b.ToTable("Disk");
                });

            modelBuilder.Entity("Repository.Model.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Artist");

                    b.Property<string>("Author");

                    b.Property<int>("DiskId");

                    b.Property<int>("Duration");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DiskId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("Repository.Model.Book", b =>
                {
                    b.HasOne("Repository.Model.Bookshelves", "Bookshelves")
                        .WithMany("Books")
                        .HasForeignKey("BookshelvesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Repository.Model.Disk", b =>
                {
                    b.HasOne("Repository.Model.Bookshelves", "Bookshelves")
                        .WithMany("Disks")
                        .HasForeignKey("BookshelvesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Repository.Model.Song", b =>
                {
                    b.HasOne("Repository.Model.Disk", "Disk")
                        .WithMany("Songs")
                        .HasForeignKey("DiskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

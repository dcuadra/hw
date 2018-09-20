using Microsoft.EntityFrameworkCore;
using Repository.Model;
using System;

namespace Repository
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }
        public MyContext()
        {

        }
        string connection;
        public MyContext(string connection)
        {
            this.connection = connection;
        }

        public static void Configure(DbContextOptionsBuilder optionsBuilder, string connection = null)
        {
            if (connection == null)
                connection = Utilities.Configuration.Config.BD;
            Console.WriteLine($@"Connected to {connection}.");
            optionsBuilder
                .UseSqlServer(connection,
                x => x.MigrationsHistoryTable("__Migration")
                    .CommandTimeout(60));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Configure(optionsBuilder, connection);
            }
        }

        public DbSet<Bookshelves> Bookshelves { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<Song> Songs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

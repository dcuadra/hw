using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Repository.Model;
using Services;
using Services.Model;
using System;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public DbContextOptions<MyContext> CreateContext(Action<MyContext> action)
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(databaseName: "tempBD").Options;
            using (var context = new MyContext(options))
            {
                context.Add(new Bookshelves
                {
                    Height = 1,
                    Lane = 1,
                    Rack = 1
                });
                context.SaveChanges();
                action(context);
            }
            return options;
        }
        [TestMethod]
        public void TestInsertBook1()
        {
            var option = CreateContext(context =>
            {
                var service = new LibraryService(context);
                service.SaveBook(new BookModel
                {
                    Author = "Diego de la Cuadra",
                    BookshelvesId = context.Bookshelves.FirstOrDefault().Id,
                    NumPages = 200,
                    Title = "The test",
                    Year = 2018
                });
            });
            using (var context = new MyContext(option))
            {
                if (context.Books.Count() != 1) Assert.Fail("There only shoud be 1 book");
                var book = context.Books.FirstOrDefault();
                if (book.Author != "Diego de la Cuadra") Assert.Fail("The author is wrong");
                if (book.BookshelvesId != context.Bookshelves.FirstOrDefault().Id) Assert.Fail("The bookshelves is wrong");
                if (book.NumPages != 200) Assert.Fail("The number of pages are wrong");
                if (book.Year != 2018) Assert.Fail("The year is wrong");
            }
        }
        [TestMethod]
        public void TestModifyBook1()
        {
            var option = CreateContext(context =>
            {
                context.Add(new Book
                {
                    Author = "Diego de la Cuadra",
                    BookshelvesId = context.Bookshelves.FirstOrDefault().Id,
                    NumPages = 200,
                    Title = "The test",
                    Year = 2018
                });
                context.SaveChanges();
            });
            using (var context = new MyContext(option))
            {
                var service = new LibraryService(context);
                service.SaveBook(new BookModel
                {
                    Id = context.Books.FirstOrDefault().Id,
                    Author = "Diego de la Cuadra2",
                    BookshelvesId = context.Bookshelves.FirstOrDefault().Id,
                    NumPages = 201,
                    Title = "The test2",
                    Year = 2019
                });
            }
            using (var contextExit = new MyContext(option))
            {
                if (contextExit.Books.Count() != 1) Assert.Fail("There only shoud be 1 book");
                var book = contextExit.Books.FirstOrDefault();
                if (book.Author != "Diego de la Cuadra2") Assert.Fail("The author is wrong");
                if (book.NumPages != 201) Assert.Fail("The number of pages are wrong");
                if (book.Year != 2019) Assert.Fail("The year is wrong");
            }
        }
        [TestMethod]
        public void TestReadBook()
        {
            var option = CreateContext(context =>
            {
                context.Add(new Book
                {
                    Author = "Diego de la Cuadra",
                    BookshelvesId = context.Bookshelves.FirstOrDefault().Id,
                    NumPages = 200,
                    Title = "The test",
                    Year = 2018
                });
                context.SaveChanges();
            });
            using (var context = new MyContext(option))
            {
                var service = new LibraryService(context);
                var book = service.LoadBook(context.Books.FirstOrDefault().Id);
                if (book.Author != "Diego de la Cuadra") Assert.Fail("The author is wrong");
                if (book.BookshelvesId != context.Bookshelves.FirstOrDefault().Id) Assert.Fail("The bookshelves is wrong");
                if (book.NumPages != 200) Assert.Fail("The number of pages are wrong");
                if (book.Year != 2018) Assert.Fail("The year is wrong");
            }
        }
        [TestMethod]
        public void TestRemoveBook()
        {
            var option = CreateContext(context =>
            {
                context.Add(new Book
                {
                    Author = "Diego de la Cuadra",
                    BookshelvesId = context.Bookshelves.FirstOrDefault().Id,
                    NumPages = 200,
                    Title = "The test",
                    Year = 2018
                });
                context.SaveChanges();
            });
            using (var context = new MyContext(option))
            {
                var service = new LibraryService(context);
                service.RemoveBook(context.Books.FirstOrDefault().Id);
            }
            using (var context = new MyContext(option))
            {
                if (context.Books.Any()) Assert.Fail("There sould not be any book");
            }
        }
    }
}

using Repository;
using Repository.Model;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class LibraryService : ILibraryService
    {
        private readonly MyContext context;

        public LibraryService(MyContext context)
        {
            this.context = context;
        }
        public void SaveBook(BookModel model)
        {
            var book = (model.Id > 0 ?
                context.Books.FirstOrDefault(f => f.Id == model.Id) :
                context.Add(new Book()).Entity);
            book.Title = model.Title;
            book.Author = model.Author;
            book.Year = model.Year;
            book.NumPages = model.NumPages;
            book.BookshelvesId = model.BookshelvesId;
            context.SaveChanges();
        }
        public BookModel LoadBook(int id)
        {
            return context.Books.Where(b => b.Id == id)
                .Select(b => new BookModel
                {
                    Id=b.Id,
                    Title=b.Title,
                    Author=b.Author,
                    Year=b.Year,
                    NumPages=b.NumPages,
                    BookshelvesId=b.BookshelvesId
                }).FirstOrDefault();
        }
        public List<BookModel> LoadBooks()
        {
            return context.Books
                .Select(b => new BookModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Year = b.Year,
                    NumPages = b.NumPages,
                    BookshelvesId = b.BookshelvesId
                }).ToList();
        }
        public void RemoveBook(int id)
        {
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            context.Books.Remove(book);
            context.SaveChanges();
        }
    }
}

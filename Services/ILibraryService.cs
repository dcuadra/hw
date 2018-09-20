using System.Collections.Generic;
using Services.Model;

namespace Services
{
    public interface ILibraryService
    {
        BookModel LoadBook(int id);
        List<BookModel> LoadBooks();
        void RemoveBook(int id);
        void SaveBook(BookModel model);
    }
}
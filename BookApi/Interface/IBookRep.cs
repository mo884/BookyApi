using BookApi.Models;

namespace BookApi.Interface
{
    public interface IBookRep
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetByID(int id);
        Task<Book> Edit(int id,Book book);
        Task Delete(int id);
        Task Create(Book book);
    }
}

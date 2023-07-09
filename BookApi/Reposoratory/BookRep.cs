using BookApi.Database;
using BookApi.Interface;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Reposoratory
{
    public class BookRep :IBookRep
    {
        private readonly ApplicationDbContext Db;
        public BookRep(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public async Task Create(Book book)
        {
            await Db.Books.AddAsync(book);
            await Db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await Db.Books.Where(a => a.ID == id).Include("Auther").Include("department").FirstOrDefaultAsync();

            data.Deleted = !data.Deleted;
            await Db.SaveChangesAsync();


        }

        public async Task<Book> Edit(int id, Book book)
        {
            var data = await Db.Books.Where(a => a.ID == id).Include("Auther").Include("department").FirstOrDefaultAsync();
            if (data != null)
            {
                data.Title= book.Title;
                data.Description = book.Description;
                data.Price = book.Price;
                await Db.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await Db.Books.Include("Auther").Include("department").ToListAsync();
        }

        public async Task<Book> GetByID(int id)
        {
            return await Db.Books.Where(a => a.ID == id).Include("Auther").Include("department").FirstOrDefaultAsync();
        }
    }
}

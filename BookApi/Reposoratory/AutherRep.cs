using BookApi.Database;
using BookApi.Interface;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Reposoratory
{
    public class AutherRep : IAutherRep
    {
        private readonly ApplicationDbContext Db;
        public AutherRep(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public async Task Create(Auther auther)
        {
           await Db.Authers.AddAsync(auther);
           await Db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await Db.Authers.Where(a => a.ID == id).FirstOrDefaultAsync();
            Db.Authers.Remove(data);
            await Db.SaveChangesAsync();
        }

        public async Task Edit(int id,Auther auther)
        {
            var data = await Db.Authers.Where(a => a.ID == id).FirstOrDefaultAsync();
            data.Name = auther.Name;
            data.Address = auther.Address;
            await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Auther>> GetAll()
        {
            return await Db.Authers.ToListAsync();
        }

        public async Task<Auther> GetByID(int id)
        {
            return await Db.Authers.Where(a => a.ID == id).FirstOrDefaultAsync();
        }
    }
}

using BookApi.Database;
using BookApi.Interface;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Reposoratory
{
    public class DepartmentRep:IDepartmentRep
    {
        private readonly ApplicationDbContext Db;
        public DepartmentRep(ApplicationDbContext Db)
        {
            this.Db = Db;
        }
        public async Task Create(Department department)
        {
            await Db.Departments.AddAsync(department);
            await Db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await Db.Departments.Where(a => a.ID == id).Include("books").FirstOrDefaultAsync();

            data.ISDeleted = !data.ISDeleted;
            await Db.SaveChangesAsync();


        }

        public async Task<Department> Edit(int id, Department department)
        {
            var data = await Db.Departments.Where(a => a.ID == id).Include("books").FirstOrDefaultAsync();
            if (data != null)
            {
                data.Name = department.Name;
              
                await Db.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await Db.Departments.ToListAsync();
        }

        public async Task<Department> GetByID(int id)
        {
            return await Db.Departments.Where(a => a.ID == id).Include("books").FirstOrDefaultAsync();
        }
    }
}

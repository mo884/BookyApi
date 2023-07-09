using BookApi.Models;

namespace BookApi.Interface
{
    public interface IDepartmentRep
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetByID(int id);
        Task<Department> Edit(int id, Department department);
        Task Delete(int id);
        Task Create(Department department);
    }
}

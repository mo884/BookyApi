using BookApi.Models;

namespace BookApi.Interface
{
    public interface IAutherRep
    {
        Task<IEnumerable<Auther>> GetAll();
        Task<Auther> GetByID(int id);
        Task Edit(int id,Auther auther);
        Task  Delete(int id);
        Task Create(Auther auther);
    }
}

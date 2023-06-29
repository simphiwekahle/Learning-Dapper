using Data.Layer.Models.Domain;


namespace Data.Layer.Repo
{
    public interface IPersonRepo
    {
        Task<bool> AddAsync(Person person);
        Task<bool> UpdateAsync(Person person);
        Task<bool> DeleteAsync(int id);
        Task<Person?> GetByIdAsync(int id);
        Task<IEnumerable<Person>> GetAllAsync();
    }
}

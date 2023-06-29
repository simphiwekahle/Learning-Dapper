using Data.Layer.DA;
using Data.Layer.Models.Domain;


namespace Data.Layer.Repo

{
    public class PersonRepo : IPersonRepo
    {
        private readonly ISqlDA _db;

        public PersonRepo(ISqlDA db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Person person) //Save
        {
            try
            {
                await _db.SaveData("create_person",
                    new
                    {
                        person.name,
                        person.email,
                        person.address
                    });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Person person) //Save
        {
            try
            {
                await _db.SaveData("update_person", person);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id) //Save
        {
            try
            {
                await _db.SaveData("delete_person",
                    new
                    {
                        Id = id
                    });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Person?> GetByIdAsync(int id) //Get
        {
            IEnumerable<Person> result = await _db.GetData<Person, dynamic>
                ("get_person",
                new
                {
                    Id = id
                });
            return result.FirstOrDefault();
        } 

        public async Task<IEnumerable<Person>> GetAllAsync() //Get
        {
            return await _db.GetData<Person, dynamic>
                ("get_people", new { });
        }
    }
}

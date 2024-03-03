
using StorePhones.DAL;
using StorePhones.DAL.Entities;
using StorePhones.DAL.Repositories;

namespace StorePhones.BLL.Services
{
    public class ManagmentPhones
    {
        private PhonesRepository phonesRepository;
        private DataContextADO _context;

        public ManagmentPhones(string connectionString)
        {
            _context = new DataContextADO(connectionString);
            phonesRepository = new PhonesRepository(_context);
        }

        public async Task AddPhone(Phone phone)
        {
            await phonesRepository.AddAsync(phone);
        }

        public async Task<IEnumerable<Phone>> GetPhones()
        {
            return await phonesRepository.GetAllAsync();
        }

        public async Task<Phone> GetPhone(int id)
        {
            return await phonesRepository.GetAsync(id);
        }

        public async Task UpdatePhone(Phone phone)
        {
            await phonesRepository.UpdateAsync(phone);
        }

        public async Task DeletePhone(int id)
        {
            await phonesRepository.DeleteAsync(id);
        }
    }
}

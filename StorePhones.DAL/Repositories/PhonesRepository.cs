
using Microsoft.Data.SqlClient;
using StorePhones.DAL.Entities;
using StorePhones.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StorePhones.DAL.Repositories
{
    public class PhonesRepository : IRepository<Phone>
    {
        private DataContextADO _context;
        public PhonesRepository(DataContextADO context)
        {
            _context = context;
        }
        public async Task AddAsync(Phone phone)
        {
            using (var db = _context.CreateConnection())
            {
                db.Open();
                var cmd = new SqlCommand(@"INSERT Phones(Name, Descriptionn, Price) 
                                           VALUES(Name=@Name, Description=@Description, Price=@Price);", db);
                var parName = new SqlParameter("@Name",phone.Name);
                cmd.Parameters.Add(parName);
                var parDesc = new SqlParameter("@Description", phone.Description);
                cmd.Parameters.Add(parDesc);
                var parPrice = new SqlParameter("@Price", phone.Price);
                cmd.Parameters.Add(parPrice);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var db = _context.CreateConnection())
            {
                db.Open();
                var cmd = new SqlCommand("DELETE FROM Phones WHERE Id=@Id", db);
                var parId = new SqlParameter("@Id", id);
                cmd.Parameters.Add(parId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<Phone>> GetAllAsync()
        {
            var phones = new List<Phone>();
            using (var db = _context.CreateConnection())
            {
                db.Open();
                var cmd = new SqlCommand("SELECT *FROM Phones",db);
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                if (rdr.HasRows)
                {
                    while (await rdr.ReadAsync())
                    {
                        phones.Add(new Phone()
                        {
                            Id = Convert.ToInt32(rdr["Id"].ToString()),
                            Name = rdr["Name"].ToString(),
                            Description = rdr["Description"].ToString(),
                            Price = Convert.ToDecimal(rdr["Price"].ToString())
                        });
                    }
                }
            }
                return phones;
        }

        public async Task<Phone> GetAsync(int id)
        {
            var phone = new Phone();
            using (var db = _context.CreateConnection())
            {
                db.Open();
                var cmd = new SqlCommand("SELECT * FROM Phones WHERE Id=@Id",db);
                var parId = new SqlParameter("@Id", id);
                cmd.Parameters.Add(parId);
                await cmd.ExecuteNonQueryAsync();

                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                if (rdr.HasRows)
                {
                    await rdr.ReadAsync();
                    phone.Id = Convert.ToInt32(rdr["Id"].ToString());
                    phone.Name = rdr["Name"].ToString();
                    phone.Description = rdr["Description"].ToString();
                    phone.Price = Convert.ToDecimal(rdr["Price"].ToString());
                }
            }
                return phone;
        }

        public async Task UpdateAsync(Phone phone)
        {
            using (var db = _context.CreateConnection())
            {
                db.Open();
                var cmd = new SqlCommand("UPDATE Phones SET Name=@Name, Description=@Description, Price=@Price WHERE Id=@Id", db);
                var parId = new SqlParameter("@Id", phone.Id);
                cmd.Parameters.Add(parId);
                var parName = new SqlParameter("@Name", phone.Name);
                cmd.Parameters.Add(parName);
                var parDesc = new SqlParameter("@Description", phone.Description);
                cmd.Parameters.Add(parDesc);
                var parPrice = new SqlParameter("@Price", phone.Price);
                cmd.Parameters.Add(parPrice);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}

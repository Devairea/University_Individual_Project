using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Yoga_App_V1.Models;

namespace Yoga_App_V1.Services
{
    public class DBAccess
    {
        private readonly SQLiteAsyncConnection _database;

        public DBAccess()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _database.CreateTableAsync<User>();
        }

        public Task<User> LoginUser(string email, string password)
        {
            if (email == "" || password == "")
                return null;
            return _database.Table<User>().Where(i => i.Email == email && i.Password == password).FirstOrDefaultAsync();
        }

        public async Task<bool> RegisterUser(User newUser)
        {
            if (await _database.Table<User>().Where(i => i.Email == newUser.Email).CountAsync() > 0)
            {
                return false;
            }
            try
            {
                return await _database.InsertAsync(newUser) > 0;
            }
            catch
            {
                return false;
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        public Task<int> UpdateUserAsync(User user)
        {
            return _database.UpdateAsync(user);
        }

        public Task<User> GetUser(string email)
        {
            return _database.Table<User>().Where(i => i.Email == email).FirstOrDefaultAsync();
        }
    }
}

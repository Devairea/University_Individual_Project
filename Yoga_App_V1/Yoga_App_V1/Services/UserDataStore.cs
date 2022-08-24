using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga_App_V1.Models;

namespace Yoga_App_V1.Services
{
    public class UserDataStore : IDataStore<User>
    {
        private readonly List<User> users;

        public UserDataStore()
        {
            users = new List<User>();
        }
        public async Task<bool> AddItemAsync(User user)
        {
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldUser = users.Where((User arg) => arg.Email == id).FirstOrDefault();
            users.Remove(oldUser);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Email == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }

        public async Task<bool> UpdateItemAsync(User user)
        {
            var oldUser = users.Where((User arg) => arg.Email == user.Email).FirstOrDefault();
            users.Remove(oldUser);
            users.Add(user);

            return await Task.FromResult(true);
        }
    }
}

using LibaryMng.Entities;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


namespace LibaryMng.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _dataFilePath = "Data/users.json";
        public async Task<User> getUser(string userName, string password)
        {
            string textFromJson = File.ReadAllText(_dataFilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(textFromJson);
            
            foreach (var user in users)
            {
                if (user.UserName == userName && user.Password == password)
                    return await Task.FromResult(user);
            }
            return await Task.FromResult<User>(null);

        }
    }
}

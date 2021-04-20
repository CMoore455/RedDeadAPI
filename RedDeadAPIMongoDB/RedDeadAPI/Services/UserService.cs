using MongoDB.Driver;
using RedDeadAPI.Interfaces;
using RedDeadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedDeadAPI.Services
{
	public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IRedDeadAPIDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }


        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.AsQueryable().ToList().SingleOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _users.AsQueryable().ToList().WithoutPasswords());
        }
    }
}

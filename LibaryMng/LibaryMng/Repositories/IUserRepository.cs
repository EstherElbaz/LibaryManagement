using LibaryMng.Entities;

namespace LibaryMng.Repositories
{
    public interface IUserRepository
    {
        public Task<User> getUser(string password, string userName);

    }
}

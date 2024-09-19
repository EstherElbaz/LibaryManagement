using LibaryMng.Entities;

namespace LibaryMng.Services
{
    public interface IUserService
    {
        public Task<User> getUser(string userName, string password);

    }
}

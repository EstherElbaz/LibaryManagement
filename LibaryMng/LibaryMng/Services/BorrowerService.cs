using LibaryMng.Entities;
using LibaryMng.Repositories;

namespace LibaryMng.Services
{
    public class BorrowerService : IBorrowerService
    {
        private ILibaryRepository _libaryRepository;
        public BorrowerService(ILibaryRepository LibaryRepository)
        {
            _libaryRepository = LibaryRepository;
        }
      
    }
}

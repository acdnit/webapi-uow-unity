using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebAPI_UOW.Models.Ef;
using WebAPI_UOW.Models.Repository;

namespace WebAPI_UOW.Models.Services {
    public class PersonService : IPersonService {
        private readonly IApiUnitOfWork _unitOfWork;

        public PersonService(IApiUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Person>> GetListPersion() {
            return await _unitOfWork.GetRepository<Person>().All().ToListAsync();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_UOW.Models.Ef;

namespace WebAPI_UOW.Models.Services {
    public interface IPersonService {
        Task<List<Person>> GetListPersion();
    }
}
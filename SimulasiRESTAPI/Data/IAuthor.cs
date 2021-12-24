using SimulasiRESTAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulasiRESTAPI.Data
{
    public interface IAuthor : ICrud<Author>
    {
        Task<IEnumerable<Author>> GetByName(string FirstName);
    }
}

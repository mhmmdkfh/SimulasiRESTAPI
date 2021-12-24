using SimulasiRESTAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulasiRESTAPI.Data
{
    public interface ICourse : ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByTitle(string title);
        Task<IEnumerable<Course>> GetTitleByAuthor(string id);
    }
}

using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IuserBL
    {
        Task<User> Get(string email, int password);
        Task<User> Post(User user);
        Task<User> Put(User user, int id);
    }
}
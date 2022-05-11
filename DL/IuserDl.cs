using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IuserDl
    {
        Task<User> Get(string email, int password);
        Task<User> Post(User user);
        Task<User> Put(User user, int id);
    }
}
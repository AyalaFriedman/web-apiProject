using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IOrederBL
    {
        Task<Order> Post(Order order);
    }
}
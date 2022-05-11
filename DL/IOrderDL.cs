using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrderDL
    {
        Task<Order> Post(Order order);
    }
}
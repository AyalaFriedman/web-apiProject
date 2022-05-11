using DL;
using Entities;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BL
{
    public class OrederBL : IOrederBL
    {
        IOrderDL IOrderDL;
        IProductDL IproductDL;
        ILogger ILogger;

        public OrederBL(IOrderDL IOrderDL, IProductDL IproductDL, ILogger<OrederBL> ILogger)
        {
            this.IOrderDL = IOrderDL;
            this.IproductDL = IproductDL;
            this.ILogger= ILogger;
        }
        public async Task<Order> Post(Order order)
        {

            double sum = 0;
            foreach (OrderItem orderItem in order.OrderItems)
            {
                Product p = await IproductDL.getProductById(orderItem.ProductId);
                sum += (double)(p.Price * orderItem.Quantity);
            }

            if (sum != order.OrderSum)
            {
                order.OrderSum = (int)sum;
                ILogger.LogInformation("------user " + order.UserId + "try to change the sum order------");
            }
            return await IOrderDL.Post(order);
        }
    }
}

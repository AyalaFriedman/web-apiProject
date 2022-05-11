using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{


    public class OrderDL : IOrderDL
    {
        Production_aaContext Production_aaContext;
        public OrderDL(Production_aaContext Production_aaContext)
        {
            this.Production_aaContext = Production_aaContext;
        }

        public async Task<Order> Post(Order order)
        {
            await Production_aaContext.Orders.AddAsync(order);
            await Production_aaContext.SaveChangesAsync();
            return order;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum OrderStatus
    {
        New, 
        Checkout, 
        Pending,
        Paid, 
        Failed, 
        Shipped, 
        Delivered, 
        Returned,
        Complete
    }
}

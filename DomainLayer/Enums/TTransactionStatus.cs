using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enums
{
    public enum TTransactionStatus
    {
        New, 
        Cancelled, 
        Failed, 
        Pending, 
        Declined, 
        Rejected,
        Success
    }
}

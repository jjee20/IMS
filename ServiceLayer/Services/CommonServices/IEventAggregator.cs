using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CommonServices
{
    public interface IEventAggregator
    {
        void Subscribe<TEvent>(Action handler);
        void Unsubscribe<TEvent>(Action handler);
        void Publish<TEvent>();
    }
}

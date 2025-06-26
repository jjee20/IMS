using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.CommonServices
{
    public class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<Delegate>> _subscriptions = new();

        public void Subscribe<TEvent>(Action handler)
        {
            var eventType = typeof(TEvent);
            if (!_subscriptions.ContainsKey(eventType))
                _subscriptions[eventType] = new List<Delegate>();

            _subscriptions[eventType].Add(handler);
        }

        public void Unsubscribe<TEvent>(Action handler)
        {
            var eventType = typeof(TEvent);
            if (_subscriptions.ContainsKey(eventType))
            {
                _subscriptions[eventType].Remove(handler);
            }
        }

        public void Publish<TEvent>()
        {
            var eventType = typeof(TEvent);
            if (_subscriptions.ContainsKey(eventType))
            {
                foreach (var handler in _subscriptions[eventType].OfType<Action>())
                {
                    handler();
                }
            }
        }
    }

}

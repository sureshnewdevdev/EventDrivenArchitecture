namespace EventDrivenArchitecture.Services
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Action<object>>> _handlers = new();

        public void Publish<TEvent>(TEvent @event)
        {
            var eventType = typeof(TEvent);

            if (_handlers.ContainsKey(eventType))
            {
                foreach (var handler in _handlers[eventType])
                {
                    handler.Invoke(@event);
                }
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
            var eventType = typeof(TEvent);

            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<Action<object>>();
            }

            _handlers[eventType].Add(e => handler((TEvent)e));
        }
    }

}

using EventDrivenArchitecture.Model;

namespace EventDrivenArchitecture.Services
{
    public class OrderService
    {
        private readonly IEventBus _eventBus;

        public OrderService(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void CreateOrder(Guid orderId, string productName, int quantity)
        {
            // Logic to create order...

            // Publish the OrderCreated event
            var orderCreatedEvent = new OrderCreatedEvent
            {
                OrderId = orderId,
                ProductName = productName,
                Quantity = quantity
            };

            _eventBus.Publish(orderCreatedEvent);
        }
    }

}

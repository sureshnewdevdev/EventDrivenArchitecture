using EventDrivenArchitecture.Model;

namespace EventDrivenArchitecture.Services
{
    public class NotificationService
    {
        public NotificationService(IEventBus eventBus)
        {
            eventBus.Subscribe<OrderCreatedEvent>(HandleOrderCreated);
        }

        private void HandleOrderCreated(OrderCreatedEvent orderCreatedEvent)
        {
            // Logic to send notification
            Console.WriteLine($"Notification sent for OrderId: {orderCreatedEvent.OrderId}");
        }
    }

}

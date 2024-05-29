using Didar.Services.Notification.Domain.Entities.Common;
using Didar.Services.Notification.Domain.Events;

namespace Didar.Services.Notification.Domain.Entities;

public class OrderEntity(Guid orderId, string orderName) : BaseEntity
{
    public Guid OrderId { get; private set; } = orderId;

    public string OrderName { get; private set; } = orderName;

    public static OrderEntity Create(Guid orderId, string orderName)
    {
        var order = new OrderEntity(orderId, orderName);
        //order.RaiseEvent(new OrderCreatedEvent(orderId));
        //ToDo: give phone number 
        order.RaiseEvent(new SendCreatedOrderSmsEvent("PhoneNuber", "Congrats!. Your Order Placed Successfully"));

        return order;
    }
}

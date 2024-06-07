using Didar.Services.Notification.Domain.Entities.Common;
using Didar.Services.Notification.Domain.Events;

namespace Didar.Services.Notification.Domain.Entities;

public class OrderEntity() : BaseEntity
{
    public string OrderName { get; private set; } 
    public long UserId { get; private set; }
    public long ProductId { get; private set; }
    public UserEntity User { get; private set; }
    public ProductEntity Product { get; private set; }
    public OrderStates OrderState { get; private set; }

    public static OrderEntity Create(long userId,long productId)
    {
        var order = new OrderEntity()
        {
            UserId=userId,
            ProductId=productId,
            CreateDate=DateTime.Now,
            OrderState=OrderStates.Created,
        };

        //order.RaiseEvent(new OrderCreatedEvent(orderId));
        //ToDo: give phone number 
        order.RaiseEvent(new SendCreatedOrderSmsEvent("PhoneNuber", "Congrats!. Your Order Placed Successfully"));

        return order;
    }
    public enum OrderStates
    {
        Created,
        Paid,
        Processing,
        Completed
    }
}

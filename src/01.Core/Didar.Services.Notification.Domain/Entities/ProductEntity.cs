using Didar.Services.Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Didar.Services.Notification.Domain.Entities;

public class ProductEntity:BaseEntity
{
    public string ProductName { get; private set; }
    public decimal ProductPrice { get; private set; }
    public int AvailableAmount { get; private set; }
    public List<OrderEntity> RelatedOrders { get; private set; }

    private ProductEntity()
    {
        
    }

    public ProductEntity Create(string productName, int availableAmount, decimal productPrice)
    {
        var product = new ProductEntity()
        {
            AvailableAmount = availableAmount,
            ProductName = productName,
            ProductPrice = productPrice,
        };

        return product;
    }
    public void DecreaseAvailableProducts()
    {
        this.AvailableAmount--;
    }
}

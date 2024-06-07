using Carter;
using Didar.Services.Notification.Domain.Entities;
using Didar.Services.Notification.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Didar.Services.Notification.WebApi.Endpoints;

public record CreateUserOrderApiModel(long UserId,long ProductId);
public class CreateUserOrderEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/CreateUserOrder", async (CreateUserOrderApiModel apiModel, ApplicationDbContext db) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(c => c.Id.Equals(apiModel.UserId));

            if (user is null)
                return Results.NotFound(new
                {
                    ErrorMessage = "specified user not found"
                });

            var product = await db.Products.FirstOrDefaultAsync(c => c.Id.Equals(apiModel.ProductId));

            if (product is null)
                return Results.NotFound(new
                {
                    ErrorMessage = "specified product not found"
                });

            var order = OrderEntity.Create(user.Id, product.Id);
            db.Orders.Add(order);
            await db.SaveChangesAsync();

            return Results.Created();
        }).WithName("CreateUserOrder")
        .WithOpenApi(); 
    }
}

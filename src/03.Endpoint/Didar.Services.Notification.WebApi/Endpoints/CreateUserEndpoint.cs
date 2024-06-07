using Carter;
using Didar.Services.Notification.Domain.Entities;
using Didar.Services.Notification.Persistance;

namespace Didar.Services.Notification.WebApi.Endpoints;

public record CreateUserApiModel(string UserName, string PhoneNumber, string EmailAddress);

public class CreateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/CreateUser", async (CreateUserApiModel apiModel, ApplicationDbContext db) =>
        {
            var user = UserEntity.Create(apiModel.UserName, apiModel.PhoneNumber, apiModel.EmailAddress);

            db.Users.Add(user);

            await db.SaveChangesAsync();

            return TypedResults.Created();
        }).WithName("CreateUser")
          .WithOpenApi();
    }
}


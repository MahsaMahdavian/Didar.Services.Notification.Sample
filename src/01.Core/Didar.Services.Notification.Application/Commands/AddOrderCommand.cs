using MediatR;

namespace Didar.Services.Notification.Application.Commands;

public record AddOrderCommand(string OrderName) : IRequest;

using Customer.Application.Common.Interfaces;
using MassTransit;

namespace Customer.Infrastructure.Messaging;

public sealed class RabbitMqMessagePublisher
    : IMessagePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;


    public RabbitMqMessagePublisher(
        IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }


public async Task PublishAsync<T>(
    T message,
    CancellationToken cancellationToken = default)
    where T : class
    {
        await _publishEndpoint.Publish(
            message,
            cancellationToken);
    }
}
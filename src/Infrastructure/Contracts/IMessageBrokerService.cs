namespace Infrastructure.Contracts
{
    public interface IMessageBrokerService
    {
        Task PublishAsync(object data, CancellationToken cancellationToken);
    }
}
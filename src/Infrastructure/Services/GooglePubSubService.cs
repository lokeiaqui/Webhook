using Google.Cloud.PubSub.V1;
using Infrastructure.Contracts;
using Infrastructure.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class GooglePubSubService(IOptions<MessageBrokerSettings> _messageBrokerSettings) : IMessageBrokerService
    {
        public async Task PublishAsync(object data, CancellationToken cancellationToken)
        {
            TopicName topicName = TopicName.FromProjectTopic(_messageBrokerSettings.Value.ProjectId, _messageBrokerSettings.Value.TopicName);
            PublisherClient publisher = await PublisherClient.CreateAsync(topicName);
            
            await publisher.PublishAsync(JsonSerializer.Serialize(data), System.Text.Encoding.UTF8);
        }
    }
}
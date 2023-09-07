using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Data.Common;
using System.Text;

namespace Mango.MessageService
{
    public class MessageBus : IMessageBus
    {
        private string connectionString = "Endpoint=sb://shopingstore.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=r5l2C62cHvcvbYi3L/W4BOv5D/4xi3HNp+ASbHUWU5Q=";
        public async Task PublishMessage(object message, string topic_queue_Name)
        {
            await using var client= new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topic_queue_Name);

            var jsonMessage = JsonConvert.SerializeObject(message);

            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding
                 .UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(finalMessage);
            await client.DisposeAsync();
        }
    }
}

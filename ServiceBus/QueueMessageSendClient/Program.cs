using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.ServiceBus;

namespace QueueMessageSendClient
{
    class Program
    {
        const string ServiceBusConnectionString = "Endpoint=sb://azdir-bus1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=IWYKvScQKdFf/6vdF7LhkEK7armVunxXr7SSNNOLjag=";
        const string QueueName = "messages";
        static IQueueClient queueClient;
        static int numberOfMessages = 10;

        static async Task Main(string[] args)
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName, ReceiveMode.PeekLock);

            Console.WriteLine("Sending messages to queue...");
            await SendMessagesAsync(numberOfMessages);

            Console.WriteLine("Messages sent, proceeding to close connection to queue...");
            await queueClient.CloseAsync();

            Console.WriteLine("THE END");
        }

        static async Task SendMessagesAsync(int count)
        {
            try
            {
                List<Message> listOfMessages = new List<Message>(count);

                for (int i = 0; i < count; i++)
                {
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    listOfMessages.Add(message);
                }

                Console.WriteLine("Messages ready to send, sending now...");
                // A list of messages is supplied to SendAsync resulting in a single call
                // to send a batch of messages to the queue.
                // Individual messages can be sent too by passing in just a single message
                // and calling this function within the for loop.
                await queueClient.SendAsync(listOfMessages);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} :: Error - {ex.Message}");
            }
        }
    }
}

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
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            

            Console.WriteLine("THE END");
        }
    }
}

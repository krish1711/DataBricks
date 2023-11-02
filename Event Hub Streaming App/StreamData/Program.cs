namespace MyNamespace
{
    namespace SampleSender
    {
        using System;
        using System.IO;
        using System.Text;
        using System.Threading.Tasks;
        using Microsoft.Azure.EventHubs;

        public class Program
        {
            private static EventHubClient eventHubClient;


            private const string EventHubConnectionString = "Replace with your Event Hub connection string key";
            private const string EventHubName = "Replace with your Event Hub name";

            public static void Main(string[] args)
            {
                MainAsync(args).GetAwaiter().GetResult();
            }

            private static async Task MainAsync(string[] args)
            {
                // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
                // Typically, the connection string should have the entity path in it, but for the sake of this simple scenario
                // we are using the connection string from the namespace.
                var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
                {
                    EntityPath = EventHubName
                };

                eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

                await SendMessagesToEventHub();

                await eventHubClient.CloseAsync();

                Console.WriteLine("Press ENTER to exit.");
                Console.ReadLine();
            }


            private static async Task SendMessagesToEventHub()
            {
                try
                {
                    // Get the path to the executable or assembly's directory
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    // Define the relative path to your file within the solution folder
                    string relativePath = "ibor-transactions.json"; // Adjust this as needed

                    // Combine the base directory and relative path to get the full file path
                    string filePath = System.IO.Path.Combine(baseDirectory, relativePath);

                    var message = File.ReadAllText(filePath);
                    Console.WriteLine($"Sending message: {message}");
                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                Console.WriteLine("message sent.");
            }
        }
    }
}
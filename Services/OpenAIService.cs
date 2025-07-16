using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using System.Text.Json;

namespace AzureAIApp.Services
{
    public class OpenAIService
    {
        public async Task GetAiResponse()
        {
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "<your-key>";
            string apiUrl = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT_URL") ?? "https://<your-resource-name>.openai.azure.com/";

            AzureOpenAIClient client = new AzureOpenAIClient(
                new Uri(apiUrl),
                new AzureKeyCredential(apiKey)
            );

            // Initialize the ChatClient with the specified deployment name
            ChatClient chatClient = client.GetChatClient("gpt-35-turbo");

            // List of messages to send
            var messages = new List<ChatMessage>
            {
              new UserChatMessage(@"please provide list of Azure AI Services"),
              new UserChatMessage(@"I am using Azure OpenAI Service now."),
            };

            // Create chat completion options
            var options = new ChatCompletionOptions
            {
                Temperature = (float)0.7,
                MaxOutputTokenCount = 800,

                TopP = (float)0.95,
                FrequencyPenalty = (float)0,
                PresencePenalty = (float)0
            };

            try
            {
                // Create the chat completion request
                ChatCompletion completion = await chatClient.CompleteChatAsync(messages, options);

                // Print the response
                if (completion != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(completion, new JsonSerializerOptions() { WriteIndented = true }));
                }
                else
                {
                    Console.WriteLine("No response received.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}

using Azure;
using Azure.AI.DocumentIntelligence;
using Azure.AI.Vision.ImageAnalysis;
using AzureAIApp.Services;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
class Program
{
    static async Task Main(string[] args)
    {
        // Your Azure credentials
        string? endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT") ?? "https://<your-resource-name>.openai.azure.com/";
        string? apiKey = Environment.GetEnvironmentVariable("VISION_KEY") ?? "<your-key>";

        // Create an Image Analysis client.
        ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
        string? docEndpoint = Environment.GetEnvironmentVariable("DOCUMENT_ENDPOINT") ?? "https://<your-resource-name>.openai.azure.com/";
        string? docApiKey = Environment.GetEnvironmentVariable("DOCUMENT_KEY") ?? "<your-key>";
        var docClient = new DocumentIntelligenceClient(new Uri(docEndpoint), new AzureKeyCredential(docApiKey));
        // Get the base directory where the app is running (bin/Debug/...)
        string baseDir = AppContext.BaseDirectory;

        // Go up to the project root using Relative Path (../../..)
        string projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\"));
        // Local image or URL
        string imagePath = Path.Combine(projectRoot, "image", "3.png");

        await AnalyseImage(client, imagePath);
        await AnalyseFieldsFromDocument(docClient);
        await GetAiResponse();

        // This example requires environment variables named "SPEECH_KEY" and "ENDPOINT"
        string speechKey = Environment.GetEnvironmentVariable("SPEECH_KEY");
        string speechEndpoint = Environment.GetEnvironmentVariable("SPEECH_ENDPOINT");

        var speechConfig = SpeechConfig.FromSubscription(speechKey, "eastus");
        speechConfig.SpeechRecognitionLanguage = "en-US";

        // Optional delay to give the mic time to initialize
        Console.WriteLine("Preparing to listen...");
        await Task.Delay(5000); // Wait for 2 seconds

        using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
        using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

        Console.WriteLine("Speak into your microphone.");
        var speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
        var speechService = new SpeechService();
        speechService.OutputSpeechRecognitionResult(speechRecognitionResult);

        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }

    public static async Task AnalyseImage(ImageAnalysisClient client, string imagePath)
    {
        var imageAnalysis = new ImageAnalysisService();
        await imageAnalysis.GenerateImageCaptionFromUrl(client);
        await imageAnalysis.GenerateImageCaption(imagePath, client);
        await imageAnalysis.ExtractTextFromImage(imagePath, client);
        await imageAnalysis.ExtractTextFromImageUrl(client);
        Console.WriteLine("Image analysis completed...");
    }

    public static async Task AnalyseFieldsFromDocument(DocumentIntelligenceClient docClient)
    {
        Console.WriteLine("Analyzing fields from an invoice...");
        var docAnalysis = new DocumentAnalysisService();
        // Analyze fields from an invoice using a invoice sample URL
        await docAnalysis.AnalyseFieldsFromInvoice(docClient);
        // Analyze fields from a business card using a business card sample URL
        //await docAnalysis.AnalyseFieldsFromBusinessCard(docClient);

        Console.WriteLine("Document analysis completed.");
    }

    public static async Task GetAiResponse()
    {
        var openAiService = new OpenAIService();
        Console.WriteLine("Getting AI response...");
        await openAiService.GetAiResponse();
        Console.WriteLine("AI response received.");

    }


}


using Azure.AI.Vision.ImageAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAIApp.Services
{
    public class ImageAnalysisService
    {
        public async Task GenerateImageCaption(string imagePath, ImageAnalysisClient client)
        {
            // Use a file stream to pass the image data to the analyze call
            using FileStream stream = new FileStream(imagePath, FileMode.Open);

            // Get a caption for the image.
            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { GenderNeutralCaption = true });

            // Print caption results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Caption:");
            Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
        }

        public async Task GenerateImageCaptionFromUrl(ImageAnalysisClient client)
        {
            // Get a caption for the image.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { GenderNeutralCaption = true });

            // Print caption results to the console
            Console.WriteLine($"Image analysis results:");
            Console.WriteLine($" Caption:");
            Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
        }
        public async Task ExtractTextFromImage(string imagePath, ImageAnalysisClient client)
        {
            // Load image to analyze into a stream
            using FileStream stream = new FileStream(imagePath, FileMode.Open);

            // Extract text (OCR) from an image stream.
            ImageAnalysisResult result = client.Analyze(
                BinaryData.FromStream(stream),
                VisualFeatures.Read);

            // Print text (OCR) analysis results to the console
            Console.WriteLine("Image analysis results:");
            Console.WriteLine(" Read:");

            foreach (DetectedTextBlock block in result.Read.Blocks)
                foreach (DetectedTextLine line in block.Lines)
                {
                    Console.WriteLine($"'{line.Text}'");
                }
        }

        public async Task ExtractTextFromImageUrl(ImageAnalysisClient client)
        {
            // Extract text (OCR) from an image stream.
            ImageAnalysisResult result = client.Analyze(
                new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
                VisualFeatures.Read);

            // Print text (OCR) analysis results to the console
            Console.WriteLine("Image analysis results:");
            Console.WriteLine(" Read:");

            foreach (DetectedTextBlock block in result.Read.Blocks)
                foreach (DetectedTextLine line in block.Lines)
                {
                    Console.WriteLine($"   Line: '{line.Text}'");
                }
        }
    }
}

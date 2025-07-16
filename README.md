
AI-Powered Console Application with Azure & OpenAI

This console application demonstrates how to combine **Azure AI services** and **OpenAI** to build intelligent document and image processing features. It showcases real-world use cases such as OCR, image caption generation, invoice/business card field extraction, and conversational AI interactions.

✨ Features

- OCR – Extract printed or handwritten text from images.
- Image Captioning – Generate natural-language descriptions of images.
- Document Intelligence – Extract structured data from:
  - Invoices
  - Business Cards
- OpenAI GPT-3.5-Turbo – Interact with a language model to summarize data, generate insights, or provide smart responses.

🛠 Tech Stack

| Category  | Technology   |
|---------  |------------- |
| Language  | C#           |
| Framework | .NET 9       |
| Cloud     |  Azure       |
| Services  | 
| - Azure AI Document Intelligence   |
| - Azure AI Vision (Image Analysis) |
| - Azure OpenAI (GPT-3.5-Turbo)     |

🧠 AI Services & Tools Used

Azure AI Foundry
Used for managing AI model lifecycles and connecting multiple services in one place. This platform simplifies orchestration of AI resources.

Azure AI Document Intelligence Studio
Used to explore and test prebuilt models for:
- Invoices: Extract billing data, vendor info, totals, and tax details.
- Business Cards: Extract contact details like name, email, company, phone.

Azure Vision – Image Analysis
Used to:
- Perform OCR on image files.
- Generate captions describing image content (e.g., "a man holding a sign").

Azure OpenAI (GPT-3.5-Turbo)
Used to:
- Generate responses from extracted data.
- Summarize document contents or OCR results.
- Enable intelligent chat features.

Test Results:

<img width="1461" height="516" alt="image" src="https://github.com/user-attachments/assets/3b55d3d1-27fb-4fae-af81-cb8d72de1974" />

<img width="1218" height="425" alt="image" src="https://github.com/user-attachments/assets/9ad21b4f-aef8-4df8-89f2-cbfeb51bf259" />

🚀 How to Run

1. Clone this repository:
   
   git clone https://github.com/yourusername/your-repo-name.git
   cd your-repo-name

3. Set up your Azure keys and endpoints in environment variables:
   Example:
   
    set AZURE_VISION_KEY=your_azure_vision_key
    set AZURE_VISION_ENDPOINT=https://your-vision-endpoint.cognitiveservices.azure.com/
    
    set DOCUMENT_INTELLIGENCE_KEY=your_document_intelligence_key
    set DOCUMENT_INTELLIGENCE_ENDPOINT=https://your-docintel-endpoint.cognitiveservices.azure.com/
    
    set OPENAI_KEY=your_openai_key
    set OPENAI_ENDPOINT=https://your-openai-endpoint.openai.azure.com/
    set OPENAI_DEPLOYMENT=gpt-35-turbo

5. Build and run the application:

   dotnet build
   dotnet run

📚 Future Enhancements

* Add support for custom-trained models.
* Add UI for uploading documents and images.
* Integrate document classification.

🤝 Let's Connect

Feel free to reach out if you're exploring Azure AI, Document Intelligence, or OpenAI in your applications!

Let me know if you want help writing the `Program.cs` structure or sample methods for image captioning, document analysis, or OpenAI response generation.


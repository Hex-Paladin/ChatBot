# AI Chat Bot

This is a simple AI chat bot web application built using ASP.NET Core and OpenAI's GPT-3.5 Turbo model. The chat bot allows users to input text and receive AI-generated responses.

## Features

- Interactive chat interface
- Utilizes OpenAI's GPT-3.5 Turbo model for generating responses
- Configurable response length and number of results

## Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [OpenAI API Key](https://beta.openai.com/signup/)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/Hex-Paladin/ChatBot.git
   cd ChatBot
   ```

2. Configure the OpenAI API key:

   Create a file named `appsettings.json` in the `WebApplication` directory and add your OpenAI API key:

   ```json
   {
       "OpenAI": {
           "ApiKey": "YOUR_API_KEY_HERE"
       }
   }
   ```

3. Build and run the application:

   ```bash
   dotnet build
   dotnet run --project WebApplication
   ```

4. Open your browser and navigate to `http://localhost:5000` to use the chat bot.

## Usage

- Enter your query in the text box and click "Submit" to receive a response from the AI chat bot.
- You can configure the maximum number of tokens (response length) and the number of results to return.

## Project Structure

- `WebApplication/Pages/Index.cshtml.cs`: The main page model handling chat interactions.
- `WebApplication/appsettings.json`: Configuration file for storing the OpenAI API key.
- `WebApplication/Startup.cs`: Configures services and middleware for the application.

## Troubleshooting

### Common Issues

- **Push Rejected Due to Secrets**: Ensure that your OpenAI API key is not exposed in your commits. Use environment variables or a secret management tool to manage sensitive information.

### Resolving Push Rejections

1. Remove the secret from your commit history:
   - Follow the steps to clean your repository using BFG Repo-Cleaner or similar tools.

You can copy and paste this Markdown-formatted text directly into your `README.md` file on GitHub.

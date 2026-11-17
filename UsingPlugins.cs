using Azure;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsingSemanticKernelFromNET
{
    public class UsingPlugins
    {
        public async Task GetWeather(string modelName, string key)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: key).Build();

            kernel.ImportPluginFromType<WeatherPlugin>();

            OpenAIPromptExecutionSettings settings = new() { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };

            Console.WriteLine(await kernel.InvokePromptAsync("whats the weather in Southwell today? ", new(settings)));
        }
        public async Task ChatWithPlugins(string modelName, string key)
        {
            Kernel kernel = Kernel.CreateBuilder().AddOpenAIChatCompletion(modelId: modelName, apiKey: key).Build();

            kernel.ImportPluginFromType<WeatherPlugin>();
            kernel.ImportPluginFromType<UserPlugin>();

            OpenAIPromptExecutionSettings settings = new() { ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions };
            string response = string.Empty;
            ChatHistory chatHistory = new();

            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            while (response != "quit")
            {
                Console.WriteLine("enter your message:");
                response = Console.ReadLine();
                chatHistory.AddUserMessage(response);
                var assistantMessage = await chatCompletionService.GetChatMessageContentAsync(chatHistory, settings, kernel);
                Console.WriteLine(assistantMessage);
                chatHistory.Add(assistantMessage);
            }
        }
    }
}

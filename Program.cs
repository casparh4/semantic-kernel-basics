using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using UsingSemanticKernelFromNET;

Console.WriteLine("Hello, World!");


var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);



IConfiguration config = builder.Build();


var modelName = config["modelName"];
var imageModel = config["imageModelName"];
var APIKey = config["OPENAI_API_KEY"];



await new BasicsofSK().SimplestPromptLoop(modelName, APIKey); //called this way because not static, its an instance method

//await new UsingPlugins().GetWeather(modelName, APIKey);

//await new UsingPlugins().ChatWithPlugins(modelName, APIKey);
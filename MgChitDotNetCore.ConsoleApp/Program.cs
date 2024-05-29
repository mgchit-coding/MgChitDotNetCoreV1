// See https://aka.ms/new-console-template for more information

using MgChitDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");

Run run = new Run();
//run.Ado();
//run.Dapper();
run.EFCore();
//run.HttpClient();
//run.Refit();


Console.ReadKey();
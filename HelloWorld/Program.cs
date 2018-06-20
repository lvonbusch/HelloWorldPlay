using System;
using System.IO;
using HelloWorldInterfaces;
using HelloWorldServices;
using HelloWorldWriters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld
{
    // Really, really complicated Hello World console application
    // This application is just demostrating my knowledge of design patterns
    // and encapsulation.
    // This program has been set up to replace the console output class with
    // a class to use SQL to output to a DB. But right now, the SQL class isn't implemented.
    // Modern applications use Dependency Injection and chains of dependency with a service layer, business logic (domain) layer, and a data access layer
    // among other things.
    // The would also probably be a webservice API, but it didn't make sense here because a webservice API wouldn't be writing to the console.
    // This program was implemented using .Net Core 2.0 on a MacBook Pro.
    class Program
    {
        public static void Main(string[] args)
        {
            // use a JSON configuration file to specify whether the output should to to the console or to the DB.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            var outputLocation = configuration.GetSection("AppSettings:output_location");

  
            // Configure the dependency injection based on the setting in the config file.
            // There's only one HelloWorldService, but the "writer" object is injected into the 
            // constructor using DI magic.
            var serviceProvider = new ServiceCollection()
                .AddTransient<IHelloWorldWriter>(s => {
                    IHelloWorldWriter writer;
                    if (outputLocation.Value == "console")  //constants might be nice here, but this is just for pretend.
                        writer = new HelloWorldConsoleWriter();
                    else if (outputLocation.Value == "sql")
                        writer = new HelloWorldSqlWriter();
                    else
                        throw new ApplicationException("Undefined output type");
                    return writer;

                })
                .AddTransient<IHelloWorldService, HelloWorldService>()
                .BuildServiceProvider();

            // if the configuration file is changed to output_location = "sql", a NotImplementedException is thrown
            var helloWorld = serviceProvider.GetService<IHelloWorldService>();
            helloWorld.WriteHelloWorld();

        }

    
    }
}

using System;
using HelloWorldInterfaces;

namespace HelloWorldWriters
{
    public class HelloWorldConsoleWriter : IHelloWorldConsoleWriter
    {
        public void WriteHelloWorld()
        {
            // just writing hello, world to the console
            Console.WriteLine("hello, world");
        }
    }
}

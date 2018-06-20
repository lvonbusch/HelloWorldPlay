using System;
using HelloWorldInterfaces;

namespace HelloWorldServices
{
    public class HelloWorldService : IHelloWorldService
    {
        // Hello, world writing is injected into the service.
        IHelloWorldWriter writer;
        public HelloWorldService(IHelloWorldWriter writer)
        {
            this.writer = writer;
        }

        // service only does this one little thing, output depends on the object that was injected
        public void WriteHelloWorld()
        {
            writer.WriteHelloWorld();
        }

      }
}

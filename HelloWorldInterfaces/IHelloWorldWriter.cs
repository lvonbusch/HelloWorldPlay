using System;
namespace HelloWorldInterfaces
{
    public interface IHelloWorldWriter
    {
        // just one function here that is polymorphed depending on the class
        void WriteHelloWorld();
    }
}

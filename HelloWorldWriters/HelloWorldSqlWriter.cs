using System;
using HelloWorldInterfaces;

namespace HelloWorldWriters
{
    public class HelloWorldSqlWriter : IHelloWorldSqlWriter
    { 
        // not implemented, the intent here would be to write something out to a DB
        public void WriteHelloWorld()
        {
            throw new NotImplementedException();
        }
    }
}

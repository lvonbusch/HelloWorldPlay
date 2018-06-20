using System;
using HelloWorldInterfaces;
using HelloWorldServices;
using HelloWorldWriters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HelloWorldTests
{
    [TestClass]
    public class HelloWorldTest
    {
        // Use Moq for setting up mocks.
        // Not much to test here, but this is how the unit tests work.
        // Set up some mocks, and just make sure the function is called that outputs the value
        // Do the console one here
        [TestMethod]
        public void HelloWorldTest_IsConsoleCalled()
        {
            var mockWriter = new Mock<IHelloWorldConsoleWriter>();

            var service = new HelloWorldService(mockWriter.Object);

            service.WriteHelloWorld();

            mockWriter.Verify(x => x.WriteHelloWorld(), Times.Once());


        }

        // Do the SQL one here.  The SQL one isn't implemented.
        [TestMethod]
        public void HelloWorldTest_IsSqlCalled()
        {
            var mockWriter = new Mock<IHelloWorldSqlWriter>();

            var service = new HelloWorldService(mockWriter.Object);

            service.WriteHelloWorld();

            mockWriter.Verify(x => x.WriteHelloWorld(), Times.Once());


        }

        // The SQL version isn't implemented so just verify it throws a not implemented exception
        [TestMethod]
        public void HelloWorldTest_DoesSQLThrowError()
        {
            var sqlWriter = new HelloWorldSqlWriter();

            Assert.ThrowsException<NotImplementedException>(() => sqlWriter.WriteHelloWorld());
            
        }

    }
}

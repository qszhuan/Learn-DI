using System;
using System.Configuration;
using System.Threading;

namespace HelloDI
{
    class Program
    {
        static void Main(string[] args)
        {
            //create writer using config file
//            var writer = MessageWriter();

//            IMessageWriter writer = new ConsoleMessageWriter();
            var writer = new SecureMessageWriter(new ConsoleMessageWriter());
            var salutation = new Salutation(writer);

            salutation.Exclaim();
        }

        private static IMessageWriter MessageWriter()
        {
            var typeName = ConfigurationManager.AppSettings["messageWriter"];
            var type = Type.GetType(typeName, true);
            var writer = (IMessageWriter) Activator.CreateInstance(type);
            return writer;
        }
    }

    public class Salutation
    {
        private readonly IMessageWriter _writer;

        public Salutation(IMessageWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            _writer = writer;
        }

        public void Exclaim()
        {
            _writer.Write("Hello, DI!");
        }
    }

    public class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IMessageWriter
    {
        void Write(string message);
    }

    public class SecureMessageWriter :IMessageWriter
    {
        private readonly IMessageWriter _writer;

        public SecureMessageWriter(IMessageWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            _writer = writer;
        }

        public void Write(string message)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                _writer.Write(message);
            }
        }
    }
}

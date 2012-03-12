using System;
using System.Configuration;

namespace HelloDI
{
    class Program
    {
        static void Main(string[] args)
        {
            //create writer using config file
            var typeName = ConfigurationManager.AppSettings["messageWriter"];
            var type = Type.GetType(typeName, true);
            var writer = (IMessageWriter) Activator.CreateInstance(type);

//            IMessageWriter writer = new ConsoleMessageWriter();
            var salutation = new Salutation(writer);
            salutation.Exclaim();
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
}

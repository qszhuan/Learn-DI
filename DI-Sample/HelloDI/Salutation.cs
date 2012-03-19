using System;

namespace HelloDI
{
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
}
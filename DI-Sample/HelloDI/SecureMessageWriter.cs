using System;
using System.Threading;

namespace HelloDI
{
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
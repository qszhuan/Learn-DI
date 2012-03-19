using System;
using System.Configuration;
using Autofac;

namespace HelloDI
{
    class Program
    {
        static void Main(string[] args)
        {
            //create writer using config file
//            var writer = MessageWriter();

          //  var writer = SecureMessageWriter();
            
            var writer = AutofacWriter();

            var salutation = new Salutation(writer);

            salutation.Exclaim();
        }


        private static IMessageWriter AutofacWriter()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ConsoleMessageWriter>().As<IMessageWriter>();
            var container = containerBuilder.Build();
            var writer = container.Resolve<IMessageWriter>();
            return writer;
        }

        private static SecureMessageWriter SecureMessageWriter()
        {
//            IMessageWriter writer = new ConsoleMessageWriter();
            var writer = new SecureMessageWriter(new ConsoleMessageWriter());
            return writer;
        }

        private static IMessageWriter MessageWriter()
        {
            var typeName = ConfigurationManager.AppSettings["messageWriter"];
            var type = Type.GetType(typeName, true);
            var writer = (IMessageWriter) Activator.CreateInstance(type);
            return writer;
        }
    }
}

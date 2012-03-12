using Moq;
using Xunit;

namespace HelloDI
{
    public class SalutationFacts
    {
        [Fact]
        public void exclaim_will_write_correct_message_to_message_writer()
        {
            var mock = new Mock<IMessageWriter>();
            var salutation = new Salutation(mock.Object);
            salutation.Exclaim();
            mock.Verify(w=>w.Write("Hello, DI!"));
        }
    }
}
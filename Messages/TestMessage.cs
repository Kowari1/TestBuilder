using CommunityToolkit.Mvvm.Messaging.Messages;
using Test_Builder.Models;

namespace Test_Builder.Messages
{
    public class TestMessage : ValueChangedMessage<Test>
    {
        public TestMessage(Test value) : base(value)
        {
        }
    }
}

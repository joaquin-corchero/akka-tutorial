using Xunit;
using Akka.TestKit.Xunit2;
using AkkaTutorial.IOT.Actors;

namespace AkkaTutorialTests.IOT.Actors
{
    public class When_working_with_the_device_actor : TestKit
    {

        [Fact]
        public void Must_reply_with_empty_reading_if_no_temperature_is_known()
        {
            var probe = CreateTestProbe();
            var deviceActor = Sys.ActorOf(Device.Props("group", "device"));
        }
    }
}

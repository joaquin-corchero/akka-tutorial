using Akka.Actor;
using Akka.Event;
using AkkaTutorial.IOT.Messages;

namespace AkkaTutorial.IOT.Actors
{
    public class Device : UntypedActor
    {
        private readonly double? _lastTemperatureReading = null;
        protected string GroupId { get; }
        protected string DeviceId { get; }
        protected ILoggingAdapter Log { get; } = Context.GetLogger();

        public Device(string groupId, string deviceId)
        {
            GroupId = groupId;
            DeviceId = deviceId;
        }

        protected override void PreStart() => Log.Info($"Device actor {GroupId}-{DeviceId} started");

        protected override void PostStop() => Log.Info($"Device actor {GroupId}-{DeviceId} stopped");


        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case ReadTemperature read:
                    Sender.Tell(new RespondTemperature(read.RequestId, _lastTemperatureReading));
                    break;
            }
        }

        public static Props Props(string groupId, string deviceId) => Akka.Actor.Props.Create(() => new Device(groupId, deviceId));
    }
}

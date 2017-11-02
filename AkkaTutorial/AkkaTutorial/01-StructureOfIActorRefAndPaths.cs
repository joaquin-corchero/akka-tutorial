using System;
using Akka.Actor;

internal class StartStructureOfIActorRedAndPaths
{
    public static void StartSystem()
    {
        using (var system = ActorSystem.Create(nameof(StartStructureOfIActorRedAndPaths).ToLower()))
        {
            var firstRef = system.ActorOf(Props.Create<PrintMyActorRefActor>(), "first-actor");
            Console.WriteLine($"First: {firstRef}");
            firstRef.Tell("printit", ActorRefs.NoSender);
        }
    }
}

internal class PrintMyActorRefActor : UntypedActor
{
    protected override void OnReceive(object message)
    {
        switch (message)
        {
            case "printit":
                IActorRef secondRef = Context.ActorOf(Props.Empty, "second-actor");
                Console.WriteLine($"Second {secondRef}");
                break;
        }
    }
}
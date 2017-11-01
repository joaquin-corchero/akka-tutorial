using System;
using Akka.Actor;

public class PrintMyActorRefActor : UntypedActor
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
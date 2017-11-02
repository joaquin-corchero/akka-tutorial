using Akka.Actor;
using System;

namespace AkkaTutorial
{
    internal class HierarchyAndFailureHandling
    {
        public static void StartSystem()
        {
            var system = ActorSystem.Create(nameof(HierarchyAndFailureHandling).ToLower());
            var actor = system.ActorOf(Props.Create<SupervisingActor>(), "first-actor");
            Console.WriteLine($"First: {actor}");
            actor.Tell("failChild");

        }
    }

    internal class SupervisingActor : UntypedActor
    {
        private IActorRef child = Context.ActorOf(Props.Create<SupervisedActor>(), nameof(SupervisedActor));

        protected override void OnReceive(object message)
        {
            switch(message)
            {
                case "failChild":
                    Console.WriteLine("Telling child to fail");
                    child.Tell("fail");
                    break;
            }
        }
    }

    internal class SupervisedActor : UntypedActor
    {
        protected override void PreStart() => Console.WriteLine($"{nameof(SupervisedActor)} actor started");
        protected override void PostStop() => Console.WriteLine($"{nameof(SupervisedActor)} actor stopped");

        protected override void OnReceive(object message)
        {
            switch(message)
            {
                case "fail":
                    Console.WriteLine($"{nameof(SupervisedActor)} actor fails now");
                    throw new Exception($"{nameof(SupervisedActor)} forced failure");
            }
        }
    }
}

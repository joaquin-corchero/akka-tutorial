using Akka.Actor;
using System;

namespace AkkaTutorial
{
    internal class HierarchyAndLifecycleOfActors
    {
        public static void StartSystem()
        {
            using (var system = ActorSystem.Create(nameof(HierarchyAndLifecycleOfActors).ToLower()))
            {

                var firstRef = system.ActorOf(Props.Create<StartStopActor1>(), nameof(StartStopActor1));
                Console.WriteLine($"First: {firstRef}");
                firstRef.Tell("stop");
            }
        }
    }

    internal class StartStopActor1 : UntypedActor
    {
        protected override void PreStart()
        {
            Console.WriteLine("first started");
            Context.ActorOf(Props.Create<StartStopActor2>(), nameof(StartStopActor2));
        }

        protected override void PostStop() => Console.WriteLine("first stopped");

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "stop":
                    Context.Stop(Self);
                    break;
            }
        }
    }

    internal class StartStopActor2 : UntypedActor
    {
        protected override void PreStart() => Console.WriteLine("second started");

        protected override void PostStop() => Console.WriteLine("second stoped");

        protected override void OnReceive(object message)
        {
        }
    }
}

using System;
using Akka.Actor;
using System.Threading;

namespace AkkaTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StartSystem();
            Console.ReadLine();
        }

        public static void StartSystem()
        {
            var system = ActorSystem.Create("MainActorSystem");
            var firstRef = system.ActorOf(Props.Create<PrintMyActorRefActor>(), "first-actor");
            Console.WriteLine($"First: {firstRef}");
            firstRef.Tell("printit", ActorRefs.NoSender);
        }
    }

}

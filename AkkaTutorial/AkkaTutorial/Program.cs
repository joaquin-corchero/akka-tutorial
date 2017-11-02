using System;
using Akka.Actor;
using AkkaTutorial.IOT;

namespace AkkaTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"1 - {nameof(StartStructureOfIActorRedAndPaths)}");
            StartStructureOfIActorRedAndPaths.StartSystem();
            Console.ReadLine();
            Console.WriteLine($"2 - {nameof(HierarchyAndLifecycleOfActors)}");
            HierarchyAndLifecycleOfActors.StartSystem();
            Console.ReadLine();
            Console.WriteLine($"3 - {nameof(HierarchyAndFailureHandling)}");
            HierarchyAndFailureHandling.StartSystem();
            Console.ReadLine();

            Console.WriteLine($"IOT System");

            IotApp.Init();
        }

    }

}

using System;
using Akka.Actor;


namespace AkkaTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"1 - {nameof(StartStructureOfIActorRedAndPaths)}");
            StartStructureOfIActorRedAndPaths.StartSystem();
            Console.ReadLine();
            Console.WriteLine($"1 - {nameof(HierarchyAndLifecycleOfActors)}");
            HierarchyAndLifecycleOfActors.StartSystem();
            Console.ReadLine();
        }

    }

}

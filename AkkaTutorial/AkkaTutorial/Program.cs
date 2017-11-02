using System;
using Akka.Actor;


namespace AkkaTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StartStructureOfIActorRedAndPaths.StartSystem();
            Console.ReadLine();
        }

    }

}

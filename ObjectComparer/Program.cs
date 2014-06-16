using System;
using System.Collections.Generic;
using Castle.Windsor;
using ObjectComparer.HelperObjects;
using ObjectComparer.HelperObjects.Interfaces;
using ObjectComparer.Installers;

namespace ObjectComparer
{
    public class Program
    {
        private static IAuditor _auditor;

        public static void InitialiseCastle()
        {
            IWindsorContainer _container = new WindsorContainer();
            _container.Install(new AspectInstaller(), new WorkerInstaller());
            _auditor = _container.Kernel.Resolve<IAuditor>();
        }

        public static void Main(string[] args)
        { 
            AppDomain currentDomain = AppDomain.CurrentDomain;
            //Catch em all
            currentDomain.UnhandledException += MyHandler; 

            InitialiseCastle();

            IAnimal aCow = new Cow(){Colour = "Blue", NumberOfUdders = 5};
            IAnimal aDog = new Dog(){Breed = "PitBull", NumberOfPaws = 4, Colour = "Azure"};

            IAnimal blueDog = new Dog(){Breed = "Super", NumberOfPaws = 4, Colour = "Blue"};

            Bike aBike = new Bike(){Wheels = 4, HasHandleBars = false};
            Car  aCar = new Car(){NumberOfDoors = 3, Wheels = 4};
            Car fiveDoorCar = new Car() { NumberOfDoors = 5, Wheels = 4 };
            
            Compare(aCow, aDog);
            Compare(aDog, blueDog);
            Compare(aBike, aCar);
            Compare(aCar, fiveDoorCar);

            Console.ReadKey();


            #region interactive gui

            //var result = _auditor.GetChanges(aCow, aDog);

            //Console.WriteLine("Choose type of first object:");

            //Console.WriteLine("{1} -> Bike");
            //Console.WriteLine("{2} -> Car");
            //Console.WriteLine("{3} -> Cow");
            //Console.WriteLine("{4} -> Dog");

            //var typeA = Console.ReadLine();

            //if (string.IsNullOrEmpty(typeA))
            //{

            //}
            //var objAType = GetObject((int)typeA) 

            #endregion
        }

        private static void Compare(object objA, object objB)
        {
            PrintMessage("Press enter to start " + objA.GetType().Name + " & " + objB.GetType().Name + " comparison");

            PrintObject(objA, "ObjectA");
            PrintObject(objB, "ObjectB");

            var result = _auditor.GetChanges(objA, objB);
            PrintResults(result);
            PrintMessage("**************************************************************************");
        }

        private static void PrintResults(List<string> result)
        {
            if (result.Count == 0)
            {
                PrintMessage("No results;");
            }
            else
            {
                PrintMessage("Results are:");
                foreach (var diff in result)
                {
                    Console.WriteLine(diff);
                }
                Console.ReadKey();
            }
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private static void PrintObject(object obj, string objectName)
        {
            Console.WriteLine(objectName + " is " + obj.ToString());
            Console.ReadLine();
        }

        public static object GetObject(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new Bike();
                case 2:
                    return new Car();
                case 3:
                    IAnimal someCow = new Cow();
                    return someCow;
                case 4:
                    IAnimal someDog = new Dog();
                    return someDog;
            }

            return null;
        }

        public static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}

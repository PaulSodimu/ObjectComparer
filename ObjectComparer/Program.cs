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

        #region TestObjects

        private static IAnimal _aCow;
        private static IAnimal _aDog;
        private static IAnimal _aBlueDog;

        private static Bike _aBike;
        private static Car _aCar;
        private static Car _aFiveDoorCar;


        #endregion

        public static void InitialiseCastle()
        {
            IWindsorContainer _container = new WindsorContainer();
            _container.Install(new AspectInstaller(), new WorkerInstaller());
            _auditor = _container.Kernel.Resolve<IAuditor>();
        }
        
        private static void InitialiseObjects()
        {
            _aCow = new Cow() { Colour = "Blue", NumberOfUdders = 5 };
            _aDog = new Dog() { Breed = "PitBull", NumberOfPaws = 4, Colour = "Azure" };
            _aBlueDog = new Dog() { Breed = "Super", NumberOfPaws = 4, Colour = "Blue" };

            _aBike = new Bike() { Wheels = 4, HasHandleBars = false };
            _aCar = new Car() { NumberOfDoors = 3, Wheels = 4 };
            _aFiveDoorCar = new Car() { NumberOfDoors = 5, Wheels = 4 };
        }

        public static void Main(string[] args)
        { 
            //Catch em all
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += MyHandler; 

            InitialiseCastle();
            InitialiseObjects(); 

            Compare(_aCow, _aDog);
            Compare(_aDog, _aBlueDog);
            Compare(_aBike, _aCar);
            Compare(_aCar, _aFiveDoorCar);
            Compare(_aCar, _aCar);

            Console.ReadKey();
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

        public static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}

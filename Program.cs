using System;
using Unity;
using Unity.Injection;
using Unity.Resolution;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICar, Ford>("TESTE1");
            container.RegisterType<ICar, BMW>("TESTE2");
            container.RegisterType<Driver>("TESTE3",
                new InjectionConstructor(container.Resolve<ICar>("TESTE2")));

            Driver drv = container.Resolve<Driver>("TESTE3");
            drv.RunCar();
        }
    }
    public interface ICar
    {
        int Run();
    }

    public class BMW : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Ford : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Audi : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }

    }
    public class Driver
    {
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
            Console.ReadKey();
        }
    }
}

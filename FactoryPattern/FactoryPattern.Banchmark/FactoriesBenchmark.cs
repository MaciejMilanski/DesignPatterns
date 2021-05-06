using System;

using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

using SimpleFactory;
using FactoryMethod;
using AbstractFactory;
using ClassRagistrationFactory;


namespace FactoryPattern.Banchmark
{
    public class FactoriesBenchmark
    {
        private static readonly SimpleFactory.Factories.CarFactory simpleFactory = SimpleFactory.Factories.CarFactory.GetInstance();
        private static readonly FactoryMethod.Factories.Make1Factory fmFactory = FactoryMethod.Factories.Make1Factory.GetInstance();
        private static readonly AbstractFactory.Factories.Make1Factory abstractFactory = AbstractFactory.Factories.Make1Factory.GetInstance();
        private static readonly ClassRagistrationFactory.Factories.Make1Factory crFactory = ClassRagistrationFactory.Factories.Make1Factory.GetInstance();
        private static readonly ClassRegistrationFactoryReflection.Factories.Make1Factory crrFactory = ClassRegistrationFactoryReflection.Factories.Make1Factory.GetInstance();
        [Benchmark]
        public void AbstractFactoryBenchmark()
        {
            var car1 = abstractFactory.CreateCar(AbstractFactory.EModels.MODEL1);
            var car2 = abstractFactory.CreateCar(AbstractFactory.EModels.MODEL2);
        }
        [Benchmark]
        public void FactoryMethodBenchmark()
        {
            var car1 = fmFactory.CreateCar(FactoryMethod.EModels.MODEL1);
            var car2 = fmFactory.CreateCar(FactoryMethod.EModels.MODEL2);
        }
        [Benchmark]
        public void SimpleFactoryBenchmark()
        {
            var car1 = simpleFactory.CreateCar(SimpleFactory.EMakes.MAKE1, SimpleFactory.EModels.MODEL1);
            var car2 = simpleFactory.CreateCar(SimpleFactory.EMakes.MAKE1, SimpleFactory.EModels.MODEL2);
        }               
        [Benchmark]
        public void ClassRegistrationFactoryBenchmark()
        {
            var car1 = crFactory.CreateCar("Model1");
            var car2 = crFactory.CreateCar("Model2");
        }
        [Benchmark]
        public void ClassRegistrationFactoryWithReflectionBenchmark()
        {
            var car1 = crrFactory.CreateCar("Model1");
            var car2 = crrFactory.CreateCar("Model2");
        }
    }
}

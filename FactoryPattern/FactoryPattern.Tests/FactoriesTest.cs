using System;

using Xunit;


namespace FactoryPattern.Tests
{
    public class FactoriesTest
    {
        private static readonly SimpleFactory.Factories.CarFactory simpleFactory = SimpleFactory.Factories.CarFactory.GetInstance();
        private static readonly FactoryMethod.Factories.Make1Factory fmFactory = FactoryMethod.Factories.Make1Factory.GetInstance();
        private static readonly AbstractFactory.Factories.Make1Factory abstractFactory = AbstractFactory.Factories.Make1Factory.GetInstance();
        private static readonly ClassRagistrationFactory.Factories.Make1Factory crFactory = ClassRagistrationFactory.Factories.Make1Factory.GetInstance();
        private static readonly ClassRegistrationFactoryReflection.Factories.Make1Factory crrFactory = ClassRegistrationFactoryReflection.Factories.Make1Factory.GetInstance();
        [Fact]
        public void checkIfSameTypes_SimpleFactory()
        {
            var car1 = simpleFactory.CreateCar(SimpleFactory.EMakes.MAKE1, SimpleFactory.EModels.MODEL1);
            var car2 = simpleFactory.CreateCar(SimpleFactory.EMakes.MAKE1, SimpleFactory.EModels.MODEL2);

            Assert.Equal(typeof(SimpleFactory.Make1Models.Make1Model1), car1.GetType());
            Assert.Equal(typeof(SimpleFactory.Make1Models.Make1Model2), car2.GetType());
        }
        [Fact]
        public void checkIfSameTypes_fmFactory()
        {
            var car1 = fmFactory.CreateCar(FactoryMethod.EModels.MODEL1);
            var car2 = fmFactory.CreateCar(FactoryMethod.EModels.MODEL2);            

            Assert.Equal(typeof(FactoryMethod.Make1Models.Make1Model1), car1.GetType());
            Assert.Equal(typeof(FactoryMethod.Make1Models.Make1Model2), car2.GetType());
        }
        [Fact]
        public void checkIfSameTypes_AbstractFactory()
        {
            var car1 = abstractFactory.CreateCar(AbstractFactory.EModels.MODEL1);
            var car2 = abstractFactory.CreateCar(AbstractFactory.EModels.MODEL2);
            var bike1 = abstractFactory.CreateBike();

            Assert.Equal(typeof(AbstractFactory.Make1Models.Make1Model1), car1.GetType());
            Assert.Equal(typeof(AbstractFactory.Make1Models.Make1Model2), car2.GetType());
            Assert.Equal(typeof(AbstractFactory.Make1Models.Make1Bike), bike1.GetType());
        }
        [Fact]
        public void checkIfSameTypes_crFactory()
        {            
            var car1 = crFactory.CreateCar("Model1");
            var car2 = crFactory.CreateCar("Model2");

            Assert.Equal(typeof(ClassRagistrationFactory.Make1Models.Make1Model1), car1.GetType());
            Assert.Equal(typeof(ClassRagistrationFactory.Make1Models.Make1Model2), car2.GetType());
        }
        [Fact]
        public void checkIfSameTypes_crrFactory()
        {
            var car1 = crrFactory.CreateCar("Model1");
            var car2 = crrFactory.CreateCar("Model2");

            Assert.Equal(typeof(ClassRegistrationFactoryReflection.Make1Models.Make1Model1), car1.GetType());
            Assert.Equal(typeof(ClassRegistrationFactoryReflection.Make1Models.Make1Model2), car2.GetType());
        }
    }
}

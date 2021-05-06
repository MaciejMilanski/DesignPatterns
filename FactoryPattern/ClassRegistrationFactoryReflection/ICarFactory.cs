using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRegistrationFactoryReflection
{
    interface ICarFactory
    {
        public ICar CreateCar(string model);
    }
}

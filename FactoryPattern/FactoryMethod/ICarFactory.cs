using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    interface ICarFactory
    {
        public ICar CreateCar(EModels model);
    }
}

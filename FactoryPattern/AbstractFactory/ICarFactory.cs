using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    interface ICarFactory
    {
        public ICar CreateCar(EModels model);
        public IBike CreateBike();
    }
}

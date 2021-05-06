using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRagistrationFactory
{
    interface ICarFactory
    {
        public ICar CreateCar(string model);
    }
}

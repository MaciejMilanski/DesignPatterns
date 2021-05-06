using System;
using System.Collections.Generic;
using System.Text;

using ClassRagistrationFactory.Factories;

namespace ClassRagistrationFactory.Make1Models
{
    public class Make1Model1 : ICar
    {
        public ICar createCar()
        {
            return new Make1Model1();
        }
    }
}

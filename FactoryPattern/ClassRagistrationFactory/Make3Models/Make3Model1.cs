using System;
using System.Collections.Generic;
using System.Text;

using ClassRagistrationFactory.Factories;

namespace ClassRagistrationFactory.Make3Models
{
    public class Make3Model1 : ICar
    {
        public ICar createCar()
        {
            return new Make3Model1();
        }
    }
}

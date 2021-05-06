using System;
using System.Collections.Generic;
using System.Text;

using ClassRagistrationFactory.Factories;

namespace ClassRagistrationFactory.Make2Models
{
    public class Make2Model1 : ICar
    {
        public ICar createCar()
        {
            return new Make2Model1();
        }
    }
}

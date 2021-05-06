using System;
using System.Collections.Generic;
using System.Text;

using ClassRagistrationFactory.Factories;

namespace ClassRagistrationFactory.Make2Models
{
    public class Make2Model2 : ICar
    {
        public ICar createCar()
        {
            return new Make2Model2();
        }
    }
}

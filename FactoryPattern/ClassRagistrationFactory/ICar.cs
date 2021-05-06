using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRagistrationFactory
{
    public interface ICar
    {
        public abstract ICar createCar();

    }
}

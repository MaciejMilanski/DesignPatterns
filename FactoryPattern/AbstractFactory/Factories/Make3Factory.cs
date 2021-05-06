using System;
using System.Collections.Generic;
using System.Text;

using AbstractFactory.Make3Models;

namespace AbstractFactory.Factories
{
    public class Make3Factory : ICarFactory
    {
        private static Make3Factory _instance;
        public static Make3Factory GetInstance()
        {
            if (_instance == null)
                _instance = new Make3Factory();
            return _instance;
        }

        public IBike CreateBike()
        {
            return new Make3Bike();
        }

        public ICar CreateCar(EModels model)
        {
            switch (model)
            {
                case EModels.MODEL1:
                    {
                        return new Make3Model1();
                    }
                case EModels.MODEL2:
                    {
                        return new Make3Model2();
                    }
                case EModels.MODEL3:
                    {
                        return new Make3Model3();
                    }
                case EModels.MODEL4:
                    {
                        return new Make3Model4();
                    }
                case EModels.MODEL5:
                    {
                        return new Make3Model5();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}

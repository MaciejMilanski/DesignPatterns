using System;
using System.Collections.Generic;
using System.Text;

using AbstractFactory.Make1Models;

namespace AbstractFactory.Factories
{
    public class Make1Factory : ICarFactory
    {
        private static Make1Factory _instance;
        public static Make1Factory GetInstance()
        {
            if (_instance == null)
                _instance = new Make1Factory();
            return _instance;
        }

        public IBike CreateBike()
        {
            return new Make1Bike();
        }

        public ICar CreateCar(EModels model) 
        {
            switch (model)
            {
                case EModels.MODEL1:
                    {
                        return new Make1Model1();
                    }
                case EModels.MODEL2:
                    {
                        return new Make1Model2();
                    }
                case EModels.MODEL3:
                    {
                        return new Make1Model3();
                    }
                case EModels.MODEL4:
                    {
                        return new Make1Model4();
                    }
                case EModels.MODEL5:
                    {
                        return new Make1Model5();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}

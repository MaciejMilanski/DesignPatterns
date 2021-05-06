using System;
using System.Collections.Generic;
using System.Text;

using SimpleFactory.Make1Models;
using SimpleFactory.Make2Models;
using SimpleFactory.Make3Models;

namespace SimpleFactory.Factories
{
    public class CarFactory
    {

        private static CarFactory _instance;
        public static CarFactory GetInstance()
        {
            if (_instance == null)
                _instance = new CarFactory();
            return _instance;
        }
        public ICar CreateCar(EMakes make, EModels model)
        {
            switch (make)
            {
                case EMakes.MAKE1:
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
                case EMakes.MAKE2:
                    {
                        switch (model)
                        {
                            case EModels.MODEL1:
                                {
                                    return new Make2Model1();
                                }
                            case EModels.MODEL2:
                                {
                                    return new Make2Model2();
                                }
                            case EModels.MODEL3:
                                {
                                    return new Make2Model3();
                                }
                            case EModels.MODEL4:
                                {
                                    return new Make2Model4();
                                }
                            case EModels.MODEL5:
                                {
                                    return new Make2Model5();
                                }
                            default:
                                {
                                    return null;
                                }
                        }
                    }
                case EMakes.MAKE3:
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
                default:
                    return null;
            }
        }

    }
}

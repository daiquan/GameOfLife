using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;
using Castle.Windsor;

namespace GameOfLife.Tests.Controllers
{
    public class TestBase
    {
        private IWindsorContainer _container;
        public TestBase()
        {
           
             _container = WindsorControllerFactory.InitIoC();

            
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace GameOfLife
{
    public class WindsorControllerFactory:DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)kernel.Resolve(controllerType);
        }

        private static IWindsorContainer container;
        public static IWindsorContainer InitIoC()
        {
            container = new WindsorContainer().Install(FromAssembly.InThisApplication());
            return container;
        }
        public static void ConfigureIoC() {
            if(container == null)
            {
                InitIoC();
            }
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }


        public static void Dispose()
        {
            container.Dispose();
        }
    }
}
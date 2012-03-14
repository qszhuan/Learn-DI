using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using DoItRight_Domain;

namespace DoItRight
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            var compositionRoot = new CompositionRoot();
            ControllerBuilder.Current.SetControllerFactory(compositionRoot.ControllerFactory);
        }
    }

    public class CompositionRoot
    {
        public CompositionRoot()
        {
            ControllerFactory = CreateControllerFactory();
        }

        private static IControllerFactory CreateControllerFactory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CommerceEntities"].ConnectionString;
            var productRepoTypeName = ConfigurationManager.AppSettings["ProductRepositoryType"];
            var productRepoType = Type.GetType(productRepoTypeName, true);
            var repository = (ProductRepository)Activator.CreateInstance(productRepoType,connectionString);

            return new CommerceControllerFactory(repository);
        }

        public IControllerFactory ControllerFactory { get; private set; }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using DoItRight.Controllers;
using DoItRight_Domain;

namespace DoItRight
{
    public class CommerceControllerFactory : IControllerFactory
    {
        private readonly Dictionary<string, Func<RequestContext, IController>> controllerMap = 
            new Dictionary<string, Func<RequestContext, IController>>();

        public CommerceControllerFactory(ProductRepository repository)
        {
            if(repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            controllerMap["Home"] = ctx=> new HomeController(repository);
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            return controllerMap[controllerName](requestContext);
        }

        public void ReleaseController(IController controller)
        {
            
        }
    }
}
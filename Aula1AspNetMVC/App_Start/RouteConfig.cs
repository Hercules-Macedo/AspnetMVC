using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Aula1AspNetMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //criando outras rotas
            //não pode haver parametros opcionais se o ultimo parametro não for opcional, 
            //para que n se troque a ordem dos parametros e se entenda um parametro opcional no lugar do proximo parametro
            routes.MapRoute(
                name: "Secundaria",
                url: "{controller}/{action}/{id}/{nome}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                    nome = UrlParameter.Optional
                });

            //rota padrão sempre tem que ser a ultima 
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
        }
    }
}

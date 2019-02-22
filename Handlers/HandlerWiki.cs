using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Conceptos2Mvc.Handlers
{
    public class HandlerWiki : IHttpHandler
    {
        private List<String> bloqueos;
        //para routear necesitamos el requestcontext
        private RequestContext requestContext;
        public HandlerWiki(List<String> bloqueos, RequestContext requestContext)
        {

            this.bloqueos = bloqueos;
            this.requestContext = requestContext;
        }

        public bool IsReusable { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            ////String url = context.Request.RawUrl;
            ////int barra = url.LastIndexOf("/") +1;
            ////String provincia = url.Substring(barra);

            //RouteValueDictionary rutas = this.requestContext.RouteData.Values;
            ////de aqui sacamos los valores que nos pasan del mapeo
            //String provincia = rutas["provincia"].ToString();

            //if (this.provincias.Contains(provincia))
            //{
            //    //para indicar contextos en MVC se utiliza contextos
            //    context.AddError(new Exception("La provincia " + provincia + " no esta permitida"));
            //    String wikis = "https://es.wikipedia.org/wiki/" + "madrid";
            //    context.Response.Redirect(wikis, true);
            //    //al añadir una excepcion se anula todo el flujo de datos
            //}


            //String wiki = "https://es.wikipedia.org/wiki/" + provincia;
            //context.Response.Redirect(wiki, true);

            //en vez de obtener la infromacion tratando la url como string podemos usar
            //RouteValueDirectory y sacar los valores pidiendoselos al contexto.
            RouteValueDictionary rutas = this.requestContext.RouteData.Values;
            //de aqui sacamos los valores que nos pasan del mapeo
            String noticias = rutas["noticia"].ToString();

            if (this.bloqueos.Contains(noticias))
            {

                //para añadir una excepcion lo hacemos también desde el contexto 
                context.AddError(new Exception("Las noticias sobre  " + noticias + " no estan permitidas"));
                //al añadir una excepcion se anula todo el flujo de datos
            }

            //si no hay errores
            String pais = "https://elpais.com/tag/" + noticias + "/a/";
            context.Response.Redirect(pais, true);

        }
    }
}
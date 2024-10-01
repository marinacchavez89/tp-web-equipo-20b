using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace TPWeb_equipo_20B
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            // Registrar jQuery en el ScriptResourceMapping
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-3.5.1.min.js", // Ruta local si tienes los archivos
                    DebugPath = "~/Scripts/jquery-3.5.1.js", // Ruta del archivo no minificado
                    CdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js",
                    CdnDebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.js",
                    CdnSupportsSecureConnection = true
                });

        }
    }
}
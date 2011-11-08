using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceContacts
{
    /// <summary>
    /// Description résumée de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            string ret = "r:";
            SharepointServiceReference.SiteDÉquipeDataContext ws = new SharepointServiceReference.SiteDÉquipeDataContext(new Uri(Properties.Settings.Default.urlrest));
            ws.Credentials = System.Net.CredentialCache.DefaultCredentials;
            var query = from contact in ws.ContactsCASA
                        select contact;
            foreach (SharepointServiceReference.ContactsCASAItem item in query)
            {
                ret += item.Login + " " + item.Responsable + " ";
            }
            return ret;
        }
    }
}
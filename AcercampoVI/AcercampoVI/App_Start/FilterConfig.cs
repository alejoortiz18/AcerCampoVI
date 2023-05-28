using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace AcercampoVI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerifySession());
        }
    }
}

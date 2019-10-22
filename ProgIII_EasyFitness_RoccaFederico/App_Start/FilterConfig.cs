using System.Web;
using System.Web.Mvc;

namespace ProgIII_EasyFitness_RoccaFederico
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

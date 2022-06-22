using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace SimpleMultiLanguage.Utility
{
    public static class GlobalHelper
    {
        public static int CurrentLanguageCode
        {
            get
            {
                switch (HttpContext.Current.Request.RequestContext.RouteData.Values["lang"].ToString())
                {
                    case "en": return 0;
                    case "tr": return 1;
                    default: return 0;

                }
            }

        }
        public static string CurrentLanguage
        {
            get
            {
                return HttpContext.Current.Request.RequestContext.RouteData.Values["lang"].ToString();
            }

        }
        public static string CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
        }

        public static string DefaultCulture
        {
            get
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
                GlobalizationSection section = (GlobalizationSection)config.GetSection("system.web/globalization");
                return section.UICulture;
            }
        }
    }
}
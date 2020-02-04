using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithAuth.ApiRoutes
{
    public static class Routes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;


        public static class Products
        {
            public const string GetAll = Base + "/products";
            public const string Create = Base + "/products";

            public const string Get = Base + "/products/{productId}";
            public const string Update = Base + "/products/{productId}";
            public const string Delete = Base + "/products/{productId}";



        }
    }
}

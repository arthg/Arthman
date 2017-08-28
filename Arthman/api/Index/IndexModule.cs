using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arthman.api.Index
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get("/", args => "Hello World");
        }
    }
}

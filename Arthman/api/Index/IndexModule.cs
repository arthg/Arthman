using Nancy;

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

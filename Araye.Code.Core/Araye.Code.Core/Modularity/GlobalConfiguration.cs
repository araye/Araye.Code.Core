using System.Collections.Generic;

namespace Araye.Code.Core.Modularity
{
    public static class GlobalConfiguration
    {
        static GlobalConfiguration()
        {
            Modules = new List<ModuleInfo>();
        }

        public static IList<ModuleInfo> Modules { get; set; }

        public static string WebRootPath { get; set; }

        public static string ContentRootPath { get; set; }
    }
}

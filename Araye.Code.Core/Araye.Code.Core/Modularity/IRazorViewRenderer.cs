using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Araye.Code.Core.Modularity
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}

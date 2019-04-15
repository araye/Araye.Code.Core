using System;

namespace Araye.Code.Core.Security
{
    public class ArayePermissionAttribute : Attribute
    {
        public string Title { get; set; }
        public string GroupTitle { get; set; }
    }
}
using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Araye.Code.Core.Security
{
    public class ArayeActionPermissionAttribute : Attribute
    {
        public string Title { get; set; }
        public string ActionId { get; set; }
        public bool HaveSamePermission { get; set; }

        public static explicit operator ArayeActionPermissionAttribute(FilterDescriptor v)
        {
            throw new NotImplementedException();
        }
    }
}
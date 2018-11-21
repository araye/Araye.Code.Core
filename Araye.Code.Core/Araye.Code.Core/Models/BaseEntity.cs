using System;

namespace Araye.Code.Core.Models
{
    public abstract class BaseEntity 
    {
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public string UserCreatedIP { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public string UserModifiedIP { get; set; }
    }
}

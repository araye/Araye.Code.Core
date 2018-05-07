using System;
using System.Collections.Generic;
using System.Text;

namespace Araye.Code.Core.Models
{
    public abstract class EntityBaseWithTypedId<TId> : ValidatableObject, IEntityWithTypedId<TId>
    {
        public virtual TId Id { get; protected set; }
    }
}

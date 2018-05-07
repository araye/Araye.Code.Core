using System;
using System.Collections.Generic;
using System.Text;

namespace Araye.Code.Core.Models
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Araye.Code.Core.Events
{
    public class UserSignedIn : INotification
    {
        public long UserId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Araye.Code.Core.Events
{
    public class SequentialMediator : Mediator
    {
        public SequentialMediator(SingleInstanceFactory singleInstanceFactory, MultiInstanceFactory multiInstanceFactory) : base(singleInstanceFactory, multiInstanceFactory)
        {
        }

        protected async override Task PublishCore(IEnumerable<Task> allHandlers)
        {
            foreach (var handler in allHandlers)
            {
                await handler;
            }
        }
    }
}

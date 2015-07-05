using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qujck.Core.Events;

namespace Qujck.Data.Tests.Unit
{
    internal class MockEventHandler<TEvent> : 
        IEventHandler<TEvent> where TEvent : IEvent
    {
        public TEvent Parameter;
        public Action<TEvent> Action;

        public MockEventHandler() { }

        public MockEventHandler(Action<TEvent> action)
        {
            this.Action = action;
        }

        public void Handle(TEvent parameter)
        {
            this.Parameter = parameter;
            if (this.Action != null)
            {
                this.Action(parameter);
            }
        }
    }
}

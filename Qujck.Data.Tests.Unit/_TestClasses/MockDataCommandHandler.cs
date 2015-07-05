using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qujck.Data.Commands;

namespace Qujck.Data.Tests.Unit
{
    internal class MockDataCommandHandler<TCommand> :
        IDataCommandHandler<TCommand> where TCommand : IDataCommand
    {
        public TCommand Command;
        public Action<TCommand> Action;

        public MockDataCommandHandler() { }

        public MockDataCommandHandler(Action<TCommand> action)
        {
            this.Action = action;
        }

        public void Handle(TCommand command)
        {
            this.Command = command;
            if (this.Action != null)
            {
                this.Action(command);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qujck.Data.Queries;
using Qujck.Core.Events;
using Xunit;

namespace Qujck.Data.Tests.Unit.Queries
{
    public class QueryHandlerEventDecoratorTests
    {
        [Fact]
        public void Handle_CallsAllBeforeEventHandlers_BeforeCallingDecoratedInstance()
        {
            bool called = false;
            bool decoratedInstanceHasBeenCalled = false;

            var beforeEventHandlers = new MockEventHandler<OnBefore<FakeQuery>>[]
            {
                new MockEventHandler<OnBefore<FakeQuery>>(parameter => decoratedInstanceHasBeenCalled = called),
                new MockEventHandler<OnBefore<FakeQuery>>(parameter => decoratedInstanceHasBeenCalled = called),
                new MockEventHandler<OnBefore<FakeQuery>>(parameter => decoratedInstanceHasBeenCalled = called)
            };

            var decoratedInstance = new StubDataQueryHandler<FakeQuery, FakeResult>(
                () => called = true);

            var decorator = this.DecoratorFactory(
                decoratedInstance,
                beforeEventHandlers,
                null, 
                null);

            decorator.Handle(new FakeQuery());

            Assert.False(decoratedInstanceHasBeenCalled);
        }

        [Fact]
        public void Handle_CallsAllAfterQueryEventHandlers_AfterCallingDecoratedInstance()
        {
            bool called = false;
            bool decoratedInstanceHasBeenCalled = false;

            var afterEventHandlers = new MockEventHandler<OnAfter<FakeQuery>>[]
            {
                new MockEventHandler<OnAfter<FakeQuery>>(parameter => decoratedInstanceHasBeenCalled = called),
                new MockEventHandler<OnAfter<FakeQuery>>(parameter => decoratedInstanceHasBeenCalled = called),
                new MockEventHandler<OnAfter<FakeQuery>>(parameter => decoratedInstanceHasBeenCalled = called)
            };

            var decoratedInstance = new StubDataQueryHandler<FakeQuery, FakeResult>(
                () => called = true);

            var decorator = this.DecoratorFactory(
                decoratedInstance,
                null,
                afterEventHandlers,
                null);

            decorator.Handle(new FakeQuery());

            Assert.True(decoratedInstanceHasBeenCalled);
        }

        [Fact]
        public void Handle_CallsAllAfterResultEventHandlers_AfterCallingAllAfterQueryEventHandlers()
        {
            int callerId = 1;
            int callerIdCounter = 0;

            var afterEventHandlers = new MockEventHandler<OnAfter<FakeQuery>>[]
            {
                new MockEventHandler<OnAfter<FakeQuery>>(parameter => { if(callerId > 0) { callerIdCounter += callerId; callerId = 10; } }),
                new MockEventHandler<OnAfter<FakeQuery>>(parameter => { if(callerId > 0) { callerIdCounter += callerId; callerId = 100; } }),
                new MockEventHandler<OnAfter<FakeQuery>>(parameter => { if(callerId > 0) { callerIdCounter += callerId; callerId = 1000; } })
            };

            var afterEventHandlers2 = new MockEventHandler<OnAfter<FakeQuery, FakeResult>>[]
            {
                new MockEventHandler<OnAfter<FakeQuery, FakeResult>>(parameter => callerId = -1),
                new MockEventHandler<OnAfter<FakeQuery, FakeResult>>(parameter => callerId = -1),
                new MockEventHandler<OnAfter<FakeQuery, FakeResult>>(parameter => callerId = -1)
            };

            var decorator = this.DecoratorFactory(
                null,
                null,
                afterEventHandlers,
                afterEventHandlers2);

            decorator.Handle(new FakeQuery());

            Assert.Equal(111, callerIdCounter);
        }

        [Fact]
        public void Handle_Always_PassesTheCommandIntoEachBeforeEventHandler()
        {
            var beforeEventHandlers = new MockEventHandler<OnBefore<FakeQuery>>[]
            {
                new MockEventHandler<OnBefore<FakeQuery>>(),
                new MockEventHandler<OnBefore<FakeQuery>>(),
                new MockEventHandler<OnBefore<FakeQuery>>()
            };

            var decorator = this.DecoratorFactory(
                null,
                beforeEventHandlers,
                null,
                null);

            var command = new FakeQuery();

            decorator.Handle(command);

            Assert.Same(command, beforeEventHandlers[0].Parameter.Request);
            Assert.Same(command, beforeEventHandlers[1].Parameter.Request);
            Assert.Same(command, beforeEventHandlers[2].Parameter.Request);
        }

        [Fact]
        public void Handle_Always_PassesTheCommandIntoEachAfterQueryEventHandler()
        {
            var afterEventHandlers = new MockEventHandler<OnAfter<FakeQuery>>[]
            {
                new MockEventHandler<OnAfter<FakeQuery>>(),
                new MockEventHandler<OnAfter<FakeQuery>>(),
                new MockEventHandler<OnAfter<FakeQuery>>()
            };

            var decorator = this.DecoratorFactory(
                null,
                null,
                afterEventHandlers,
                null);

            var command = new FakeQuery();

            decorator.Handle(command);

            Assert.Same(command, afterEventHandlers[0].Parameter.Request);
            Assert.Same(command, afterEventHandlers[1].Parameter.Request);
            Assert.Same(command, afterEventHandlers[2].Parameter.Request);
        }

        [Fact]
        public void Handle_Always_PassesTheCommandIntoEachAfterResultEventHandler()
        {
            var afterEventHandlers2 = new MockEventHandler<OnAfter<FakeQuery, FakeResult>>[]
            {
                new MockEventHandler<OnAfter<FakeQuery, FakeResult>>(),
                new MockEventHandler<OnAfter<FakeQuery, FakeResult>>(),
                new MockEventHandler<OnAfter<FakeQuery, FakeResult>>()
            };

            var decorator = this.DecoratorFactory(
                null,
                null,
                null,
                afterEventHandlers2);

            var command = new FakeQuery();

            decorator.Handle(command);

            Assert.Same(command, afterEventHandlers2[0].Parameter.Request);
            Assert.Same(command, afterEventHandlers2[1].Parameter.Request);
            Assert.Same(command, afterEventHandlers2[2].Parameter.Request);
        }

        private DataQueryHandlerEventDecorator<FakeQuery, FakeResult> DecoratorFactory(
            IDataQueryHandler<FakeQuery, FakeResult> decoratedInstance,
            IEnumerable<IEventHandler<OnBefore<FakeQuery>>> beforeEventHandlers,
            IEnumerable<IEventHandler<OnAfter<FakeQuery>>> afterEventHandlers,
            IEnumerable<IEventHandler<OnAfter<FakeQuery, FakeResult>>> afterEventHandlers2)
        {
            return new DataQueryHandlerEventDecorator<FakeQuery, FakeResult>(
                decoratedInstance ?? new StubDataQueryHandler<FakeQuery, FakeResult>(),
                beforeEventHandlers ?? Enumerable.Empty<IEventHandler<OnBefore<FakeQuery>>>(),
                afterEventHandlers ?? Enumerable.Empty<IEventHandler<OnAfter<FakeQuery>>>(),
                afterEventHandlers2 ?? Enumerable.Empty<IEventHandler<OnAfter<FakeQuery, FakeResult>>>());
        }

        private class FakeQuery : IDataQuery<FakeResult> { }

        private class FakeResult { }
    }
}

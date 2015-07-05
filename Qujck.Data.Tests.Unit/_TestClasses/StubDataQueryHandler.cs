using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qujck.Data.Queries;

namespace Qujck.Data.Tests.Unit
{
    internal class StubDataQueryHandler<TQuery, TResult> :
        IDataQueryHandler<TQuery, TResult> where TQuery : IDataQuery<TResult>
    {
        public TQuery Query;
        public TResult Result;
        public Action Action;

        public StubDataQueryHandler() { }

        public StubDataQueryHandler(TResult result)
        {
            this.Result = result;
        }

        public StubDataQueryHandler(Action action, TResult result)
        {
            this.Action = action;
            this.Result = result;
        }

        public StubDataQueryHandler(Action action)
        {
            this.Action = action;
        }

        public TResult Handle(TQuery query)
        {
            this.Query = query;
            if (this.Action != null)
            {
                this.Action();
            }
            return this.Result;
        }
    }
}

namespace Qujck.Data.Queries
{
    public interface IDataQueryHandler<TQuery, TResult> where TQuery : IDataQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}

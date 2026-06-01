namespace CRM.Application.Common.Extention
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> ApplyPaging<TEntity>(
            this IOrderedQueryable<TEntity> query, int pageNumber, int pageSize)
        {
            int validPageNumber = pageNumber > 0 ? pageNumber : 1;
            int validPageSize = pageSize > 0 ? pageSize : 100;
            return query
                .Skip((validPageNumber - 1) * validPageSize)
                .Take(validPageSize);
        }
    }
}

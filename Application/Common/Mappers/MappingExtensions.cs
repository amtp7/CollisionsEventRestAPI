using CollisionsEventRestAPI.Application.DTOs;

namespace CollisionsEventRestAPI.Application.Mappers
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
            this IQueryable<TDestination> queryable, 
            int pageNumber, 
            int pageSize) where TDestination : class
        {
            return PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
        }
    }
}

using AutoMapper;

namespace ProyectoBaseNetCore.Services
{
    public class LinqHelper
    {
        private readonly IMapper mapper;

        public LinqHelper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<List<TDestination>> GetMappedListAsync<TSource, TDestination>(List<TSource> sourceList, Func<TSource, bool> condition) => await Task.FromResult(mapper.Map<List<TDestination>>(sourceList.Where(condition).ToList()));
    }
}
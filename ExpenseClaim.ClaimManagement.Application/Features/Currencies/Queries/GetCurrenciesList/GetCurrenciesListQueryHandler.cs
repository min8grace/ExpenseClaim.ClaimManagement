using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Queries.GetCurrenciesList
{
    public class GetCurrenciesListQueryHandler
    {
        private readonly IAsyncRepository<Currency> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCurrenciesListQueryHandler(IMapper mapper, IAsyncRepository<Currency> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CurrencyListVm>> Handle(GetCurrenciesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CurrencyListVm>>(allCategories);
        }
    }
}

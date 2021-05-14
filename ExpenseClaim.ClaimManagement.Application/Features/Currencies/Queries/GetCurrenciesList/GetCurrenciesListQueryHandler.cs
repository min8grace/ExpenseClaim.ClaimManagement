using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Queries.GetCurrenciesList
{
    public class GetCurrenciesListQueryHandler : IRequestHandler<GetCurrenciesListQuery, List<CurrencyListVm>>
    {
        private readonly IAsyncRepository<Currency> _currencyRepository;
        private readonly IMapper _mapper;

        public GetCurrenciesListQueryHandler(IMapper mapper, IAsyncRepository<Currency> currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public async Task<List<CurrencyListVm>> Handle(GetCurrenciesListQuery request, CancellationToken cancellationToken)
        {
            var allcurrencies = (await _currencyRepository.ListAllAsync());
            return _mapper.Map<List<CurrencyListVm>>(allcurrencies);
        }
    }
}

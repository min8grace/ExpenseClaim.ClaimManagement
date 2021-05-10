using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.UpdateCurrency
{
    class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand>
    {
        private readonly IAsyncRepository<Currency> _currencyRepository;
        private readonly IMapper _mapper;

        public UpdateCurrencyCommandHandler(IMapper mapper, IAsyncRepository<Currency> currencyRepository)
        {
            _mapper = mapper;
            _currencyRepository = currencyRepository;
        }

        public async Task<Unit> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {

            var currencyToUpdate = await _currencyRepository.GetByIdAsync(request.Id);
           
            _mapper.Map(request, currencyToUpdate, typeof(UpdateCurrencyCommand), typeof(Currency));

            await _currencyRepository.UpdateAsync(currencyToUpdate);

            return Unit.Value;
        }
    }
}

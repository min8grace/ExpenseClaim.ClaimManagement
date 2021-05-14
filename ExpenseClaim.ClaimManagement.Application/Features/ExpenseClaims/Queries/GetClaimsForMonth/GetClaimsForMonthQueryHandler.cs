using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetClaimsForMonth
{
    public class GetClaimsForMonthQueryHandler : IRequestHandler<GetClaimsForMonthQuery, PagedClaimsForMonthVm>
    {
        private readonly IExpenseClaimRepository _expenseClaimRepository;
        private readonly IMapper _mapper;

        public GetClaimsForMonthQueryHandler(IExpenseClaimRepository expenseClaimRepository, IMapper mapper)
        {
            _expenseClaimRepository = expenseClaimRepository;
            _mapper = mapper;
        }

        public async Task<PagedClaimsForMonthVm> Handle(GetClaimsForMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await _expenseClaimRepository.GetPagedClaimsForMonth(request.Date, request.Page, request.Size);
            var claims = _mapper.Map<List<ClaimsForMonthDto>>(list);


            var count = await _expenseClaimRepository.GetTotalCountOfClaimsForMonth(request.Date);
            return new PagedClaimsForMonthVm() { Count = count, ClaimsForMonth = claims, Page = request.Page, Size = request.Size };
        }
    }
}

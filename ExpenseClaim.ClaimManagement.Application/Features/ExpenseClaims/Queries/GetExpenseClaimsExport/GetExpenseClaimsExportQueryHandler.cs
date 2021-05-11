using AutoMapper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Infrastructure;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Persistence;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimsExport
{
    public class GetExpenseClaimsExportQueryHandler : IRequestHandler<GetExpenseClaimsExportQuery, ExpenseClaimsExportFileVm>
    {
        private readonly IAsyncRepository<ExpenseClaim> _expenseClaimRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetExpenseClaimsExportQueryHandler(IMapper mapper, IAsyncRepository<ExpenseClaim> expenseClaimRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _expenseClaimRepository = expenseClaimRepository;
            _csvExporter = csvExporter;
        }
        
        public async Task<ExpenseClaimsExportFileVm> Handle(GetExpenseClaimsExportQuery request, CancellationToken cancellationToken)
        {
            var allExpenseClaims = _mapper.Map<List<ExpenseClaimsExportDto>>((await _expenseClaimRepository.ListAllAsync()).OrderBy(x => x.SubmitDate));

            var fileData = _csvExporter.ExportExpenseClaimsToCsv(allExpenseClaims);

            var ExpenseClaimExportFileDto = new ExpenseClaimsExportFileVm() { ContentType = "text/csv", Data = fileData, ExpenseClaimExportFileName = $"{Guid.NewGuid()}.csv" };

            return ExpenseClaimExportFileDto;
        }
    }
}


using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimsExport;
using System.Collections.Generic;

namespace KakaoExpenseClaim.ClaimManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportExpenseClaimsToCsv(List<ExpenseClaimsExportDto> eventExportDtos);
    }
}

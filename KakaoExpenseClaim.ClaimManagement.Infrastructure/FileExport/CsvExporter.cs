using CsvHelper;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Infrastructure;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimsExport;
using System.Collections.Generic;
using System.IO;

namespace KakaoExpenseClaim.ClaimManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportExpenseClaimsToCsv(List<ExpenseClaimsExportDto> expenseClaimExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(expenseClaimExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}

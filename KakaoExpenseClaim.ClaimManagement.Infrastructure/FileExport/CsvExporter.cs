using CsvHelper;
using CsvHelper.Configuration;
using KakaoExpenseClaim.ClaimManagement.Application.Contracts.Infrastructure;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimsExport;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace KakaoExpenseClaim.ClaimManagement.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportExpenseClaimsToCsv(List<ExpenseClaimsExportDto> expenseClaimExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(expenseClaimExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}

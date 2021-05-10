using System;

namespace KakaoExpenseClaim.ClaimManagement.Application.Exceptions
{
    public class BadRequestException: ApplicationException
    {
        public BadRequestException(string message): base(message)
        {

        }
    }
}

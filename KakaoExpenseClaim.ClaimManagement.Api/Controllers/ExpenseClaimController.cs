using KakaoExpenseClaim.ClaimManagement.Api.Utility;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.CreateExpenseClaim;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.DeleteExpenseClaim;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Commands.UpdateExpenseClaim;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesList;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetCategoriesListWithEvents;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimById;
using KakaoExpenseClaim.ClaimManagement.Application.Features.ExpenseClaims.Queries.GetExpenseClaimsExport;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseClaimController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseClaimController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllExpenseClaims")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ExpenseClaimListVm>>> GetAllExpenseClaims()
        {
            var dtos = await _mediator.Send(new GetExpenseClaimsListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithevents", Name = "GetExpenseClaimsWithItems")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ExpenseClaimItemListVm>>> GetExpenseClaimsWithItems(bool includeHistory)
        {
            GetExpenseClaimsWithItemsQuery getExpenseClaimsListWithItemsQuery = new GetExpenseClaimsWithItemsQuery() { IncludeHistory = includeHistory };

            var dtos = await _mediator.Send(getExpenseClaimsListWithItemsQuery);
            return Ok(dtos);
        }


        [HttpGet("{id}", Name = "GetExpenseClaimById")]
        public async Task<ActionResult<ExpenseClaimDetailVm>> GetExpenseClaimById(int id)
        {
            var getExpenseClaimDetailQuery = new GetExpenseClaimDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getExpenseClaimDetailQuery));
        }

        [HttpPost(Name = "AddExpenseClaim")]
        public async Task<ActionResult<CreateExpenseClaimCommandResponse>> Create([FromBody] CreateExpenseClaimCommand createExpenseClaimCommand)
        {
            var response = await _mediator.Send(createExpenseClaimCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateExpenseClaim")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateExpenseClaimCommand updateExpenseClaimCommand)
        {
            await _mediator.Send(updateExpenseClaimCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteExpenseClaim")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteExpenseClaimCommand = new DeleteExpenseClaimCommand() { ExpenseClaimId = id };
            await _mediator.Send(deleteExpenseClaimCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportExpenseClaims")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportExpeseClaims()
        {
            var fileDto = await _mediator.Send(new GetExpenseClaimsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.ExpenseClaimExportFileName);
        }
    }
}

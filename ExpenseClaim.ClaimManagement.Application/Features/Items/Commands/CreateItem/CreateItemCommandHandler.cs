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

namespace KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemCommandResponse>
    {

        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;


        public CreateItemCommandHandler(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<CreateItemCommandResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var createItemCommandResponse = new CreateItemCommandResponse();

            var validator = new CreateItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request);


            if (validationResult.Errors.Count > 0)
            {
                createItemCommandResponse.Success = false;
                createItemCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createItemCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createItemCommandResponse.Success)
            {
                var item = _mapper.Map<Item>(request);
                item = await _itemRepository.AddAsync(item);
                createItemCommandResponse.Item = _mapper.Map<CreateItemDto>(item);
            }

            return createItemCommandResponse;
        }
    }
}

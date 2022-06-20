using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.SharedKernel.Interfaces;
using FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.InstructorItems
{
    public class GetById : BaseAsyncEndpoint<Guid, object>
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;

        public GetById(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }


        [HttpGet("/instructor/{id:Guid}")]
        [SwaggerOperation(
            Summary = "Gets a single InstructorItem",
            Description = "Gets a single InstructorItem by Id",
            OperationId = "Instructor.GetById",
            Tags = new[] { "InstructorItemEndpoints" })
        ]
        public override async Task<ActionResult<object>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await _instructorService.GetByIdAsync(id);

            if (item.Value == null)
            {               
                return Ok(Result<bool>.Error(item.Errors.First()));
            }
            //mapper
            var value = _mapper.Map<InstructorItemReadDto>(item.Value);

            var response = new Result<InstructorItemReadDto>(value);
            return Ok(response);
        }

    }
}

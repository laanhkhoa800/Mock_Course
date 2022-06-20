using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
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
    public class List : BaseAsyncEndpoint<string, Result<List<IntructorListReadDto>>>
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;

        public List(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }

        [HttpGet("/instructor/get-all")]
        [SwaggerOperation(
            Summary = "Gets a list of all Instructors by page",
            Description = "Gets a list of all Instructors by page",
            OperationId = "Instructor.List",
            Tags = new[] { "InstructorItemEndpoints" })
        ]
        public override async Task<ActionResult<Result<List<IntructorListReadDto>>>> HandleAsync(string searchString, CancellationToken cancellationToken)
        {
            var items = await _instructorService.GetAllIntructor(searchString);
            var values = _mapper.Map<List<IntructorListReadDto>>(items.Value);

            var modelsToReturn = new Result<List<IntructorListReadDto>> (values);
            return Ok(modelsToReturn);
        }
    }
}

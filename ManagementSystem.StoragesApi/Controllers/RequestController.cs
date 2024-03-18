using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ManagementSystem.Common.Entities;
using ManagementSystem.StoragesApi.Services;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using AutoMapper;
using Dapper;
using AutoMapper.QueryableExtensions;

namespace ManagementSystem.StoragesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly RequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(StoragesDbContext context, IMapper mapper)
        {
            _requestService = new RequestService(context, _mapper);
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult GetListRequests()
        {
            var requests = _requestService.GetListRequests();

            var rs = requests.AsQueryable().ProjectTo<RequestDTO>(_mapper.ConfigurationProvider).ToList();

            return Ok(new ResponseRequestDto() {
                Data = rs,
                TotalRecord = rs.Count(),
            });
        }

        [HttpGet("get_by_id")]
        public ActionResult GetRequestById([FromQuery]int id)
        {
            var request = _requestService.GetRequestById(id);
            var rs = _mapper.Map<RequestDTO>(request);
            if (rs == null)
            {
                return NotFound();
            }
            return Ok(rs);
        }

        [HttpPost("create")]
        public ActionResult<Request> CreateRequest([FromBody] RequestApiModel<RequestModel> request)
        {
            var createdRequest = _requestService.CreateRequest(request.Item);
            return CreatedAtAction(nameof(GetRequestById), new { id = createdRequest.RequestId }, createdRequest);
        }

        [HttpPost("update")]
        public IActionResult UpdateRequest([FromBody] RequestModel updatedRequest)
        {
            int id = updatedRequest.RequestId;
            var result = _requestService.UpdateRequest(id, updatedRequest);
            if (result)
            {
                return Ok(true);
            }

            return NotFound();
        }

        [HttpPost("update/status")]
        public IActionResult UpdateStatusRequest([FromBody] UpdateStatusModel updateStatusModel)
        {
            int id = updateStatusModel.RequestId;
            var result = _requestService.UpdateStatusRequest(id, updateStatusModel.RequestStatus);
            if (result)
            {
                return Ok(true);
            }

            return NotFound();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteRequest([FromQuery]int id)
        {
            var result = _requestService.DeleteRequest(id);
            return Ok(result);
        }
    }
}
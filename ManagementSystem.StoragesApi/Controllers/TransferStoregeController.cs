using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.StoragesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferStoregeController : ControllerBase
    {
        private readonly TransferStorageService _transferService;
        private readonly IMapper _mapper;

        public TransferStoregeController(StoragesDbContext context, IMapper mapper)
        {
            _transferService = new TransferStorageService(context);
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult GetListTransfer()
        {
            var transfers = _transferService.GetListTransfer();

            var rs = transfers.AsQueryable().ProjectTo<TransferDTO>(_mapper.ConfigurationProvider).ToList();

            return Ok(new ResponseTransferDto()
            {
                Data = rs,
                TotalRecord = rs.Count(),
            });
        }

         [HttpGet("get_by_id")]
        public ActionResult GetTransferById([FromQuery]int id)
        {
            var transfer = _transferService.GetTramsferById(id);
            var rs = _mapper.Map<TransferDTO>(transfer);
            if (transfer == null)
            {
                return NotFound();
            }
            return Ok(transfer);
        }

        [HttpPost("create")]
        public ActionResult<Transfer> CreateTransfer([FromBody] TransferApiModel<TransferModel> transfer)
        {
            var createdTransfer = _transferService.CreateTransfer(transfer.Item);
            return CreatedAtAction(nameof(GetTransferById), new { id = createdTransfer.TransferId }, createdTransfer);
        }

        [HttpPost("update")]
        public IActionResult UpdateTransfer([FromBody] TransferModel updatedTransfer)
        {
            int id = updatedTransfer.TransferId;
            var result = _transferService.UpdateTransfer(id, updatedTransfer);
            if (result)
            {
                return Ok(true);
            }

            return NotFound();
        }

        [HttpPost("update/status")]
        public IActionResult UpdateStatusTransfer([FromBody] StatusTransferModel updateStatusModel)
        {
            int id = updateStatusModel.TransferId;
            var result = _transferService.UpdateStatusTransfer(id, updateStatusModel.TransferStatus);
            if (result)
            {
                return Ok(true);
            }

            return NotFound();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteTransfer([FromQuery]int id)
        {
            var result = _transferService.DeleteTransfer(id);
            return Ok(result);
        }


    }

}

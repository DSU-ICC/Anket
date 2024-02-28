using DomainService.DtoModels.Account;
using DomainService.Models;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationModeController : Controller
    {
        private readonly IOperationModeRepository _operationModeRepository;
        public OperationModeController(IOperationModeRepository operationModeRepository)
        {
            _operationModeRepository = operationModeRepository;
        }

        [Route("GetOperationModes")]
        [HttpGet]
        public IActionResult GetOperationModes()
        {
            return Ok(_operationModeRepository.Get());
        }

        [Route("ChangeOperationMode")]
        [HttpGet]
        public async Task<IActionResult> ChangeOperationMode(int operationModeId)
        {
            var operationModes = _operationModeRepository.Get();
            foreach (var item in operationModes)
            {
                item.IsActive = false;
                if (item.Id == operationModeId)
                    item.IsActive = true;
                await _operationModeRepository.Update(item);
            }
            return Ok();
        }

        [Route("CreateOperationMode")]
        [HttpPost]
        public async Task<IActionResult> CreateOperationMode(OperationMode operationMode)
        {
            await _operationModeRepository.Create(operationMode);
            return Ok();
        }

        [Route("UpdateOperationMode")]
        [HttpPost]
        public async Task<IActionResult> UpdateOperationMode(OperationMode operationMode)
        {
            await _operationModeRepository.Update(operationMode);
            return Ok();
        }
    }
}

using DomainService.Models;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    //[Authorize(Roles = "admin")]
    [ApiController]
    [Route("[controller]")]
    public class OperationModeController : Controller
    {
        private readonly IOperationModeRepository _operationModeRepository;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        public OperationModeController(IOperationModeRepository operationModeRepository, ILoggerFactory loggerFactory)
        {
            _operationModeRepository = operationModeRepository;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger("OperationModeController");
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
            _logger.LogWarning("Изменение режима работы");
            foreach (var item in operationModes)
            {
                if (item.IsActive == true)
                    _logger.LogWarning("Убрана активность режима с Id = " + item.Id);
                item.IsActive = false;
                if (item.Id == operationModeId)
                {
                    item.IsActive = true;
                    _logger.LogWarning("Выбран активным режим с Id = " + item.Id);
                }
                await _operationModeRepository.Update(item);
            }
            return Ok();
        }

        [Route("UpdateOperationMode")]
        [HttpPost]
        public async Task<IActionResult> UpdateOperationMode(OperationMode operationMode)
        {
            var oldMode = _operationModeRepository.Get().FirstOrDefault(x=>x.Id == operationMode.Id);
            if (oldMode == null)
                return BadRequest("Не найден данный режим");
            _logger.LogWarning("Запрос на изменение режима с ID " + operationMode.Id + "\n Старый период = " + oldMode.BeginDate + " - " + oldMode.EndDate);
            await _operationModeRepository.Update(operationMode);
            
            _logger.LogWarning("Новый период = " + operationMode.BeginDate + " - " + operationMode.EndDate);
            return Ok();
        }
    }
}

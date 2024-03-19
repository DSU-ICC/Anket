using DomainService.Models;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anket.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("[controller]")]
    public class OperationModeController : Controller
    {
        private readonly IOperationModeRepository _operationModeRepository;
        //private readonly ILoggerFactory _loggerFactory;
        //private readonly ILogger logger;
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

        [Route("UpdateOperationMode")]
        [HttpPost]
        public async Task<IActionResult> UpdateOperationMode(OperationMode operationMode)
        {
            //var oldMode = await _operationModeRepository.FindById(operationMode.Id);
            //if (oldMode == null)
            //    return BadRequest("Не найден данный режим");
            //logger.LogInformation("Запрос на изменение режима с ID " + operationMode.Id + "\n Старый период = " + oldMode.BeginDate + " - " + oldMode.EndDate);
            //try
            //{
            //    await _operationModeRepository.Update(operationMode);
            //    logger.LogInformation("Новый период = " + operationMode.BeginDate + " - " + operationMode.EndDate);
            //}
            //catch (Exception ex) { }
            //{
            //    logger.LogInformation("Ошибка при попытке обновить период = " + operationMode.BeginDate + " - " + operationMode.EndDate);
            //}

            await _operationModeRepository.Update(operationMode);
            return Ok();
        }
    }
}

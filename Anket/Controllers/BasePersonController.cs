﻿using BasePersonDBService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anket.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BasePersonController : Controller
    {
        private readonly IBasePersonActiveData _basePersonActiveData;
        public BasePersonController(IBasePersonActiveData basePersonActiveData)
        {
            _basePersonActiveData = basePersonActiveData;
        }
    }
}

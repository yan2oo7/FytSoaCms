﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FytSoa.Common;
using FytSoa.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FytSoa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly ISysLogService _logService;
        public LogController(ISysLogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("getpages")]
        public async Task<JsonResult> GetPages(string key,string time)
        {
            var res = await _logService.GetPagesAsync(key, time);
            return Json(new { code = 0, msg = "success", count = res.data.TotalItems, data = res.data.Items });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<ApiResult<string>> DeleteMenu(string parm)
        {
            return await _logService.DeleteAsync(parm);
        }
    }
}
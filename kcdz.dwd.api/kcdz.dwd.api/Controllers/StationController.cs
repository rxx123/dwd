using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kcdz.dwd.api.common;
using kcdz.dwd.api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace kcdz.dwd.api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("any")] //设置跨域处理的 代理
    public class StationController : Controller
    {
        //构造函数注入上下文
        private readonly SignalDepotContext _context;
        public StationController(SignalDepotContext Context)
        {
            _context = Context;
        }
        /// <summary>
        /// 获取所有车站
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReturnMessage GetStations()
        {
            var result = _context.Station.ToList();
            if (result == null)
            {
                return new ReturnMessage(false, "车站信息获取失败！", null);
            }
            NLogger.logger.Info("车站信息获取成功！");
            return new ReturnMessage(true, "车站信息获取成功！", result);
        }
    }
}
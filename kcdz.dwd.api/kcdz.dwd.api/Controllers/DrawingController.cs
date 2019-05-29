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
    public class DrawingController : Controller
    {
        //构造函数注入上下文
        private readonly SignalDepotContext _context;
        public DrawingController(SignalDepotContext Context)
        {
            _context = Context;
        }

        [HttpGet("{station}")]
        public ReturnMessage GetDrawing(string station)
        {
            if (_context.Station.ToList().Find(x => x.StationName == station) == null)
            {
                NLogger.logger.Debug("获取图纸信息失败！");
                return new ReturnMessage(false, "获取图纸信息失败！", null);
            }
            var stationId = _context.Station.ToList().Find(x => x.StationName == station).Id;
            var drawingList = _context.Drawing.ToList();
            List<Drawing> drawingTemp=new List<Drawing>();
            for (int i = 0; i < drawingList.Count; i++)
            {
                if (drawingList[i].StationId==stationId)
                {
                    drawingTemp.Add(drawingList[i]);
                }
            }
            if (drawingTemp.Count <= 0)
            {
                NLogger.logger.Debug("获取图纸信息失败！");
                return new ReturnMessage(false, "获取图纸信息失败！", null);
            }
            NLogger.logger.Info("获取图纸信息成功！");
            return new ReturnMessage(true, "获取图纸信息成功！", drawingTemp);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kcdz.dwd.api.common;
using kcdz.dwd.api.Dtos;
using kcdz.dwd.api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace kcdz.dwd.api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("any")] //设置跨域处理的 代理
    public class EquipmentController : Controller
    {
        //构造函数注入上下文
        private readonly SignalDepotContext _context;
        public EquipmentController(SignalDepotContext Context)
        {
            _context = Context;
        }
        /// <summary>
        /// 查找设备信息
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        [Route("/api/Equipment/Semaphore")]
        [HttpPost]
        public ReturnMessage GetSemaphoreInfo([FromBody] EquipmentGetDto equipment)
        {
            var equipmentSemaphore = _context.EquipmentSemaphore.ToList();
            var result = equipmentSemaphore.FindIndex(x => x.DeviceName == equipment.desc&&x.BelongStation==equipment.station);
            if (result<0)
            {
                return new ReturnMessage(false, "获取设备信息失败！", null);
            }
            return new ReturnMessage(true, "", equipmentSemaphore[result]); 
        }
        [Route("/api/Equipment/Zone")]
        [HttpPost]
        public ReturnMessage GetZoneInfo([FromBody] EquipmentGetDto equipment)
        {
            var equipmentZone = _context.EquipmentZone.ToList();
            var result = equipmentZone.FindIndex(x => x.DeviceName == equipment.desc && x.BelongStation == equipment.station);
            if (result < 0)
            {
                return new ReturnMessage(false, "获取设备信息失败！", null);
            }
            return new ReturnMessage(true, "", equipmentZone[result]);
        }
        [Route("/api/Equipment/Turnout")]
        [HttpPost]
        public ReturnMessage GetTurnoutInfo([FromBody] EquipmentGetDto equipment)
        {
            var equipmentTurnout = _context.EquipmentTurnout.ToList();
            var result = equipmentTurnout.FindIndex(x => x.DeviceName == equipment.desc && x.BelongStation == equipment.station);
            if (result < 0)
            {
                return new ReturnMessage(false, "获取设备信息失败！", null);
            }
            return new ReturnMessage(true, "", equipmentTurnout[result]);
        }
        /// <summary>
        /// 添加设备信息
        /// </summary>
        /// <param name="equipmentLedger"></param>
        /// <returns></returns>
        [Route("/api/Equipment/Semaphore/Add")]
        [HttpPost]
        public ReturnMessage Post([FromBody] EquipmentSemaphore equipmentSemaphore)
        {
            equipmentSemaphore.Id = _context.EquipmentSemaphore.ToList().OrderByDescending(t => t.Id).First().Id + 1;
            _context.EquipmentSemaphore.Add(equipmentSemaphore);
            _context.SaveChanges();
            return new ReturnMessage(true, "添加成功！", null);
        }
        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("/api/Equipment/Semaphore")]
        [HttpPut]
        public ReturnMessage PutSemaphore([FromBody] EquipmentSemaphore equipmentSemaphore)
        {
            if (equipmentSemaphore.Id == -1)
            {
                equipmentSemaphore.Id = _context.EquipmentSemaphore.ToList().OrderByDescending(t => t.Id).First().Id + 1;
                _context.EquipmentSemaphore.Add(equipmentSemaphore);
                _context.SaveChanges();
                return new ReturnMessage(true, "添加成功！", null);
            }
            else
            {
                _context.EquipmentSemaphore.Attach(equipmentSemaphore);
                _context.Entry<EquipmentSemaphore>(equipmentSemaphore).Property("LineLimit").IsModified = true;
                _context.Entry<EquipmentSemaphore>(equipmentSemaphore).Property("AdjacentLimit").IsModified = true;
                _context.Entry<EquipmentSemaphore>(equipmentSemaphore).Property("LensGroupType").IsModified = true;
                _context.Entry<EquipmentSemaphore>(equipmentSemaphore).Property("NumberIndicators").IsModified = true;
                _context.Entry<EquipmentSemaphore>(equipmentSemaphore).Property("InstitutionalType").IsModified = true;
                _context.Entry<EquipmentSemaphore>(equipmentSemaphore).Property("EquipmentModel").IsModified = true;
                //_context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return new ReturnMessage(true, "修改成功！", null);
            }
        }
        [Route("/api/Equipment/Zone")]
        [HttpPut]
        public ReturnMessage PutZone([FromBody] EquipmentZone equipmentZone)
        {
            if (equipmentZone.Id == -1)
            {
                if (_context.EquipmentZone.ToList().Count == 0)
                {
                    equipmentZone.Id = 1;
                }
                else
                {
                    equipmentZone.Id = _context.EquipmentZone.ToList().OrderByDescending(t => t.Id).First().Id + 1;
                }

                _context.EquipmentZone.Add(equipmentZone);
                _context.SaveChanges();
                return new ReturnMessage(true, "添加成功！", null);
            }
            else
            {
                _context.EquipmentZone.Attach(equipmentZone);
                _context.Entry<EquipmentZone>(equipmentZone).Property("Type").IsModified = true;
                _context.Entry<EquipmentZone>(equipmentZone).Property("System").IsModified = true;
                _context.Entry<EquipmentZone>(equipmentZone).Property("Coding").IsModified = true;
                _context.Entry<EquipmentZone>(equipmentZone).Property("ZoneLength").IsModified = true;
                _context.SaveChanges();
                return new ReturnMessage(true, "修改成功！", null);
            }
        }
        [Route("/api/Equipment/Turnout")]
        [HttpPut]
        public ReturnMessage PutTurnout([FromBody] EquipmentTurnout equipmentTurnout)
        {
            if (equipmentTurnout.Id == -1)
            {
                if (_context.EquipmentTurnout.ToList().Count == 0)
                {
                    equipmentTurnout.Id = 1;
                }
                else
                {
                    equipmentTurnout.Id = _context.EquipmentTurnout.ToList().OrderByDescending(t => t.Id).First().Id + 1;
                }

                _context.EquipmentTurnout.Add(equipmentTurnout);
                _context.SaveChanges();
                return new ReturnMessage(true, "添加成功！", null);
            }
            else
            {
                _context.EquipmentTurnout.Attach(equipmentTurnout);
                _context.Entry<EquipmentTurnout>(equipmentTurnout).Property("MainLine").IsModified = true;
                _context.Entry<EquipmentTurnout>(equipmentTurnout).Property("SwitchType").IsModified = true;
                _context.Entry<EquipmentTurnout>(equipmentTurnout).Property("NumberSwitchMachine").IsModified = true;
                _context.Entry<EquipmentTurnout>(equipmentTurnout).Property("GapSupervision").IsModified = true;
                _context.Entry<EquipmentTurnout>(equipmentTurnout).Property("SnowMelting").IsModified = true;
                _context.Entry<EquipmentTurnout>(equipmentTurnout).Property("TapeChecker").IsModified = true;
                _context.Entry<EquipmentTurnout>(equipmentTurnout).Property("SettingType").IsModified = true;
                _context.Entry<EquipmentTurnout>(equipmentTurnout).Property("InterlockType").IsModified = true;
                _context.SaveChanges();
                return new ReturnMessage(true, "修改成功！", null);
            }
        }
    }
}
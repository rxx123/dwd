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
    public class EquipmentLedgerController : Controller
    {
        //构造函数注入上下文
        private readonly SignalDepotContext _context;
        public EquipmentLedgerController(SignalDepotContext Context)
        {
            _context = Context;
        }
        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        [Route("/api/[controller]/get")]
        [HttpPost]
        public ReturnMessageTable GetEquipmentLedgers([FromBody] EquipmentLedgerGetDto equipment)
        {
            var listEquipmentLedger = _context.EquipmentLedger.ToList();
            if (listEquipmentLedger.Count <= 0)
            {
                return new ReturnMessageTable(true, "", 0, 0, null);
            }
            List<EquipmentLedger> listEquipmentLedgerTemp=new List<EquipmentLedger>();
            for (int i = 0; i < listEquipmentLedger.Count; i++)
            {
                if (listEquipmentLedger[i].BelongStation == equipment.station)
                {
                    listEquipmentLedgerTemp.Add(listEquipmentLedger[i]);
                }
            }
            //List<EquipmentLedger> listEquipmentLedgerTemp = new List<EquipmentLedger>();
            //for (int i = (equipment.currentPage-1)*equipment.per_page; i < equipment.currentPage * equipment.per_page; i++)
            //{
            //    listEquipmentLedgerTemp.Add(listEquipmentLedger[i]);
            //}
            //return new ReturnMessageTable(true, "", listEquipmentLedger.Count, equipment.currentPage, listEquipmentLedger.GetRange((equipment.currentPage - 1) * equipment.per_page, equipment.per_page));
            return new ReturnMessageTable(true, "", listEquipmentLedgerTemp.Count, equipment.currentPage, listEquipmentLedgerTemp);
        }
        /// <summary>
        /// 添加设备信息
        /// </summary>
        /// <param name="equipmentLedger"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnMessage Post([FromBody] EquipmentLedger equipmentLedger)
        {
            if (_context.EquipmentLedger.ToList().Count == 0)
            {
                equipmentLedger.Id = 1;
            }
            else
            {
                equipmentLedger.Id = _context.EquipmentLedger.ToList().OrderByDescending(t => t.Id).First().Id + 1;
            }
            _context.EquipmentLedger.Add(equipmentLedger);
            _context.SaveChanges();
            if (equipmentLedger.DeviceClassify == "信号机")
            {
                var index = _context.EquipmentSemaphore.ToList().FindIndex(t =>
                    t.BelongStation == equipmentLedger.BelongStation && t.DeviceName == equipmentLedger.DeviceName);
                _context.EquipmentSemaphore.ToList()[index].EquipmentLedgerId = equipmentLedger.Id;
                _context.EquipmentSemaphore.Attach(_context.EquipmentSemaphore.ToList()[index]);
                _context.Entry<EquipmentSemaphore>(_context.EquipmentSemaphore.ToList()[index]).Property("EquipmentLedgerId").IsModified = true;
                _context.SaveChanges();
            }
            if (equipmentLedger.DeviceClassify == "道岔")
            {
                var index = _context.EquipmentTurnout.ToList().FindIndex(t =>
                    t.BelongStation == equipmentLedger.BelongStation && t.DeviceName == equipmentLedger.DeviceName);
                _context.EquipmentTurnout.ToList()[index].EquipmentLedgerId = equipmentLedger.Id;
                _context.EquipmentTurnout.Attach(_context.EquipmentTurnout.ToList()[index]);
                _context.Entry<EquipmentTurnout>(_context.EquipmentTurnout.ToList()[index]).Property("EquipmentLedgerId").IsModified = true;
                _context.SaveChanges();
            }
            return new ReturnMessage(true, "添加成功！", null);
        }
        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public ReturnMessage Put([FromBody] EquipmentLedger equipmentLedger)
        {
            _context.EquipmentLedger.Attach(equipmentLedger);
            _context.Entry<EquipmentLedger>(equipmentLedger).Property("DeviceCode").IsModified = true;
            _context.Entry<EquipmentLedger>(equipmentLedger).Property("DeviceClassify").IsModified = true;
            //_context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return new ReturnMessage(true, "修改成功！", null);
        }
        /// <summary>
        /// 删除设备信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ReturnMessage Delete(int id)
        {
            EquipmentLedger equipmentLedger = _context.EquipmentLedger.Find(id);
            _context.EquipmentLedger.Remove(equipmentLedger);
            _context.SaveChanges();
            return new ReturnMessage(true, "删除成功！", null);
        }
    }
}
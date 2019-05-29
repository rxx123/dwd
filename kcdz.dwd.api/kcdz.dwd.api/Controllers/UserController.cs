using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    public class UserController : Controller
    {
        //构造函数注入上下文
        private readonly SignalDepotContext _context;
        public UserController(SignalDepotContext Context)
        {
            _context = Context;
        }
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ReturnMessage GetUsers()
        {
            var result = _context.User.ToList();
            if (result == null)
            {
                return new ReturnMessage(false, "用户信息获取失败！", null);
            }
            NLogger.logger.Info("用户信息获取成功！");
            return new ReturnMessage(true, "用户信息获取成功！", result);
        }
        /// <summary>
        /// 根据用户名和密码查找用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("/api/Login")]
        [HttpPost]
        public ReturnMessage Login([FromBody] User user)
        {
            var result = _context.User.ToList().FindIndex(x => x.UserName == user.UserName && x.PassWord == user.PassWord);
            if (result < 0)
            {
                NLogger.logger.Debug("登录失败！");
                return new ReturnMessage(false, "登录失败！", null);
            }
            NLogger.logger.Info(user.UserName + ":登录成功！");
            return new ReturnMessage(true, "登录成功！", _context.User.ToList()[result]);
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ReturnMessage Post([FromBody] User user)
        {
            user.Id = _context.User.ToList().OrderByDescending(t => t.Id).First().Id + 1;
            _context.User.Add(user);
            _context.SaveChanges();
            return new ReturnMessage(true, "添加成功！", null);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public ReturnMessage Put([FromBody] User user)
        {
            _context.User.Attach(user);
            _context.Entry<User>(user).Property("UserName").IsModified = true;
            _context.Entry<User>(user).Property("PassWord").IsModified = true;
            //_context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return new ReturnMessage(true, "修改成功！", null);
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ReturnMessage Delete(int id)
        {
            User user = _context.User.Find(id);
            _context.User.Remove(user);
            _context.SaveChanges();
            return new ReturnMessage(true, "删除成功！", null);
        }
    }
}
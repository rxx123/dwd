using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcdz.dwd.api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
    }
}

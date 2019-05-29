using System;
using System.Collections.Generic;

namespace kcdz.dwd.api.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}

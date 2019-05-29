using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kcdz.dwd.api.Dtos
{
    public class UserCreationDto
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "{0}是必填项")]
        // [MinLength(2, ErrorMessage = "{0}的最小长度是{1}")]
        // [MaxLength(10, ErrorMessage = "{0}的长度不可以超过{1}")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{0}的长度应该不小于{2}, 不大于{1}")]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{0}的长度应该不小于{2}, 不大于{1}")]
        public string PassWord { get; set; }
    }
}

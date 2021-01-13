using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFinal.Models
{
    public class UserAdmin
    {
        [DisplayName("Tên Đăng Nhập")]
        [Required(ErrorMessage ="Vui lòng nhập tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string MatKhau { get; set; }
    }
}
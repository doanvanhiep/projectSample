using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectFinal.Models
{
    public class RegisterAdmin
    {
        [DisplayName("Tên Đăng Nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string MatKhau { get; set; }
        [DisplayName("Nhập Lại Mật Khẩu")]
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        public string ReMatKhau { get; set; }
        [DisplayName("Tên Công Ty")]
        public string TenCongTy { get; set; }
    }
}
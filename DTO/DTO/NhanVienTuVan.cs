using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienTuVan
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string NgaySinh { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string TrangThai { get; set; }

        public NhanVienTuVan(string maNV, string tenNV, string sdt, string email, string ngaySinh, string password, string role, string tt)
        {
            MaNV = maNV;
            TenNV = tenNV;
            SDT = sdt;
            Email = email;
            NgaySinh = ngaySinh;
            Password = password;
            Role = role;
            TrangThai = tt;
        }
        public NhanVienTuVan() { }
    }

}

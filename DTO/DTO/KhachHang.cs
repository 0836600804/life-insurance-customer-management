using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string MaKH { get; set; }  
        public string TenKH { get; set; } 
        public DateTime NgaySinh { get; set; } 
        public string SDT { get; set; }   
        public string Email { get; set; }  
        public string DiaChi { get; set; }
        public string CCCD { get; set; }
        public string NgheNghiep { get; set; }

        public KhachHang() { }

        public KhachHang(string maKH, string tenKH, DateTime ngaySinh, string sdt, string email, string diaChi, string cccd, string ngheNghiep)
        {
            MaKH = maKH;
            TenKH = tenKH;
            NgaySinh = ngaySinh;
            SDT = sdt;
            Email = email;
            DiaChi = diaChi;
            CCCD = cccd;
            NgheNghiep = ngheNghiep;
        }

        public override string ToString()
        {
            return $"Mã: {MaKH} - Tên: {TenKH} - Ngày sinh: {NgaySinh:dd/MM/yyyy} - SĐT: {SDT} - Email: {Email} - Địa chỉ: {DiaChi} - CCCD: {CCCD}";
        }
    }

}

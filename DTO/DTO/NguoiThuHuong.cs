using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiThuHuong
    {
        public string MaNTH { get; set; }    
        public string TenNTH { get; set; }  
        public string SDT { get; set; }    
        public string CCCD { get; set; }    
        public string DiaChi { get; set; }   
        public string NgheNghiep { get; set; } 

        public NguoiThuHuong() { }

        public NguoiThuHuong(string maNTH, string tenNTH, string sdt, string cccd, string diaChi, string ngheNghiep)
        {
            MaNTH = maNTH;
            TenNTH = tenNTH;
            SDT = sdt;
            CCCD = cccd;
            DiaChi = diaChi;
            NgheNghiep = ngheNghiep;
        }

        public override string ToString()
        {
            return $"Mã: {MaNTH} - Tên: {TenNTH} - SĐT: {SDT} - CCCD: {CCCD} - Địa chỉ: {DiaChi} - Nghề nghiệp: {NgheNghiep}";
        }
    }

}

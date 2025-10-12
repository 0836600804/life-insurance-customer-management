using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KhachHang
    {
        private readonly DAO_KhachHang _daoKhachHang;

        public BUS_KhachHang(DAO_KhachHang daoKhachHang)
        {
            _daoKhachHang = daoKhachHang;
        }

        public async Task<KhachHang> GetKhachHangByMaAsync(string maKH)
        {
            return await _daoKhachHang.GetKhachHangByMaAsync(maKH);
        }

        public async Task<KhachHang> GetKhachHangByMaHDAsync(string maHD)
        {
            return await _daoKhachHang.GetKhachHangByMaHDAsync(maHD);
        }

        public async Task<bool> ThemKhachHangAsync(KhachHang kh)
        {
            if (string.IsNullOrWhiteSpace(kh.MaKH) || string.IsNullOrWhiteSpace(kh.TenKH))
            {
                throw new ArgumentException("Mã khách hàng và Tên khách hàng không được để trống.");
            }

            return await _daoKhachHang.ThemKhachHangAsync(kh);
        }
        public async Task<bool> CapNhatKhachHangAsync(KhachHang khachHang)
        {
            return await _daoKhachHang.CapNhatKhachHangAsync(khachHang);
        }
        public async Task<List<KhachHang>> GetDanhSachKhachHangAsync()
        {
            return await _daoKhachHang.GetDanhSachKhachHangAsync();
        }
    }

}

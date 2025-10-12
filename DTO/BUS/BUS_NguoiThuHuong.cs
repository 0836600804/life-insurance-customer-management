using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NguoiThuHuong
    {
        private readonly DAO_NguoiThuHuong _daoNguoiThuHuong;

        public BUS_NguoiThuHuong(DAO_NguoiThuHuong daoNguoiThuHuong)
        {
            _daoNguoiThuHuong = daoNguoiThuHuong;
        }

        public async Task<bool> ThemNguoiThuHuongAsync(NguoiThuHuong nth)
        {
            return await _daoNguoiThuHuong.ThemNguoiThuHuongAsync(nth);
        }

        public async Task<NguoiThuHuong> GetNguoiThuHuongByMaHDAsync(string maHD)
        {
            return await _daoNguoiThuHuong.GetNguoiThuHuongByMaHDAsync(maHD);
        }
        public async Task<bool> CapNhatNguoiThuHuongAsync(NguoiThuHuong nth)
        {
            return await _daoNguoiThuHuong.CapNhatNguoiThuHuongAsync(nth);
        }

    }
}

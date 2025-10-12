using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_HopDongBaoHiem
    {
        private DAO_HopDongBaoHiem daoHopDong;

        public BUS_HopDongBaoHiem(DAO_HopDongBaoHiem dao)
        {
            daoHopDong = dao;
        }
        public async Task<List<HopDongBaoHiem>> GetDanhSachHopDongAsync()
        {
            return await daoHopDong.GetDanhSachHopDongAsync();
        }

        public async Task<bool> ThemHopDongAsync(HopDongBaoHiem hd)
        {
            return await daoHopDong.ThemHopDongAsync(hd);
        }

        public async Task<List<HopDongBaoHiem>> GetDanhSachHopDongChuaThanhToanAsync()
        {
            return await daoHopDong.GetDanhSachHopDongChuaThanhToanAsync();
        }
        public async Task<bool> CapNhatTrangThaiHopDongAsync(string maHD, string trangThaiMoi)
        {
            return await daoHopDong.CapNhatTrangThaiHopDongAsync(maHD, trangThaiMoi);
        }

        public async Task<int> DemSoHoaDonTheoHopDongAsync(string maHD)
        {
            return await daoHopDong.DemSoHoaDonTheoHopDongAsync(maHD);
        }

        public async Task<int> LayKyThanhToanTiepTheoAsync(string maHD)
        {
            int soHoaDon = await daoHopDong.DemSoHoaDonTheoHopDongAsync(maHD);
            return (soHoaDon >= 0) ? soHoaDon + 1 : 1;
        }
    }

}

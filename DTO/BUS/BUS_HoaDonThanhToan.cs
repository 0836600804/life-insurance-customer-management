using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_HoaDonThanhToan
    {
        private DAO_HoaDonThanhToan daoHoaDonThanhToan;

        public BUS_HoaDonThanhToan(DAO_HoaDonThanhToan dAO_HoaDonThanhToan)
        {
            this.daoHoaDonThanhToan = dAO_HoaDonThanhToan;
        }

        public async Task<bool> ThemHoaDonThanhToanAsync(string maHD, HoaDonThanhToan hoaDon)
        {
            return await daoHoaDonThanhToan.ThemHoaDonThanhToanAsync(maHD, hoaDon);
        }

        public async Task<List<HoaDonThanhToan>> GetHoaDonByMaHDAsync(string maHD)
        {
            return await daoHoaDonThanhToan.GetHoaDonByMaHDAsync(maHD);
        }
    }
}

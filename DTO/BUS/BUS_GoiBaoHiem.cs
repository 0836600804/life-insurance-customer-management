using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_GoiBaoHiem
    {
        private readonly DAO_GoiBaoHiem dao_GoiBaoHiem;

        public BUS_GoiBaoHiem(DAO_GoiBaoHiem daoGoiBaoHiem)
        {
            dao_GoiBaoHiem = daoGoiBaoHiem;
        }

        public async Task<List<GoiBaoHiem>> GetAllGoiBaoHiemAsync()
        {
            return await dao_GoiBaoHiem.GetGoiBaoHiemListAsync();
        }
        public async Task<float> TinhPhiDongDinhKiAsync(string maGoi, DateTime ngaySinh, string phuongThucDong)
        {
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (DateTime.Now < ngaySinh.AddYears(tuoi)) tuoi--;
            Console.WriteLine($"Tuổi: {tuoi}");


            BangPhiBaoHiem bangPhi = await dao_GoiBaoHiem.GetBangPhiBaoHiemByTuoiAsync(maGoi, tuoi);

            if (bangPhi == null)
                throw new Exception("Không tìm thấy bảng phí phù hợp cho độ tuổi này.");

            float phiNam = bangPhi.PhiNam;

            switch (phuongThucDong)
            {
                case "Tháng":
                    return phiNam / 12;
                case "Quý":
                    return phiNam / 4;
                case "Đóng 1 lần":
                    return phiNam;
                default:
                    throw new Exception("Phương thức đóng không hợp lệ.");
            }
        }
        public async Task<List<BangPhiBaoHiem>> GetBangPhiBaoHiemByMaGoiAsync(string maGoi)
        {
            return await dao_GoiBaoHiem.GetBangPhiBaoHiemByMaGoiAsync(maGoi);
        }
        public async Task<bool> CapNhatGoiBaoHiemAsync(string maGoi, string tenMoi, string moTaMoi)
        {
            return await dao_GoiBaoHiem.CapNhatGoiBaoHiemAsync(maGoi, tenMoi, moTaMoi);
        }
        public async Task<bool> ThemGoiBaoHiemAsync(string maGoi, string tenGoi, string moTa, List<BangPhiBaoHiem> danhSachBangPhi)
        {
            return await dao_GoiBaoHiem.ThemGoiBaoHiemAsync(maGoi, tenGoi, moTa, danhSachBangPhi);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HopDongBaoHiem
    {
        public string MaHD { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKT { get; set; }
        public string ThoiHanHopDong { get; set; }
        public string PhuongThucDong { get; set; }
        public float PhiDongDinhKi { get; set; }
        public string TrangThai { get; set; }

        public string MaKH { get; set; } 
        public string MaNTH { get; set; } 
        public string MaNV { get; set; } 
        public string MaCTBH { get; set; } 
        public string MaGoi { get; set; } 
    }

}

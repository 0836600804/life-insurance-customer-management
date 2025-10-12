using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonThanhToan
    {
        public string MaHoaDon { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public float SoTienThanhToan { get; set; }
        public string TrangThai { get; set; } 
        public int KyThanhToan { get; set; }
    }

}

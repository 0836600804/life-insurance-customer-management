using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GoiBaoHiem
    {
        public string MaGoi { get; set; }
        public string TenGoi { get; set; }
        public string MoTa { get; set; }

        public GoiBaoHiem(string maGoi, string tenGoi, string moTa)
        {
            MaGoi = maGoi;
            TenGoi = tenGoi;
            MoTa = moTa;
        }
    }
}

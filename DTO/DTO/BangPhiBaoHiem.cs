using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangPhiBaoHiem
    {
        public int DoTuoiTu { get; set; }
        public int DoTuoiDen { get; set; }
        public float PhiNam { get; set; }

        public BangPhiBaoHiem() { }

        public BangPhiBaoHiem(int doTuoiTu, int doTuoiDen, float phiNam)
        {
            DoTuoiTu = doTuoiTu;
            DoTuoiDen = doTuoiDen;
            PhiNam = phiNam;
        }
    }
}

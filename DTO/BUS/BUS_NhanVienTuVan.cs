using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NhanVienTuVan
    {
        private readonly DAO_NhanVienTuVan _daoNhanVienTuVan;

        public BUS_NhanVienTuVan(DAO_NhanVienTuVan daoNhanVienTuVan)
        {
            _daoNhanVienTuVan = daoNhanVienTuVan;
        }

        public async Task<NhanVienTuVan> DangNhapAsync(string sdt, string password)
        {
            return await _daoNhanVienTuVan.DangNhapAsync(sdt, password);
        }

        public Task<List<NhanVienTuVan>> GetAllNhanVienAsync()
        {
            return _daoNhanVienTuVan.GetDanhSachNhanVienAsync();
        }

        public Task<NhanVienTuVan> GetNhanVienByMaAsync(string maNV)
        {
            return _daoNhanVienTuVan.GetNhanVienByMaAsync(maNV);
        }
        public async Task<bool> CapNhatNhanVienAsync(NhanVienTuVan nhanVien)
        {
            return await _daoNhanVienTuVan.CapNhatNhanVienAsync(nhanVien);
        }
        public async Task<bool> XoaNhanVienAsync(string maNV)
        {
            return await _daoNhanVienTuVan.XoaNhanVienAsync(maNV);
        }
        public async Task<bool> ThemNhanVienAsync(NhanVienTuVan nv)
        {
            return await _daoNhanVienTuVan.ThemNhanVienAsync(nv);
        }

    }
}

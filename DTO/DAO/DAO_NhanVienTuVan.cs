using DTO;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_NhanVienTuVan
    {
        private readonly IDriver _driver;

        public DAO_NhanVienTuVan(ConnectNeo4j neo4jConnection)
        {
            _driver = neo4jConnection.GetDriver();
        }

        public async Task<NhanVienTuVan> DangNhapAsync(string sdt, string password)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var query = "MATCH (nv:NhanVienTuVan) WHERE nv.SDT = $sdt AND nv.pw = $password " +
                            "RETURN nv.MaNV AS MaNV, nv.TenNV AS TenNV, nv.SDT AS SDT, " +
                            "nv.Email AS Email, nv.NgaySinh AS NgaySinh, nv.pw AS Password, nv.Role AS Role, nv.TrangThai AS TrangThai";

                var result = await session.RunAsync(query, new { sdt, password });

                if (await result.FetchAsync())
                {
                    return new NhanVienTuVan(
                        result.Current["MaNV"].As<string>(),
                        result.Current["TenNV"].As<string>(),
                        result.Current["SDT"].As<string>(),
                        result.Current["Email"].As<string>(),
                        result.Current["NgaySinh"].As<string>(),
                        result.Current["Password"].As<string>(),
                        result.Current["Role"].As<string>(),
                        result.Current["TrangThai"].As<string>()
                    );
                }

                return null;
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public async Task<List<NhanVienTuVan>> GetDanhSachNhanVienAsync()
        {
            List<NhanVienTuVan> danhSach = new List<NhanVienTuVan>();
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var result = await session.RunAsync(@"
            MATCH (nv:NhanVienTuVan)
            RETURN nv.MaNV AS MaNV, nv.TenNV AS TenNV, nv.NgaySinh AS NgaySinh,
                   nv.SDT AS SDT, nv.Email AS Email, nv.Role AS Role, nv.TrangThai AS TrangThai");

                while (await result.FetchAsync())
                {
                    danhSach.Add(new NhanVienTuVan
                    {
                        MaNV = result.Current["MaNV"].As<string>(),
                        TenNV = result.Current["TenNV"].As<string>(),
                        NgaySinh = result.Current["NgaySinh"].As<string>(),
                        SDT = result.Current["SDT"].As<string>(),
                        Email = result.Current["Email"].As<string>(),
                        Role = result.Current["Role"].As<string>(),
                        TrangThai = result.Current["TrangThai"].As<string>()
                    });
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return danhSach;
        }

        public async Task<NhanVienTuVan> GetNhanVienByMaAsync(string maNV)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var result = await session.RunAsync(@"
            MATCH (nv:NhanVienTuVan {MaNV: $maNV})
            RETURN nv.MaNV AS MaNV, nv.TenNV AS TenNV, nv.NgaySinh AS NgaySinh,
                   nv.SDT AS SDT, nv.Email AS Email, nv.Role AS Role, nv.TrangThai AS TrangThai",
                    new { maNV });

                if (await result.FetchAsync())
                {
                    return new NhanVienTuVan
                    {
                        MaNV = result.Current["MaNV"].As<string>(),
                        TenNV = result.Current["TenNV"].As<string>(),
                        NgaySinh = result.Current["NgaySinh"].As<string>(),
                        SDT = result.Current["SDT"].As<string>(),
                        Email = result.Current["Email"].As<string>(),
                        Role = result.Current["Role"].As<string>(),
                        TrangThai = result.Current["TrangThai"].As<string>()
                    };
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return null;
        }
        public async Task<bool> CapNhatNhanVienAsync(NhanVienTuVan nhanVien)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
            MATCH (nv:NhanVienTuVan {MaNV: $maNV})
            SET nv.TenNV = $tenNV,
                nv.NgaySinh = $ngaySinh,
                nv.SDT = $sdt,
                nv.Email = $email,
                nv.Role = $role
            RETURN nv";

                var parameters = new
                {
                    maNV = nhanVien.MaNV,
                    tenNV = nhanVien.TenNV,
                    ngaySinh = nhanVien.NgaySinh,
                    sdt = nhanVien.SDT,
                    email = nhanVien.Email,
                    role = nhanVien.Role
                };

                var result = await session.RunAsync(query, parameters);

                return await result.FetchAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật nhân viên: " + ex.Message);
                return false;
            }
            finally
            {
                await session.CloseAsync();
            }
        }
        public async Task<bool> XoaNhanVienAsync(string maNV)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
            MATCH (nv:NhanVienTuVan {MaNV: $maNV})
            SET nv.TrangThai = '0'
            RETURN nv";

                var result = await session.RunAsync(query, new { maNV });
                return await result.FetchAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa nhân viên: " + ex.Message);
                return false;
            }
            finally
            {
                await session.CloseAsync();
            }
        }
        public async Task<bool> ThemNhanVienAsync(NhanVienTuVan nv)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
            CREATE (nv:NhanVienTuVan {
                MaNV: $MaNV,
                TenNV: $TenNV,
                NgaySinh: $NgaySinh,
                SDT: $SDT,
                Email: $Email,
                Role: $Role,
                TrangThai: 1
            })";

                var parameters = new
                {
                    nv.MaNV,
                    nv.TenNV,
                    NgaySinh = nv.NgaySinh,
                    nv.SDT,
                    nv.Email,
                    nv.Role,
                    nv.TrangThai
                };

                await session.RunAsync(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm nhân viên: " + ex.Message);
                return false;
            }
            finally
            {
                await session.CloseAsync();
            }
        }

    }
}

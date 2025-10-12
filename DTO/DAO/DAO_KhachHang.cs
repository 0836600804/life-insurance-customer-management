using DTO;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_KhachHang : IDisposable
    {
        private readonly IDriver _driver;

        public DAO_KhachHang(ConnectNeo4j neo4jConnection)
        {
            _driver = neo4jConnection.GetDriver();
        }

        public void Dispose()
        {
            // Không dispose _driver vì nó được quản lý bởi ConnectNeo4j
        }

        public async Task<List<string>> GetCustomerListAsync()
        {
            List<string> customers = new List<string>();
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var result = await session.RunAsync("MATCH (c:KhachHang) RETURN c.TenKH AS Ten");

                while (await result.FetchAsync())
                {
                    customers.Add(result.Current["Ten"].As<string>());
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return customers;
        }
        public async Task<List<KhachHang>> GetDanhSachKhachHangAsync()
        {
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var result = await session.RunAsync(@"
            MATCH (c:KhachHang) 
            RETURN c.MaKH AS MaKH, c.TenKH AS TenKH, c.CCCD AS CCCD, 
                   c.SDT AS SDT, c.DiaChi AS DiaChi");

                while (await result.FetchAsync())
                {
                    danhSachKhachHang.Add(new KhachHang
                    {
                        MaKH = result.Current["MaKH"].As<string>(),
                        TenKH = result.Current["TenKH"].As<string>(),
                        CCCD = result.Current["CCCD"].As<string>(),
                        SDT = result.Current["SDT"].As<string>(),
                        DiaChi = result.Current["DiaChi"].As<string>()
                    });
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return danhSachKhachHang;
        }


        public async Task<KhachHang> GetKhachHangByMaAsync(string maKH)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh")); 

            try
            {
                var result = await session.RunAsync(
                    "MATCH (c:KhachHang {MaKH: $maKH}) RETURN c.MaKH AS MaKH, c.TenKH AS TenKH, c.NgaySinh AS NgaySinh, " +
                    "c.SDT AS SDT, c.Email AS Email, c.DiaChi AS DiaChi, c.CCCD AS CCCD, c.NgheNghiep AS NgheNghiep",
                    new { maKH });

                if (await result.FetchAsync())
                {
                    return new KhachHang
                    {
                        MaKH = result.Current["MaKH"].As<string>(),
                        TenKH = result.Current["TenKH"].As<string>(),
                        NgaySinh = result.Current["NgaySinh"].As<DateTime>(),
                        SDT = result.Current["SDT"].As<string>(),
                        Email = result.Current["Email"].As<string>(),
                        DiaChi = result.Current["DiaChi"].As<string>(),
                        CCCD = result.Current["CCCD"].As<string>(),
                        NgheNghiep = result.Current["NgheNghiep"].As<string>()
                    };
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return null;
        }

        public async Task<KhachHang> GetKhachHangByMaHDAsync(string maHD)
        {
            KhachHang khachHang = null;
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var query = @"
            MATCH (kh:KhachHang)-[:ky_ket]->(hd:HopDongBaoHiem {MaHD: $maHD})
            RETURN kh.MaKH AS MaKH, kh.TenKH AS TenKH, kh.NgaySinh AS NgaySinh, 
                   kh.SDT AS SDT, kh.Email AS Email, kh.DiaChi AS DiaChi, kh.CCCD AS CCCD
        ";

                var result = await session.RunAsync(query, new { maHD });

                if (await result.FetchAsync())
                {
                    khachHang = new KhachHang
                    {
                        MaKH = result.Current["MaKH"].As<string>(),
                        TenKH = result.Current["TenKH"].As<string>(),
                        NgaySinh = result.Current["NgaySinh"].As<DateTime>(), 
                        SDT = result.Current["SDT"].As<string>(),
                        Email = result.Current["Email"].As<string>(),
                        DiaChi = result.Current["DiaChi"].As<string>(),
                        CCCD = result.Current["CCCD"].As<string>()
                    };
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return khachHang;
        }


        public async Task<bool> ThemKhachHangAsync(KhachHang kh)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));
            try
            {
                string query = @"
            CREATE (c:KhachHang {
                MaKH: $MaKH,
                TenKH: $TenKH,
                NgaySinh: date($NgaySinh),
                SDT: $SDT,
                Email: $Email,
                DiaChi: $DiaChi,
                CCCD: $CCCD
            })";

                var parameters = new
                {
                    MaKH = kh.MaKH,
                    TenKH = kh.TenKH,
                    NgaySinh = kh.NgaySinh.ToString("yyyy-MM-dd"),
                    SDT = kh.SDT,
                    Email = kh.Email,
                    DiaChi = kh.DiaChi,
                    CCCD = kh.CCCD
                };

                await session.RunAsync(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                return false;
            }
            finally
            {
                await session.CloseAsync();
            }
        }
        public async Task<bool> CapNhatKhachHangAsync(KhachHang khachHang)
        {
            bool success = false;
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var query = @"
            MATCH (kh:KhachHang {MaKH: $MaKH})
            SET kh.TenKH = $TenKH,
                kh.NgaySinh = $NgaySinh,
                kh.SDT = $SDT,
                kh.Email = $Email,
                kh.DiaChi = $DiaChi,
                kh.CCCD = $CCCD,
                kh.NgheNghiep = $NgheNghiep
            RETURN kh";

                var parameters = new
                {
                    MaKH = khachHang.MaKH,
                    TenKH = khachHang.TenKH,
                    NgaySinh = khachHang.NgaySinh.ToString("yyyy-MM-dd"),
                    SDT = khachHang.SDT,
                    Email = khachHang.Email,
                    DiaChi = khachHang.DiaChi,
                    CCCD = khachHang.CCCD,
                    NgheNghiep = khachHang.NgheNghiep
                };

                var result = await session.RunAsync(query, parameters);
                success = await result.FetchAsync(); 
            }
            finally
            {
                await session.CloseAsync();
            }

            return success;
        }
    }
}

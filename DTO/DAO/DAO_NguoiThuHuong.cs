using DTO;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_NguoiThuHuong : IDisposable
    {
        private readonly IDriver _driver;

        public DAO_NguoiThuHuong(ConnectNeo4j neo4jConnection)
        {
            _driver = neo4jConnection.GetDriver();
        }

        public void Dispose()
        {
            // Không dispose _driver vì nó được quản lý bởi ConnectNeo4j
        }

        public async Task<bool> ThemNguoiThuHuongAsync(NguoiThuHuong nth)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var result = await session.RunAsync(
                    "CREATE (n:NguoiThuHuong {MaNTH: $MaNTH, TenNTH: $TenNTH, SDT: $SDT, CCCD: $CCCD, DiaChi: $DiaChi, NgheNghiep: $NgheNghiep})",
                    new
                    {
                        MaNTH = nth.MaNTH,
                        TenNTH = nth.TenNTH,
                        SDT = nth.SDT,
                        CCCD = nth.CCCD,
                        DiaChi = nth.DiaChi,
                        NgheNghiep = nth.NgheNghiep
                    });

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false; 
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public async Task<NguoiThuHuong> GetNguoiThuHuongByMaHDAsync(string maHD)
        {
            NguoiThuHuong nguoiThuHuong = null;
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var query = @"
            MATCH (nth:NguoiThuHuong)<-[:bao_hiem_cho]-(hd:HopDongBaoHiem {MaHD: $maHD})
            RETURN nth.MaNTH AS MaNTH, nth.TenNTH AS TenNTH, nth.SDT AS SDT, 
                   nth.CCCD AS CCCD, nth.DiaChi AS DiaChi, nth.NgheNghiep AS NgheNghiep
        ";

                var result = await session.RunAsync(query, new { maHD });

                if (await result.FetchAsync())
                {
                    nguoiThuHuong = new NguoiThuHuong
                    {
                        MaNTH = result.Current["MaNTH"].As<string>(),
                        TenNTH = result.Current["TenNTH"].As<string>(),
                        SDT = result.Current["SDT"].As<string>(),
                        CCCD = result.Current["CCCD"].As<string>(),
                        DiaChi = result.Current["DiaChi"].As<string>(),
                        NgheNghiep = result.Current["NgheNghiep"].As<string>()
                    };
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return nguoiThuHuong;
        }
        public async Task<bool> CapNhatNguoiThuHuongAsync(NguoiThuHuong nth)
        {
            bool success = false;
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var query = @"
            MATCH (nth:NguoiThuHuong {MaNTH: $MaNTH})
            SET nth.TenNTH = $TenNTH,
                nth.SDT = $SDT,
                nth.CCCD = $CCCD,
                nth.DiaChi = $DiaChi,
                nth.NgheNghiep = $NgheNghiep
            RETURN nth";

                var parameters = new
                {
                    MaNTH = nth.MaNTH,
                    TenNTH = nth.TenNTH,
                    SDT = nth.SDT,
                    CCCD = nth.CCCD,
                    DiaChi = nth.DiaChi,
                    NgheNghiep = nth.NgheNghiep
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

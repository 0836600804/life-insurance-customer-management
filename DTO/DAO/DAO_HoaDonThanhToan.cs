using DTO;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_HoaDonThanhToan
    {
        private readonly IDriver _driver;

        public DAO_HoaDonThanhToan(ConnectNeo4j neo4jConnection)
        {
            _driver = neo4jConnection.GetDriver();
        }

        public async Task<bool> ThemHoaDonThanhToanAsync(string maHD, HoaDonThanhToan hoaDon)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
            MATCH (hd:HopDongBaoHiem {MaHD: $maHD})
            CREATE (h:HoaDonThanhToan {
                MaHoaDon: $maHoaDon,
                NgayThanhToan: $ngayThanhToan,
                SoTienThanhToan: $soTienThanhToan,
                TrangThai: $trangThai,
                KyThanhToan: $KyThanhToan
            })
            MERGE (hd)-[:CO_HOA_DON]->(h)";

                var parameters = new
                {
                    maHD = maHD,
                    maHoaDon = hoaDon.MaHoaDon,
                    ngayThanhToan = hoaDon.NgayThanhToan.ToString("yyyy-MM-dd"),
                    soTienThanhToan = hoaDon.SoTienThanhToan,
                    trangThai = hoaDon.TrangThai,
                    hoaDon.KyThanhToan
                };

                await session.RunAsync(query, parameters);
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

        //public async Task<List<HoaDonThanhToan>> GetHoaDonByMaHDAsync(string maHD)
        //{
        //    List<HoaDonThanhToan> danhSachHoaDon = new List<HoaDonThanhToan>();
        //    var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

        //    try
        //    {
        //        string query = @"
        //    MATCH (hd:HopDongBaoHiem {MaHD: $maHD})-[:CO_HOA_DON]->(h:HoaDonThanhToan)
        //    RETURN h.MaHoaDon AS MaHoaDon, 
        //           h.NgayThanhToan AS NgayThanhToan, 
        //           h.SoTienThanhToan AS SoTienThanhToan, 
        //           h.TrangThai AS TrangThai,
        //           h.kyThanhToan AS KyThanhToan";

        //        var result = await session.RunAsync(query, new { maHD });

        //        while (await result.FetchAsync())
        //        {
        //            danhSachHoaDon.Add(new HoaDonThanhToan

        //            {
        //                MaHoaDon = result.Current["MaHoaDon"].As<string>(),
        //                NgayThanhToan = DateTime.Parse(result.Current["NgayThanhToan"].As<string>()),
        //                SoTienThanhToan = float.Parse(result.Current["SoTienThanhToan"].As<string>()),
        //                TrangThai = result.Current["TrangThai"].As<string>(),
        //                KyThanhToan = int.Parse(result.Current["KyThanhToan"].As<string>())
        //            });

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //    finally
        //    {
        //        await session.CloseAsync();
        //    }

        //    return danhSachHoaDon;
        //}
        public async Task<List<HoaDonThanhToan>> GetHoaDonByMaHDAsync(string maHD)
        {
            List<HoaDonThanhToan> danhSachHoaDon = new List<HoaDonThanhToan>();
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
        MATCH (hd:HopDongBaoHiem {MaHD: $maHD})-[:CO_HOA_DON]->(h:HoaDonThanhToan)
        RETURN h.MaHoaDon AS MaHoaDon, 
               h.NgayThanhToan AS NgayThanhToan, 
               h.SoTienThanhToan AS SoTienThanhToan, 
               h.TrangThai AS TrangThai,
               h.KyThanhToan AS KyThanhToan"; // Đúng tên KyThanhToan

                var result = await session.RunAsync(query, new { maHD });

                while (await result.FetchAsync())
                {
                    var hoaDon = new HoaDonThanhToan
                    {
                        MaHoaDon = result.Current["MaHoaDon"].As<string>(),
                        NgayThanhToan = result.Current["NgayThanhToan"].As<DateTime>(), 
                        SoTienThanhToan = result.Current["SoTienThanhToan"].As<float>(), 
                        TrangThai = result.Current["TrangThai"].As<string>(),
                        KyThanhToan = result.Current["KyThanhToan"].As<int>() 
                    };

                    danhSachHoaDon.Add(hoaDon);

                    Console.WriteLine($"[Debug] Hóa đơn nhận được: {hoaDon.MaHoaDon} - {hoaDon.NgayThanhToan} - {hoaDon.SoTienThanhToan}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu từ Neo4j: " + ex.Message);
            }
            finally
            {
                await session.CloseAsync();
            }

            Console.WriteLine($"Tổng số hóa đơn lấy được: {danhSachHoaDon.Count}");
            return danhSachHoaDon;
        }

    }
}

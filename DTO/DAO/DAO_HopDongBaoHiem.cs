using DTO;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_HopDongBaoHiem
    {
        private readonly IDriver _driver;

        public DAO_HopDongBaoHiem(ConnectNeo4j neo4jConnection)
        {
            _driver = neo4jConnection.GetDriver();
        }
        public async Task<List<HopDongBaoHiem>> GetDanhSachHopDongAsync()
        {
            List<HopDongBaoHiem> danhSachHopDong = new List<HopDongBaoHiem>();
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
            MATCH (hd:HopDongBaoHiem)
            RETURN hd.MaHD AS MaHD, hd.NgayBatDau AS NgayBatDau, 
                   hd.NgayKT AS NgayKT, hd.ThoiHanHopDong AS ThoiHan, 
                   hd.PhuongThucDong AS PhuongThucDong, 
                   hd.PhiDongDinhKi AS PhiDongDinhKy, hd.TrangThai AS TrangThai";

                var result = await session.RunAsync(query);

                while (await result.FetchAsync())
                {
                    danhSachHopDong.Add(new HopDongBaoHiem
                    {
                        MaHD = result.Current["MaHD"].As<string>(),
                        NgayBatDau = DateTime.Parse(result.Current["NgayBatDau"].As<string>()),
                        NgayKT = DateTime.Parse(result.Current["NgayKT"].As<string>()),
                        ThoiHanHopDong = result.Current["ThoiHan"].As<string>(),
                        PhuongThucDong = result.Current["PhuongThucDong"].As<string>(),
                        PhiDongDinhKi = result.Current["PhiDongDinhKy"].As<float>(),
                        TrangThai = result.Current["TrangThai"].As<string>()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hợp đồng: " + ex.Message);
            }
            finally
            {
                await session.CloseAsync();
            }

            return danhSachHopDong;
        }


        public async Task<bool> ThemHopDongAsync(HopDongBaoHiem hd)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var query = @"
                CREATE (hd:HopDongBaoHiem {
                    MaHD: $MaHD, NgayBatDau: date($NgayBatDau), NgayKT: date($NgayKT) ,
                    ThoiHanHopDong: $ThoiHanHopDong, PhuongThucDong: $PhuongThucDong,
                    PhiDongDinhKi: $PhiDongDinhKi, TrangThai: $TrangThai
                })
                WITH hd
                MATCH (kh:KhachHang {MaKH: $MaKH})
                CREATE (kh)-[:`ky_ket`]->(hd)
                
                WITH hd
                OPTIONAL MATCH (nth:NguoiThuHuong {MaNTH: $MaNTH})
                CREATE (hd)-[:`bao_hiem_cho`]->(nth)
                
                WITH hd
                MATCH (nv:NhanVienTuVan {MaNV: $MaNV})
                CREATE (hd)-[:`duoc_phu_trach_boi`]->(nv)

                WITH hd
                MATCH (ctbh:CongTyBaoHiem {TenCT: $MaCTBH})
                CREATE (hd)-[:`cung_cap_boi`]->(ctbh)

                WITH hd
                MATCH (goi:GoiBaoHiem {MaGoi: $MaGoi})
                CREATE (hd)-[:`dua_tren`]->(goi)
            ";

                var parameters = new
                {
                    MaHD = hd.MaHD,
                    NgayBatDau = hd.NgayBatDau.ToString("yyyy-MM-dd"),
                    NgayKT = hd.NgayKT.ToString("yyyy-MM-dd"),
                    ThoiHanHopDong = hd.ThoiHanHopDong,
                    PhuongThucDong = hd.PhuongThucDong,
                    PhiDongDinhKi = hd.PhiDongDinhKi,
                    TrangThai = hd.TrangThai,
                    MaKH = hd.MaKH,
                    MaNTH = hd.MaNTH,
                    MaNV = hd.MaNV,
                    MaCTBH = hd.MaCTBH,
                    MaGoi = hd.MaGoi
                };

                await session.RunAsync(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hợp đồng: " + ex.Message);
                return false;
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public async Task<List<HopDongBaoHiem>> GetDanhSachHopDongChuaThanhToanAsync()
        {
            List<HopDongBaoHiem> danhSach = new List<HopDongBaoHiem>();
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var query = @"
            MATCH (hd:HopDongBaoHiem)
            WHERE NOT EXISTS {
                MATCH (hd)-[:CO_HOA_DON]->(hdt)
                WHERE 
                    (hd.PhuongThucDong = 'Tháng' AND hdt.NgayThanhToan >= date() - duration({months: 1})) OR
                    (hd.PhuongThucDong = 'Quý' AND hdt.NgayThanhToan >= date() - duration({months: 3})) OR
                    (hd.PhuongThucDong = 'Đóng 1 lần' AND hdt.NgayThanhToan IS NOT NULL)
            }
            RETURN hd.MaHD AS MaHD, hd.NgayBatDau AS NgayBatDau, 
                   hd.NgayKT AS NgayKT, hd.ThoiHanHopDong AS ThoiHanHopDong, 
                   hd.PhuongThucDong AS PhuongThucDong, hd.PhiDongDinhKi AS PhiDongDinhKi,
                   hd.TrangThai AS TrangThai";

                var result = await session.RunAsync(query);

                while (await result.FetchAsync())
                {
                    danhSach.Add(new HopDongBaoHiem
                    {
                        MaHD = result.Current["MaHD"].As<string>(),
                        NgayBatDau = result.Current["NgayBatDau"].As<DateTime>(),
                        NgayKT = result.Current["NgayKT"].As<DateTime>(),
                        ThoiHanHopDong = result.Current["ThoiHanHopDong"].As<string>(),
                        PhuongThucDong = result.Current["PhuongThucDong"].As<string>(),
                        PhiDongDinhKi = result.Current["PhiDongDinhKi"].As<float>(),
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
        public async Task<bool> CapNhatTrangThaiHopDongAsync(string maHD, string trangThaiMoi)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
            MATCH (hd:HopDongBaoHiem {MaHD: $maHD})
            SET hd.TrangThai = $trangThaiMoi
            RETURN hd";

                var result = await session.RunAsync(query, new { maHD, trangThaiMoi });

                return await result.FetchAsync(); // Nếu có kết quả thì cập nhật thành công
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
        public async Task<int> DemSoHoaDonTheoHopDongAsync(string maHD)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
        MATCH (:HopDongBaoHiem {MaHD: $maHD})-[:CO_HOA_DON]->(h:HoaDonThanhToan)
        RETURN COUNT(h) AS SoLuongHoaDon";

                var result = await session.RunAsync(query, new { maHD });

                var record = await result.SingleAsync();
                return record["SoLuongHoaDon"].As<int>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return -1; // Trả về -1 nếu lỗi
            }
            finally
            {
                await session.CloseAsync();
            }
        }
        public async Task<int> LayKyThanhToanTiepTheoAsync(string maHD)
        {
            int soHoaDon = await DemSoHoaDonTheoHopDongAsync(maHD);
            return (soHoaDon >= 0) ? soHoaDon + 1 : 1; 
        }
    }

}

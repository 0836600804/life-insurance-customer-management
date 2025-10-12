using DTO;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_GoiBaoHiem : IDisposable
    {
        private readonly IDriver _driver;

        public DAO_GoiBaoHiem(ConnectNeo4j neo4jConnection)
        {
            _driver = neo4jConnection.GetDriver();
        }

        public void Dispose()
        {
        }

        public async Task<List<GoiBaoHiem>> GetGoiBaoHiemListAsync()
        {
            List<GoiBaoHiem> goiBaoHiemList = new List<GoiBaoHiem>();
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh")); 

            try
            {
                var result = await session.RunAsync("MATCH (c:GoiBaoHiem) RETURN c.MaGoi AS MaGoi, c.TenGoi AS TenGoi, c.MoTa AS MoTa");

                while (await result.FetchAsync())
                {
                    string maGoi = result.Current["MaGoi"].As<string>();
                    string tenGoi = result.Current["TenGoi"].As<string>();
                    string moTa = result.Current["MoTa"].As<string>();
                    goiBaoHiemList.Add(new GoiBaoHiem(maGoi, tenGoi, moTa)); 
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return goiBaoHiemList;
        }

        public async Task<BangPhiBaoHiem> GetBangPhiBaoHiemByTuoiAsync(string maGoi, int tuoi)
        {
            BangPhiBaoHiem bangPhi = null;
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                var query = @"
            MATCH (gbh:GoiBaoHiem {MaGoi: $maGoi})-[:CO_BANG_PHI]->(bp:BangPhiBaoHiem)
            WHERE bp.DoTuoiTu <= $tuoi AND bp.DoTuoiDen > $tuoi
            RETURN bp.DoTuoiTu AS DoTuoiTu, bp.DoTuoiDen AS DoTuoiDen, bp.PhiNam AS PhiNam
            LIMIT 1
        ";

                var result = await session.RunAsync(query, new { maGoi, tuoi });

                if (await result.FetchAsync())
                {
                    bangPhi = new BangPhiBaoHiem
                    {
                        DoTuoiTu = result.Current["DoTuoiTu"].As<int>(),
                        DoTuoiDen = result.Current["DoTuoiDen"].As<int>(),
                        PhiNam = result.Current["PhiNam"].As<float>()
                    };
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return bangPhi;
        }
        public async Task<List<BangPhiBaoHiem>> GetBangPhiBaoHiemByMaGoiAsync(string maGoi)
        {
            List<BangPhiBaoHiem> danhSach = new List<BangPhiBaoHiem>();
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
            MATCH (g:GoiBaoHiem {MaGoi: $maGoi})-[:CO_BANG_PHI]->(bp:BangPhiBaoHiem)
            RETURN bp.DoTuoiTu AS DoTuoiTu, bp.DoTuoiDen AS DoTuoiDen, bp.PhiNam AS PhiNam
            ORDER BY bp.DoTuoiTu ASC";

                var result = await session.RunAsync(query, new { maGoi });

                while (await result.FetchAsync())
                {
                    danhSach.Add(new BangPhiBaoHiem
                    {
                        DoTuoiTu = result.Current["DoTuoiTu"].As<int>(),
                        DoTuoiDen = result.Current["DoTuoiDen"].As<int>(),
                        PhiNam = result.Current["PhiNam"].As<float>()
                    });
                }
            }
            finally
            {
                await session.CloseAsync();
            }

            return danhSach;
        }
        public async Task<bool> CapNhatGoiBaoHiemAsync(string maGoi, string tenMoi, string moTaMoi)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string query = @"
            MATCH (g:GoiBaoHiem {MaGoi: $maGoi})
            SET g.TenGoi = $tenMoi, g.MoTa = $moTaMoi
            RETURN g";

                var result = await session.RunAsync(query, new { maGoi, tenMoi, moTaMoi });

                return await result.FetchAsync(); // Trả về true nếu cập nhật thành công
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
        public async Task<bool> ThemGoiBaoHiemAsync(string maGoi, string tenGoi, string moTa, List<BangPhiBaoHiem> danhSachBangPhi)
        {
            var session = _driver.AsyncSession(o => o.WithDatabase("qlbh"));

            try
            {
                string queryGoiBaoHiem = @"
            CREATE (g:GoiBaoHiem {MaGoi: $maGoi, TenGoi: $tenGoi, MoTa: $moTa})
            RETURN g";

                var resultGoiBaoHiem = await session.RunAsync(queryGoiBaoHiem, new { maGoi, tenGoi, moTa });

                if (!await resultGoiBaoHiem.FetchAsync())
                {
                    return false; 
                }

                foreach (var bangPhi in danhSachBangPhi)
                {
                    string queryBangPhi = @"
                MATCH (g:GoiBaoHiem {MaGoi: $maGoi})
                CREATE (bp:BangPhiBaoHiem {DoTuoiTu: $doTuoiTu, DoTuoiDen: $doTuoiDen, PhiNam: $phiNam})
                CREATE (g)-[:CO_BANG_PHI]->(bp)";

                    await session.RunAsync(queryBangPhi, new
                    {
                        maGoi,
                        doTuoiTu = bangPhi.DoTuoiTu,
                        doTuoiDen = bangPhi.DoTuoiDen,
                        phiNam = bangPhi.PhiNam
                    });
                }

                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm gói bảo hiểm: " + ex.Message);
                return false;
            }
            finally
            {
                await session.CloseAsync();
            }
        }

    }
}

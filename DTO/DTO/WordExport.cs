using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace DTO
{
    public class WordExporter
    {
        //public static void XuatHoaDonTuMau(HoaDonThanhToan hoaDon, KhachHang khachHang, HopDongBaoHiem hopDong, string filePath)
        //{
        //    Word.Application wordApp = new Word.Application();
        //    Word.Document doc = wordApp.Documents.Open(filePath);

        //    try
        //    {
        //        // Dữ liệu thay thế
        //        Dictionary<string, string> mergeFields = new Dictionary<string, string>
        //{
        //    { "{MaHD}", hoaDon.MaHoaDon },
        //    { "{tenKH}", khachHang.TenKH },
        //    { "{cccd}", khachHang.CCCD },
        //    { "{sdt}", khachHang.SDT },
        //    { "{dchi}", khachHang.DiaChi },
        //    { "{maHopDong}", hopDong.MaHD },
        //    { "{tengoi}", hopDong.MaGoi },
        //    { "{thoihan}", hopDong.ThoiHanHopDong + " năm" },
        //    { "{phuongthuc}", hopDong.PhuongThucDong },
        //    { "{sotiendong}", hoaDon.SoTienThanhToan.ToString("N0") + " VND" },
        //    { "{ngaydong}", hoaDon.NgayThanhToan.ToString("dd/MM/yyyy") },
        //    { "{SoTienBangChu}", DocSoThanhChu(hoaDon.SoTienThanhToan) }
        //};

        //        // Tìm & thay thế từng placeholder trong văn bản Word
        //        foreach (var item in mergeFields)
        //        {
        //            Word.Find findObject = wordApp.Selection.Find;
        //            findObject.Text = item.Key;
        //            findObject.Replacement.Text = item.Value;

        //            object replaceAll = Word.WdReplace.wdReplaceAll;
        //            findObject.Execute(Replace: ref replaceAll);
        //        }

        //        // Lưu đè lên file gốc
        //       // doc.Save();
        //        doc.Close();

        //        // Mở lại file sau khi sửa
        //        wordApp.Visible = true;
        //        wordApp.Documents.Open(filePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        doc.Close();
        //        wordApp.Quit();
        //        throw new Exception("Lỗi khi xuất hóa đơn: " + ex.Message);
        //    }
        //}
        public static void XuatHoaDonTuMau(NhanVienTuVan nv, HoaDonThanhToan hoaDon, KhachHang khachHang, HopDongBaoHiem hopDong, string templatePath, string outputFolder)
        {
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string newFilePath = Path.Combine(outputFolder, $"HoaDon_{hoaDon.MaHoaDon}.docx");

            File.Copy(templatePath, newFilePath, true);

            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Open(newFilePath);

            DateTime today = DateTime.Now;
            string ngayHienTai = $"Ngày {today.Day} tháng {today.Month} năm {today.Year}";

            try
            {
                // Dữ liệu thay thế
                Dictionary<string, string> mergeFields = new Dictionary<string, string>
        {
            { "{nhanvien}", nv.TenNV },
            { "{MaHD}", hoaDon.MaHoaDon },
            { "{tenKH}", khachHang.TenKH },
            { "{cccd}", khachHang.CCCD },
            { "{sdt}", khachHang.SDT },
            { "{dchi}", khachHang.DiaChi },
            { "{maHopDong}", hopDong.MaHD },
            { "{tengoi}", hopDong.MaGoi },
            { "{thoihan}", hopDong.ThoiHanHopDong + " năm" },
            { "{phuongthuc}", hopDong.PhuongThucDong },
            { "{sotiendong}", hoaDon.SoTienThanhToan.ToString("N0") + " VND" },
            { "{ngaydong}", hoaDon.NgayThanhToan.ToString("dd/MM/yyyy") },
            { "{maKy}", hoaDon.KyThanhToan.ToString() },
            { "{SoTienBangChu}", DocSoThanhChu(hoaDon.SoTienThanhToan) },
            { "Ngày…. tháng…. năm 2025", ngayHienTai }
        };

                foreach (var item in mergeFields)
                {
                    Word.Find findObject = wordApp.Selection.Find;
                    findObject.Text = item.Key;
                    findObject.Replacement.Text = item.Value;

                    object replaceAll = Word.WdReplace.wdReplaceAll;
                    findObject.Execute(Replace: ref replaceAll);
                }

                doc.Save();
                doc.Close();

                wordApp.Visible = true;
                wordApp.Documents.Open(newFilePath);
            }
            catch (Exception ex)
            {
                doc.Close();
                wordApp.Quit();
                throw new Exception("Lỗi khi xuất hóa đơn: " + ex.Message);
            }
        }


        private static string DocSoThanhChu(float number)
        {
            return number + " đồng"; 
        }
    }
}

using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Invoice
{
    public partial class frmCreateInvoices : Form
    {
        private NhanVienTuVan nhanVien;
        private BUS_HopDongBaoHiem busHopDong;
        private BUS_KhachHang busKhachHang;
        private BUS_HoaDonThanhToan busHoaDon;
        public frmCreateInvoices(NhanVienTuVan nv)
        {
            InitializeComponent();
            this.nhanVien = nv;
            busHopDong = new BUS_HopDongBaoHiem(new DAO_HopDongBaoHiem(new ConnectNeo4j()));
            busKhachHang = new BUS_KhachHang(new DAO_KhachHang(new ConnectNeo4j()));
            busHoaDon = new BUS_HoaDonThanhToan(new DAO_HoaDonThanhToan(new ConnectNeo4j()));

            SetupDataGridViewHD();
            LoadDanhSachHopDongChuaThanhToan();
        }
        private void SetupDataGridViewHD()
        {
            // Tạo cột Button "In"
            DataGridViewButtonColumn btnIn = new DataGridViewButtonColumn();
            btnIn.HeaderText = "In Hóa Đơn";
            btnIn.Name = "btnIn";
            btnIn.Text = "In";
            btnIn.UseColumnTextForButtonValue = true;
            dgv_hoadontheohd.Columns.Add(btnIn);

            dgv_hoadontheohd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private async void LoadDanhSachHopDongChuaThanhToan()
        {
            List<HopDongBaoHiem> danhSach = await busHopDong.GetDanhSachHopDongChuaThanhToanAsync();

            foreach (var hd in danhSach)
            {
                dgv_ganhandong.Rows.Add(hd.MaHD, hd.NgayBatDau.ToString("dd/MM/yyyy"), hd.NgayKT.ToString("dd/MM/yyyy"),
                                            hd.ThoiHanHopDong, hd.PhuongThucDong, hd.PhiDongDinhKi, hd.TrangThai);
            }
        }
        string maKH = "";
        KhachHang khprint = new KhachHang();
        HopDongBaoHiem hdongPrint = new HopDongBaoHiem();
        string maHD = "";
        float phihd = 0;
        private async void dgv_ganhandong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dữ liệu hợp đồng
            DataGridViewRow row = dgv_ganhandong.Rows[e.RowIndex];
            //dữ liệu KH
            maHD = row.Cells["MaHD"].Value?.ToString(); 
            phihd = (float)row.Cells["PhiDongDinhKi"].Value;
            txt_phi.Text = phihd.ToString("N0");
            txt_mahd.Text = row.Cells["MaHD"].Value?.ToString();
            hdongPrint.MaHD = row.Cells["MaHD"].Value?.ToString();
            string ngayBatDau = row.Cells["NgayBatDau"].Value.ToString();

            //hdongPrint.NgayBatDau = (DateTime)row.Cells["NgaySinh"].Value;

            //hdongPrint.NgayKT = (DateTime)row.Cells["NgayKT"].Value;
            hdongPrint.PhiDongDinhKi = (float)row.Cells["PhiDongDinhKi"].Value;
            hdongPrint.PhuongThucDong = row.Cells["PhuongThucDong"].Value?.ToString();
            hdongPrint.ThoiHanHopDong = row.Cells["ThoiHanHopDong"].Value?.ToString();
            hdongPrint.TrangThai = row.Cells["TrangThai"].Value?.ToString();

            if (!string.IsNullOrEmpty(maHD))
            {
                KhachHang kh = await busKhachHang.GetKhachHangByMaHDAsync(maHD);

                if (kh != null)
                {
                    //txtMaKH.Text = kh.MaKH;
                    maKH = kh.MaKH;
                    txt_tenkh.Text = kh.TenKH;
                    khprint.TenKH = kh.TenKH;
                    //dp_ns.Text = kh.NgaySinh.ToString();
                    txt_sdt.Text = kh.SDT;
                    khprint.CCCD = kh.CCCD;
                    khprint.Email = kh.Email;
                    khprint.DiaChi = kh.DiaChi;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            LoadHoaDonTheoHopDong();
        }
        string mahoadon = "";
        float phitt = 0;
        HoaDonThanhToan hoadonPrint = new HoaDonThanhToan();
        private async void btn_themthanhtoan_Click(object sender, EventArgs e)
        {
            int kyThanhToan = await busHopDong.LayKyThanhToanTiepTheoAsync(maHD);
            HoaDonThanhToan hoaDon = new HoaDonThanhToan
            {
                MaHoaDon = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                NgayThanhToan = DateTime.Now,
                SoTienThanhToan = phihd,
                TrangThai = "Đã thanh toán",
                KyThanhToan = kyThanhToan
            };
            hoadonPrint = hoaDon;
            mahoadon = hoaDon.MaHoaDon;
            phitt = hoaDon.SoTienThanhToan;

            bool success = await busHoaDon.ThemHoaDonThanhToanAsync(maHD, hoaDon);

            if (success)
            {
                MessageBox.Show("Thêm hóa đơn thành công!");
                LoadDanhSachHopDongChuaThanhToan(); 
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại!");
            }
        }

        private async void LoadHoaDonTheoHopDong()
        {
            string maHD = txt_mahd.Text.Trim();

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập Mã Hợp Đồng!");
                return;
            }

            dgv_hoadontheohd.Rows.Clear();

            List<HoaDonThanhToan> danhSachHoaDon = await busHoaDon.GetHoaDonByMaHDAsync("HD638780690855137712");

            MessageBox.Show("Số hóa đơn: " + danhSachHoaDon.Count);

            foreach (var hoaDon in danhSachHoaDon)
            {
                dgv_hoadontheohd.Rows.Add(
                    hoaDon.KyThanhToan.ToString(),
                    hoaDon.MaHoaDon,
                    hoaDon.NgayThanhToan.ToString("dd/MM/yyyy"),
                    hoaDon.SoTienThanhToan.ToString("N0"),
                    hoaDon.TrangThai
                );
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            HopDongBaoHiem hopDong = new HopDongBaoHiem
            {
                MaHD = "HD789012",
                MaGoi = "Bảo hiểm tử kỳ",
                ThoiHanHopDong = "10",
                PhuongThucDong = "Đóng theo năm"
            };

            string templatePath = @"E:\HK8\Winform\HoaDon.docx";
            string outputFolder = @"E:\HK8\Winform\HoaDon_Xuat\";

            //WordExporter.XuatHoaDonTuMau(hoadonPrint, khprint, hopDong, templatePath, outputFolder);

            MessageBox.Show($"Xuất hóa đơn thành công!\nFile đã được tạo: HoaDon_{hoadonPrint.MaHoaDon}.docx");
        }

        private void dgv_hoadontheohd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_hoadontheohd.Rows[e.RowIndex];
            HoaDonThanhToan hdon = new HoaDonThanhToan();
            if (e.ColumnIndex >= 0 && dgv_hoadontheohd.Columns[e.ColumnIndex].Name == "btnIn" && e.RowIndex >= 0)
            {
                hdon.MaHoaDon = row.Cells["MaHoaDonn"].Value?.ToString();
                string ngayThanhToanStr = row.Cells["NgayThanhToan"].Value?.ToString();

                if (DateTime.TryParseExact(ngayThanhToanStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngayThanhToan))
                {
                    hdon.NgayThanhToan = ngayThanhToan;

                }
                string soTienStr = row.Cells["SoTienThanhToan"].Value?.ToString();
                if (float.TryParse(soTienStr, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out float soTien))
                {
                    hdon.SoTienThanhToan = soTien;
                }
                hdon.TrangThai = row.Cells["TrangThaiHoaDon"].Value.ToString();

                if (row.Cells["KyThanhToan"].Value != null && row.Cells["KyThanhToan"].Value != DBNull.Value)
                {
                    hdon.KyThanhToan = Convert.ToInt32(row.Cells["KyThanhToan"].Value);
                }

                string templatePath = @"E:\HK8\Winform\HoaDon.docx";
                string outputFolder = @"E:\HK8\Winform\HoaDon_Xuat\";

                WordExporter.XuatHoaDonTuMau(nhanVien, hdon, khprint, hdongPrint, templatePath, outputFolder);

                MessageBox.Show($"Xuất hóa đơn thành công!\nFile đã được tạo: HoaDon_{hdon.MaHoaDon}.docx");
            }    
        }
    }
}

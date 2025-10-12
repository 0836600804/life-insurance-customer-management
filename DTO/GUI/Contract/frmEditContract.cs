using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Contract
{
    public partial class frmEditContract : Form
    {
        private BUS_HopDongBaoHiem busHopDongBaoHiem;
        private BUS_KhachHang busKhachHang;
        private BUS_NguoiThuHuong busThuHuong;
        public frmEditContract()
        {
            InitializeComponent();
            busHopDongBaoHiem = new BUS_HopDongBaoHiem(new DAO_HopDongBaoHiem(new ConnectNeo4j()));
            busKhachHang = new BUS_KhachHang(new DAO_KhachHang(new ConnectNeo4j()));
            busThuHuong = new BUS_NguoiThuHuong(new DAO_NguoiThuHuong(new ConnectNeo4j()));

            //init
            LoadGoiBaoHiemToComboBox();
            LoadThoiHanHD();
            LoadPhuongThucDong();
            cbo_trangthai.DataSource = new List<string> { "Đang hiệu lực", "Hết hạn", "Vô hiệu hóa", "Đóng phí trễ hạn", "đã duyệt" };
        }

        private void SetupDataGridView()
        {
            drg_hd.Columns.Clear(); 

            drg_hd.Columns.Add("MaHD", "Mã Hợp Đồng");
            drg_hd.Columns.Add("NgayBatDau", "Ngày Bắt Đầu");
            drg_hd.Columns.Add("NgayKT", "Ngày Kết Thúc");
            drg_hd.Columns.Add("ThoiHanHopDong", "Thời Hạn Hợp Đồng");
            drg_hd.Columns.Add("PhuongThucDong", "Phương Thức Đóng");
            drg_hd.Columns.Add("PhiDongDinhKi", "Phí Đóng Định Kỳ");
            drg_hd.Columns.Add("TrangThai", "Trạng Thái");

            drg_hd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private async void LoadGoiBaoHiemToComboBox()
        {
            var neo4jConnection = new ConnectNeo4j();
            var daoGoiBaoHiem = new DAO_GoiBaoHiem(neo4jConnection);
            var busGoiBaoHiem = new BUS_GoiBaoHiem(daoGoiBaoHiem);

            cbo_goibaohiem.Items.Clear();

            List<GoiBaoHiem> danhSachGoi = await busGoiBaoHiem.GetAllGoiBaoHiemAsync();

            foreach (var goi in danhSachGoi)
            {
                cbo_goibaohiem.Items.Add(goi);
            }

            cbo_goibaohiem.DisplayMember = "TenGoi";
            cbo_goibaohiem.ValueMember = "MaGoi";

            if (cbo_goibaohiem.Items.Count > 0)
                cbo_goibaohiem.SelectedIndex = 0;

        }

        private void LoadThoiHanHD()
        {
            cbo_thoihan.Items.Clear();
            for (int i = 1; i < 30; i++)
                cbo_thoihan.Items.Add(i.ToString());
            cbo_thoihan.Items.Add("Trọn đời");
            cbo_thoihan.SelectedIndex = 0;
        }
        private void LoadPhuongThucDong()
        {
            cbo_pt.Items.Clear();
            cbo_pt.Items.Add("Tháng");
            cbo_pt.Items.Add("Quý");
            cbo_pt.Items.Add("Đóng 1 lần");
            cbo_pt.SelectedIndex = 0;
        }

        private async void LoadDanhSachHopDong()
        {
            SetupDataGridView();
            List<HopDongBaoHiem> danhSach = await busHopDongBaoHiem.GetDanhSachHopDongAsync();

            foreach (var hd in danhSach)
            {
                drg_hd.Rows.Add(hd.MaHD, hd.NgayBatDau.ToString("dd/MM/yyyy"), hd.NgayKT.ToString("dd/MM/yyyy"),
                                    hd.ThoiHanHopDong, hd.PhuongThucDong, hd.PhiDongDinhKi, hd.TrangThai);
            }
        }

        private void drg_hd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmEditContract_Load(object sender, EventArgs e)
        {
            LoadDanhSachHopDong();
        }

        string maKH = "";
        string maTH = "";
        string maHD = "";
        private async void drg_hd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //dữ liệu hợp đồng
                DataGridViewRow row = drg_hd.Rows[e.RowIndex];

                if (DateTime.TryParse(row.Cells["NgayBatDau"].Value?.ToString(), out DateTime ngayBatDau))
                {
                    dp_bd.Value = ngayBatDau;
                }

                if (DateTime.TryParse(row.Cells["NgayKT"].Value?.ToString(), out DateTime ngayKetThuc))
                {
                    pk_kt.Value = ngayKetThuc;
                }
                lbl_mahd.Text = row.Cells["MaHD"].Value?.ToString();
                cbo_thoihan.Text = row.Cells["ThoiHanHopDong"].Value?.ToString();
                cbo_pt.Text = row.Cells["PhuongThucDong"].Value?.ToString();
                float phidk = (float)row.Cells["PhiDongDinhKi"].Value;
                txt_dongdk.Text = phidk.ToString("N0");
                cbo_trangthai.Text = row.Cells["TrangThai"].Value?.ToString();


                //dữ liệu KH
                string maHD = row.Cells["MaHD"].Value?.ToString();

                if (!string.IsNullOrEmpty(maHD))
                {
                    //dữ liệu KH
                    KhachHang kh = await busKhachHang.GetKhachHangByMaHDAsync(maHD);

                    if (kh != null)
                    {
                        //txtMaKH.Text = kh.MaKH;
                        maKH = kh.MaKH;
                        txtTenKH.Text = kh.TenKH;
                        dp_ns.Text = kh.NgaySinh.ToString();
                        txtSDT.Text = kh.SDT;
                        txtEmail.Text = kh.Email;
                        txtDiaChi.Text = kh.DiaChi;
                        txtCCCD.Text = kh.CCCD;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //dữ liệu thụ hưởng
                    NguoiThuHuong nth = await busThuHuong.GetNguoiThuHuongByMaHDAsync(maHD);

                    if (nth != null)
                    {
                        //txtMaNTH.Text = nth.MaNTH;
                        maTH = nth.MaNTH;
                        txt_tenht.Text = nth.TenNTH;
                        txt_sdtth.Text = nth.SDT;
                        txt_cccdht.Text = nth.CCCD;
                        txt_dcth.Text = nth.DiaChi;
                        txt_nghenghiepth.Text = nth.NgheNghiep;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Người Thụ Hưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private async void btn_updateKH_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang
            {
                MaKH = maKH,
                TenKH = txtTenKH.Text.Trim(),
                NgaySinh = dp_ns.Value,
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                CCCD = txtCCCD.Text.Trim()
            };

            bool success = await busKhachHang.CapNhatKhachHangAsync(kh);
            if (success)
            {
                MessageBox.Show("Cập nhật khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại!");
            }
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {

            NguoiThuHuong nth = new NguoiThuHuong
            {
                MaNTH = maTH,
                TenNTH = txt_tenht.Text.Trim(),
                SDT = txt_sdtth.Text.Trim(),
                CCCD = txt_cccdht.Text.Trim(),
                DiaChi = txt_dcth.Text.Trim(),
                NgheNghiep = txt_nghenghiepth.Text.Trim()
            };

            bool success = await busThuHuong.CapNhatNguoiThuHuongAsync(nth);
            if (success)
            {
                MessageBox.Show("Cập nhật Người Thụ Hưởng thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật Người Thụ Hưởng thất bại!");
            }
        }

        private async void guna2Button5_Click(object sender, EventArgs e)
        {
            string trangThaiMoi = cbo_trangthai.Text.Trim(); 

            bool success = await busHopDongBaoHiem.CapNhatTrangThaiHopDongAsync(lbl_mahd.Text, trangThaiMoi);

            DialogResult result = MessageBox.Show("Bạn có muốn thay đổi trạng thái hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (success)
                {
                    MessageBox.Show("Cập nhật trạng thái hợp đồng thành công!");
                    LoadDanhSachHopDong();
                }
                else
                {
                    MessageBox.Show("Cập nhật trạng thái thất bại!");
                }
            }
        }
    }
}

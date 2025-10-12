using BUS;
using DAO;
using DTO;
using GUI.Customer;
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
    public partial class frmAddContract : Form
    {
        private NhanVienTuVan nhanVien;
        private readonly ConnectNeo4j connectNeo4J;
        private readonly DAO_KhachHang daoKhachHang;
        private readonly DAO_GoiBaoHiem daoGoiBaoHiem;
        private BUS_HopDongBaoHiem busHopDongBaoHiem;
        private BUS_GoiBaoHiem busGoiBH;

        public frmAddContract(NhanVienTuVan nv)
        {
            InitializeComponent();
            this.nhanVien = nv;

            connectNeo4J = new ConnectNeo4j();
            daoKhachHang = new DAO_KhachHang(connectNeo4J);
            daoGoiBaoHiem = new DAO_GoiBaoHiem(connectNeo4J);
            //load gói bảo hiểm
            LoadGoiBaoHiemToComboBox();

            //load thời hạn
            LoadThoiHanHD();

            //pthuc ddosng
            LoadPhuongThucDong();

            busHopDongBaoHiem = new BUS_HopDongBaoHiem(new DAO_HopDongBaoHiem(connectNeo4J));
            busGoiBH = new BUS_GoiBaoHiem(daoGoiBaoHiem);
        }

        private void btn_themKH_Click(object sender, EventArgs e)
        {
            frmAddCustomer frm = new frmAddCustomer();
            frm.ShowDialog();
        }

        private async void btn_timiemKH_Click(object sender, EventArgs e)
        {
            string maKH = txt_searchKH.Text.Trim();

            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!");
                return;
            }

            var neo4jConnection = new ConnectNeo4j();
            var daoKhachHang = new DAO_KhachHang(neo4jConnection);
            var busKhachHang = new BUS_KhachHang(daoKhachHang);

            try
            {
                KhachHang kh = await busKhachHang.GetKhachHangByMaAsync(maKH);

                if (kh != null)
                {
                    txt_makh.Text = kh.MaKH;
                    txtTenKH.Text = kh.TenKH;
                    txtNgaySinh.Text = kh.NgaySinh.ToString("dd/MM/yyyy");
                    txtSDT.Text = kh.SDT;
                    txtEmail.Text = kh.Email;
                    txtDiaChi.Text = kh.DiaChi;
                    txtCCCD.Text = kh.CCCD;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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
        float phiDongDinhKi = 0;
        private async void TinhPhiDongDinhKi()
        {
            if (cbo_goibaohiem.SelectedItem == null || cbo_pt.SelectedItem == null || string.IsNullOrEmpty(txtNgaySinh.Text))
                return;

            try
            {
                GoiBaoHiem selectedGoi = (GoiBaoHiem)cbo_goibaohiem.SelectedItem;
                string maGoi = selectedGoi.MaGoi;

                DateTime ngaySinh = DateTime.Parse(txtNgaySinh.Text);
                string phuongThucDong = cbo_pt.SelectedItem.ToString();

                phiDongDinhKi = await busGoiBH.TinhPhiDongDinhKiAsync(maGoi, ngaySinh, phuongThucDong);

                txt_dongdk.Text = phiDongDinhKi.ToString("N0"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void txt_searchKH_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        string maNTH = "";
        private async void btn_addKH_Click(object sender, EventArgs e)
        {
            maNTH = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            string tenNTH = txt_tenht.Text.Trim();
            string sdt = txt_cccdht.Text.Trim();
            string cccd = txt_cccdht.Text.Trim();
            string diaChi = txt_dcth.Text.Trim();
            string ngheNghiep = txt_nghenghiepth.Text.Trim();

            if (string.IsNullOrEmpty(tenNTH) || string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(ngheNghiep))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var neo4jConnection = new ConnectNeo4j();
            var daoNguoiThuHuong = new DAO_NguoiThuHuong(neo4jConnection);
            var busNguoiThuHuong = new BUS_NguoiThuHuong(daoNguoiThuHuong);

            var nth = new NguoiThuHuong(maNTH, tenNTH, sdt, cccd, diaChi, ngheNghiep);

            try
            {
                bool success = await busNguoiThuHuong.ThemNguoiThuHuongAsync(nth);

                if (success)
                {
                    MessageBox.Show("Thêm Người Thụ Hưởng thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btn_thembh_Click(object sender, EventArgs e)
        {
            string maHD = "HD" + DateTime.Now.Ticks; // Tạo mã hợp đồng tự động
            //DateTime ngayBatDau = new DateTime(2025, 3, 20);//dtpNgayBatDau.Value;
            //DateTime ngayKT = new DateTime(2027, 3, 20);

            DateTime ngayBatDau = DateTime.Now;
            int soNam;
            DateTime ngayKT = DateTime.Now;
            if (int.TryParse(cbo_thoihan.Text, out soNam))
            {
                ngayKT = ngayBatDau.AddYears(soNam);
            }

            string thoiHan = cbo_thoihan.Text;
            string phuongThucDong = cbo_pt.Text;
            //float phiDong = float.Parse(txt_dongdk.Text);
            string trangThai = "đã duyệt";

            string maKH = txt_makh.Text.Trim();
            string maTH = maNTH;
            string maNV = nhanVien.MaNV;
            string maCTBH = "Công ty bảo hiểm SunLife";

            // Lấy gói bảo hiểm từ ComboBox
            GoiBaoHiem selectedGoi = (GoiBaoHiem)cbo_goibaohiem.SelectedItem;
            string maGoi = selectedGoi.MaGoi;
            HopDongBaoHiem hd = new HopDongBaoHiem
            {
                MaHD = maHD,
                NgayBatDau = ngayBatDau,
                NgayKT = ngayKT,
                ThoiHanHopDong = thoiHan,
                PhuongThucDong = phuongThucDong,
                PhiDongDinhKi = phiDongDinhKi,
                TrangThai = trangThai,
                MaKH = maKH,
                MaNTH = maTH,
                MaNV = maNV,
                MaCTBH = maCTBH,
                MaGoi = maGoi 
            };

            bool success = await busHopDongBaoHiem.ThemHopDongAsync(hd);

            if (success)
            {
                MessageBox.Show("Thêm hợp đồng thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm hợp đồng.");
            }
        }

        private void cbo_goibaohiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TinhPhiDongDinhKi();
        }

        private void cbo_pt_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhPhiDongDinhKi();
        }

        private void frmAddContract_Load(object sender, EventArgs e)
        {
            //if (txt_makh.Text == "" || txt_nsth.Text == "")
                //btn_thembh.Enabled = false;
        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

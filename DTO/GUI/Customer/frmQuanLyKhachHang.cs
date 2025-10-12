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

namespace GUI.Customer
{
    public partial class frmQuanLyKhachHang : Form
    {
        private BUS_KhachHang busKhachHang;
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
            busKhachHang = new BUS_KhachHang(new DAO_KhachHang(new ConnectNeo4j()));
            LoadDanhSachKhachHang();
        }

        private async void LoadDanhSachKhachHang()
        {
            dgv_dskh.Rows.Clear();

            List<KhachHang> danhSach = await busKhachHang.GetDanhSachKhachHangAsync();

            foreach (var kh in danhSach)
            {
                dgv_dskh.Rows.Add(kh.MaKH, kh.CCCD, kh.TenKH, kh.SDT);
            }
        }

        private async void dgv_dskh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgv_dskh.Rows[e.RowIndex];

                //string maKH = row.Cells["MaKH"].Value?.ToString();
                string maKH = row.Cells[0].Value?.ToString();

                KhachHang khachHang = await busKhachHang.GetKhachHangByMaAsync(maKH);
                if (khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng với mã: " + maKH);
                    return;
                }

                if (khachHang != null)
                {
                    txt_makh.Text = khachHang.MaKH;
                    txt_tenkh.Text = khachHang.TenKH;
                    dp_ngaysinh.Value = khachHang.NgaySinh;
                    txt_sdt.Text = khachHang.SDT;
                    txt_email.Text = khachHang.Email;
                    txt_dc.Text = khachHang.DiaChi;
                    txt_cccd.Text = khachHang.CCCD;
                    txt_nghenghiep.Text = khachHang.NgheNghiep;
                }
            }
        }

        private async void btn_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_makh.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật!");
                return;
            }

            KhachHang khachHang = new KhachHang
            {
                MaKH = txt_makh.Text.Trim(),
                TenKH = txt_tenkh.Text.Trim(),
                NgaySinh = dp_ngaysinh.Value,
                SDT = txt_sdt.Text.Trim(),
                Email = txt_email.Text.Trim(),
                DiaChi = txt_dc.Text.Trim(),
                CCCD = txt_cccd.Text.Trim(),
                NgheNghiep = txt_nghenghiep.Text.Trim()
            };

            bool success = await busKhachHang.CapNhatKhachHangAsync(khachHang);

            if (success)
            {
                MessageBox.Show("Cập nhật khách hàng thành công!");
                LoadDanhSachKhachHang(); 
            }
            else
            {
                MessageBox.Show("Cập nhật khách hàng thất bại!");
            }
        }

        private void btn_themthanhtoan_Click(object sender, EventArgs e)
        {
            frmAddCustomer frm = new frmAddCustomer();
            frm.ShowDialog();
        }
    }
}

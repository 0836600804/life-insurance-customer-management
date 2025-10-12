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

namespace GUI.Employee
{
    public partial class frmQuanLiNhanVien : Form
    {
        private BUS_NhanVienTuVan busNV;
        public frmQuanLiNhanVien()
        {
            InitializeComponent();
            busNV = new BUS_NhanVienTuVan(new DAO_NhanVienTuVan(new ConnectNeo4j()));
            LoadDanhSachNhanVien();
        }
        //private async void LoadDanhSachNhanVien()
        //{
        //    dgv_dskh.Rows.Clear();

        //    var ds = await busNV.GetAllNhanVienAsync();

        //    foreach (var nv in ds)
        //    {
        //        dgv_dskh.Rows.Add(nv.MaNV, nv.TenNV, nv.NgaySinh, nv.SDT, nv.Email, nv.Role);
        //    }
        //}
        private async void LoadDanhSachNhanVien()
        {
            dgv_dskh.Rows.Clear();
            dgv_dskh.Columns.Clear();

            // Thêm cột nếu chưa có
            dgv_dskh.Columns.Add("MaNV", "Mã NV");
            dgv_dskh.Columns.Add("TenNV", "Tên NV");
            dgv_dskh.Columns.Add("NgaySinh", "Ngày sinh");
            dgv_dskh.Columns.Add("SDT", "SĐT");
            dgv_dskh.Columns.Add("Email", "Email");
            dgv_dskh.Columns.Add("Role", "Vai trò");
            dgv_dskh.Columns.Add("TrangThai", "Trạng thái");

            var dsNhanVien = await busNV.GetAllNhanVienAsync();

            foreach (var nv in dsNhanVien)
            {
                string trangThaiText = nv.TrangThai == "0" ? "Không hoạt động" : "Đang làm";
                dgv_dskh.Rows.Add(nv.MaNV, nv.TenNV, nv.NgaySinh, nv.SDT, nv.Email, nv.Role, trangThaiText);
            }
        }


        private async void dgv_dskh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var maNV = dgv_dskh.Rows[e.RowIndex].Cells["MaNV"].Value?.ToString();

                var nv = await busNV.GetNhanVienByMaAsync(maNV);
                if (nv != null)
                {
                    txt_makh.Text = nv.MaNV;
                    txt_tenkh.Text = nv.TenNV;
                    txt_ngaysinh.Text = nv.NgaySinh;
                    txt_sdt.Text = nv.SDT;
                    txt_email.Text = nv.Email;
                    txt_role.Text = nv.Role;
                }
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private async void btn_sua_Click(object sender, EventArgs e)
        {
            NhanVienTuVan nv = new NhanVienTuVan
            {
                MaNV = txt_makh.Text,
                TenNV = txt_tenkh.Text,
                NgaySinh = txt_ngaysinh.Text,
                SDT = txt_sdt.Text,
                Email = txt_email.Text,
                Role = txt_role.Text
            };

            bool updated = await busNV.CapNhatNhanVienAsync(nv);

            if (updated)
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
        }

        private async void btn_xoa_Click(object sender, EventArgs e)
        {
            string maNV = txt_makh.Text;

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                bool success = await busNV.XoaNhanVienAsync(maNV);

                if (success)
                {
                    MessageBox.Show("Xóa (cập nhật trạng thái) nhân viên thành công!");
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btn_themthanhtoan_Click(object sender, EventArgs e)
        {
            frmThemNhanVien frm = new frmThemNhanVien();
            frm.ShowDialog();
        }
    }
}

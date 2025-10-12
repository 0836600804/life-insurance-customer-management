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
    public partial class frmThemNhanVien : Form
    {
        private BUS_NhanVienTuVan busNV;
        public frmThemNhanVien()
        {
            InitializeComponent();
            busNV = new BUS_NhanVienTuVan(new DAO_NhanVienTuVan(new ConnectNeo4j()));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_cccd_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btn_addKH_Click(object sender, EventArgs e)
        {
            NhanVienTuVan nv = new NhanVienTuVan
            {
                MaNV = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                TenNV = txt_hoten.Text.Trim(),
                NgaySinh = txt_ns.Text,
                SDT = txt_sdt.Text.Trim(),
                Email = txt_email.Text.Trim(),
                Role = txt_role.Text.Trim(), 
                TrangThai = "1"
            };

            bool success = await busNV.ThemNhanVienAsync(nv);

            if (success)
            {
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!");
            }
        }
    }
}

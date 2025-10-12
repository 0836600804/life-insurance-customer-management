using DTO;
using GUI.Contract;
using GUI.Customer;
using GUI.Employee;
using GUI.Insurance;
using GUI.Invoice;
using GUI.libraries;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Home
{
    public partial class frmTabBar : Form
    {
        private NhanVienTuVan nhanVien;
        public frmTabBar(NhanVienTuVan nv)
        {
            InitializeComponent();

            this.nhanVien = nv;
            labelWelcome.Text = "Xin chào, " + nhanVien.TenNV;
            if (nv.Role != "QuanLy")
            {
                btnNhanVien.Visible = false;
                btn_MasterCauHinh.Visible = false;
                btnCauHinh.Visible = false;
            }
        }

        private void btnThemHopDongMoi_Click(object sender, EventArgs e)
        {
            MyLibrary.LoadForm(panel_container, new frmAddContract(nhanVien));
            SetActiveButton((Guna2Button)sender);
        }
        private void SetActiveButton(Guna2Button button)
        {
            button.CheckedState.FillColor = Color.RoyalBlue;
            button.CheckedState.ForeColor = Color.White;
            button.FillColor = Color.WhiteSmoke;
        }

        private void btnTinhTrangDon_Click(object sender, EventArgs e)
        {
            MyLibrary.LoadForm(panel_container, new frmEditContract());
            SetActiveButton((Guna2Button)sender);
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            MyLibrary.LoadForm(panel_container, new frmCreateInvoices(nhanVien));
            SetActiveButton((Guna2Button)sender);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
  
            MyLibrary.LoadForm(panel_container, new frmQuanLyKhachHang());
            SetActiveButton((Guna2Button)sender);
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            MyLibrary.LoadForm(panel_container, new frmQLGoiBaoHiem());
            SetActiveButton((Guna2Button)sender);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            MyLibrary.LoadForm(panel_container, new frmQuanLiNhanVien());
            SetActiveButton((Guna2Button)sender);
        }
    }
}

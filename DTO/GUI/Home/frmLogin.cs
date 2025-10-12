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

namespace GUI.Home
{
    public partial class frmLogin : Form
    {
        private BUS_NhanVienTuVan busNhanVienTuVan;

        public frmLogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            var neo4jConnection = new ConnectNeo4j();
            var daoNhanVienTuVan = new DAO_NhanVienTuVan(neo4jConnection);
            busNhanVienTuVan = new BUS_NhanVienTuVan(daoNhanVienTuVan);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string sdt = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            //string sdt = "0879586251";
            //string password = "2001216066";

            if (string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!");
                return;
            }

            NhanVienTuVan nv = await busNhanVienTuVan.DangNhapAsync(sdt, password);

            if (nv != null)
            {
                MessageBox.Show($"Đăng nhập thành công! Xin chào {nv.TenNV}");
                frmTabBar mainForm = new frmTabBar(nv);
                mainForm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Email hoặc mật khẩu không đúng.");
            }
        }
    }
}

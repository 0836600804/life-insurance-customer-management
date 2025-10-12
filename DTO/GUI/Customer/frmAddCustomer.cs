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
    public partial class frmAddCustomer : Form
    {
        private BUS_KhachHang busKhachHang;

        public frmAddCustomer()
        {
            InitializeComponent();
            busKhachHang = new BUS_KhachHang(new DAO_KhachHang(new ConnectNeo4j()));
        }

        private async void btn_addKH_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang
            {
                MaKH = "KH" + DateTime.Now.Ticks,
                TenKH = txt_hotenKH.Text.Trim(),
                NgaySinh = dp_ns.Value,
                SDT = txt_sdt.Text.Trim(),
                Email = txt_email.Text.Trim(),
                DiaChi = txt_diachi.Text.Trim(),
                CCCD = txt_cccd.Text.Trim()
            };

            bool success = await busKhachHang.ThemKhachHangAsync(kh);

            if (success)
            {
                MessageBox.Show("Thêm khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm khách hàng.");
            }
        }
    }
}

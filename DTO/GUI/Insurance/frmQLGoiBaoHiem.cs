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

namespace GUI.Insurance
{
    public partial class frmQLGoiBaoHiem : Form
    {
        private BUS_GoiBaoHiem busGoiBH;
        public frmQLGoiBaoHiem()
        {
            InitializeComponent();
            busGoiBH = new BUS_GoiBaoHiem(new DAO_GoiBaoHiem(new ConnectNeo4j()));
        }

        private void frmQLGoiBaoHiem_Load(object sender, EventArgs e)
        {
            LoadDanhSachGoiBaoHiem();
        }
        private async void LoadDanhSachGoiBaoHiem()
        {
            dgv_dsgoi.Rows.Clear();

            List<GoiBaoHiem> danhSach = await busGoiBH.GetAllGoiBaoHiemAsync();

            foreach (var goi in danhSach)
            {
                dgv_dsgoi.Rows.Add(goi.MaGoi, goi.TenGoi, goi.MoTa);
            }
        }
        private async void LoadBangPhiBaoHiem(string maGoi)
        {
            cbo_muctuoi.Items.Clear();

            List<BangPhiBaoHiem> danhSach = await busGoiBH.GetBangPhiBaoHiemByMaGoiAsync(maGoi);

            foreach (var bangPhi in danhSach)
            {
                cbo_muctuoi.Items.Add($"Độ tuổi: {bangPhi.DoTuoiTu} - {bangPhi.DoTuoiDen} | Phí năm: {bangPhi.PhiNam:N0} VND");
            }

            if (cbo_muctuoi.Items.Count > 0)
            {
                cbo_muctuoi.SelectedIndex = 0;
            }
        }


        private async void dgv_dsgoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_dsgoi.Rows[e.RowIndex];

                txt_magoi.Text = row.Cells["MaGoi"].Value?.ToString();
                txt_tengoi.Text = row.Cells["TenGoi"].Value?.ToString();
                txt_mota.Text = row.Cells["MoTa"].Value?.ToString();

                LoadBangPhiBaoHiem(txt_magoi.Text);
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_magoi.Text) || string.IsNullOrWhiteSpace(txt_tengoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maGoi = txt_magoi.Text;
            string tenMoi = txt_tengoi.Text;
            string moTaMoi = txt_mota.Text;

            bool success = await busGoiBH.CapNhatGoiBaoHiemAsync(maGoi, tenMoi, moTaMoi);

            if (success)
            {
                MessageBox.Show("Cập nhật gói bảo hiểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachGoiBaoHiem();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            frmThemGoiBaoHiem frm = new frmThemGoiBaoHiem();
            frm.Show();
        }
    }
}

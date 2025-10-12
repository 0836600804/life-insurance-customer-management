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
    public partial class frmThemGoiBaoHiem : Form
    {
        private BUS_GoiBaoHiem busGoiBH;
        public frmThemGoiBaoHiem()
        {
            InitializeComponent();
            busGoiBH = new BUS_GoiBaoHiem(new DAO_GoiBaoHiem(new ConnectNeo4j()));
        }

        private void KiemTraDuLieu()
        {
            // Kiểm tra tất cả các trường có dữ liệu không
            bool duDieuKien =
                !string.IsNullOrWhiteSpace(txt_magoi.Text) &&
                !string.IsNullOrWhiteSpace(txt_tengoi.Text) &&
                !string.IsNullOrWhiteSpace(txt_mota.Text) &&
                !string.IsNullOrWhiteSpace(txt_tuoitu1.Text) &&
                !string.IsNullOrWhiteSpace(txt_tuoiden1.Text) &&
                !string.IsNullOrWhiteSpace(txt_phinam1.Text) &&
                !string.IsNullOrWhiteSpace(txt_tuoitu2.Text) &&
                !string.IsNullOrWhiteSpace(txt_tuoiden2.Text) &&
                !string.IsNullOrWhiteSpace(txt_phinam2.Text) &&
                !string.IsNullOrWhiteSpace(txt_tuoitu3.Text) &&
                !string.IsNullOrWhiteSpace(txt_tuoiden3.Text) &&
                !string.IsNullOrWhiteSpace(txt_phinam3.Text);

            // Enable/Disable nút Thêm
            btn_them.Enabled = duDieuKien;
        }

        private async void btn_them_Click(object sender, EventArgs e)
        {
            string maGoi = txt_magoi.Text;
            string tenGoi = txt_tengoi.Text;
            string moTa = txt_mota.Text;

            List<BangPhiBaoHiem> danhSachBangPhi = new List<BangPhiBaoHiem>
            {
                new BangPhiBaoHiem
                {
                    DoTuoiTu = int.Parse(txt_tuoitu1.Text),
                    DoTuoiDen = int.Parse(txt_tuoiden1.Text),
                    PhiNam = float.Parse(txt_phinam1.Text)
                },
                new BangPhiBaoHiem
                {
                    DoTuoiTu = int.Parse(txt_tuoitu2.Text),
                    DoTuoiDen = int.Parse(txt_tuoiden2.Text),
                    PhiNam = float.Parse(txt_phinam2.Text)
                },
                new BangPhiBaoHiem
                {
                    DoTuoiTu = int.Parse(txt_tuoitu3.Text),
                    DoTuoiDen = int.Parse(txt_tuoiden3.Text),
                    PhiNam = float.Parse(txt_phinam3.Text)
                }
            };

            bool success = await busGoiBH.ThemGoiBaoHiemAsync(maGoi, tenGoi, moTa, danhSachBangPhi);

            if (success)
            {
                MessageBox.Show("Thêm gói bảo hiểm thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm gói bảo hiểm thất bại!");
            }
        }

        private void txt_magoi_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_tengoi_TextChanged(object sender, EventArgs e)
        {
           KiemTraDuLieu();
        }

        private void txt_mota_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_tuoitu1_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_tuoiden1_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_phinam1_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_tuoitu2_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_tuoiden2_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_phinam2_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_tuoitu3_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_tuoiden3_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        private void txt_phinam3_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }
    }
}

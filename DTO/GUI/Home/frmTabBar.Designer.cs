
using System.Windows.Forms;

namespace GUI.Home
{
    partial class frmTabBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTabBar));
            this.button8 = new System.Windows.Forms.Button();
            this.Resize_Admin = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
            this.DragControl_Admin = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.TableLayoutPanel_Header = new System.Windows.Forms.TableLayoutPanel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Label_Heading = new System.Windows.Forms.Label();
            this.BorderLess_Admin = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel_sidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.tablePanel_DangXuat = new System.Windows.Forms.TableLayoutPanel();
            this.btn_DangXuat = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbLogout = new System.Windows.Forms.Label();
            this.Panel_MasterHeThong = new Guna.UI2.WinForms.Guna2Panel();
            this.btnNguoiDung = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhachHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btn_MasterHeThong = new Guna.UI2.WinForms.Guna2Button();
            this.Panel_MasterBanHang = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTinhTrangDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnThemHopDongMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btn_MasterBanHang = new Guna.UI2.WinForms.Guna2Button();
            this.Panel_MasterNhapHang = new Guna.UI2.WinForms.Guna2Panel();
            this.btnNhaCC = new Guna.UI2.WinForms.Guna2Button();
            this.btnMasterNhapHang = new Guna.UI2.WinForms.Guna2Button();
            this.Panel_MasterCauHinh = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCauHinh = new Guna.UI2.WinForms.Guna2Button();
            this.btn_MasterCauHinh = new Guna.UI2.WinForms.Guna2Button();
            this.Panel_Logo = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_newIndex = new Guna.UI2.WinForms.Guna2PictureBox();
            this.TableLayoutPanel_Body = new System.Windows.Forms.TableLayoutPanel();
            this.panel_container = new System.Windows.Forms.Panel();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.TableLayoutPanel_Header.SuspendLayout();
            this.panel_sidebar.SuspendLayout();
            this.tablePanel_DangXuat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DangXuat)).BeginInit();
            this.Panel_MasterHeThong.SuspendLayout();
            this.Panel_MasterBanHang.SuspendLayout();
            this.Panel_MasterNhapHang.SuspendLayout();
            this.Panel_MasterCauHinh.SuspendLayout();
            this.Panel_Logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_newIndex)).BeginInit();
            this.TableLayoutPanel_Body.SuspendLayout();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.button8.Location = new System.Drawing.Point(203, 4);
            this.button8.Margin = new System.Windows.Forms.Padding(0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(70, 32);
            this.button8.TabIndex = 8;
            this.button8.Text = "Tìm kiếm";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // Resize_Admin
            // 
            this.Resize_Admin.TargetForm = this;
            // 
            // DragControl_Admin
            // 
            this.DragControl_Admin.DockForm = true;
            this.DragControl_Admin.DockIndicatorTransparencyValue = 0.6D;
            this.DragControl_Admin.TargetControl = this.TableLayoutPanel_Header;
            this.DragControl_Admin.UseTransparentDrag = true;
            // 
            // TableLayoutPanel_Header
            // 
            this.TableLayoutPanel_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TableLayoutPanel_Header.ColumnCount = 5;
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.TableLayoutPanel_Header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.TableLayoutPanel_Header.Controls.Add(this.labelWelcome, 0, 0);
            this.TableLayoutPanel_Header.Controls.Add(this.guna2ControlBox1, 4, 0);
            this.TableLayoutPanel_Header.Controls.Add(this.guna2ControlBox2, 3, 0);
            this.TableLayoutPanel_Header.Controls.Add(this.guna2ControlBox3, 2, 0);
            this.TableLayoutPanel_Header.Controls.Add(this.Label_Heading, 1, 0);
            this.TableLayoutPanel_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel_Header.Location = new System.Drawing.Point(7, 0);
            this.TableLayoutPanel_Header.Name = "TableLayoutPanel_Header";
            this.TableLayoutPanel_Header.RowCount = 1;
            this.TableLayoutPanel_Header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Header.Size = new System.Drawing.Size(891, 30);
            this.TableLayoutPanel_Header.TabIndex = 0;
            // 
            // labelWelcome
            // 
            this.labelWelcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.ForeColor = System.Drawing.Color.White;
            this.labelWelcome.Location = new System.Drawing.Point(79, 6);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(80, 17);
            this.labelWelcome.TabIndex = 10;
            this.labelWelcome.Text = "Hello Admin";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.Animated = true;
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(857, 0);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(34, 30);
            this.guna2ControlBox1.TabIndex = 6;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.Animated = true;
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(823, 0);
            this.guna2ControlBox2.Margin = new System.Windows.Forms.Padding(0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(34, 30);
            this.guna2ControlBox2.TabIndex = 7;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.Animated = true;
            this.guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Location = new System.Drawing.Point(789, 0);
            this.guna2ControlBox3.Margin = new System.Windows.Forms.Padding(0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(34, 30);
            this.guna2ControlBox3.TabIndex = 8;
            // 
            // Label_Heading
            // 
            this.Label_Heading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label_Heading.AutoSize = true;
            this.Label_Heading.Font = new System.Drawing.Font("Candara", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Heading.ForeColor = System.Drawing.Color.Black;
            this.Label_Heading.Location = new System.Drawing.Point(426, 4);
            this.Label_Heading.Name = "Label_Heading";
            this.Label_Heading.Size = new System.Drawing.Size(175, 21);
            this.Label_Heading.TabIndex = 9;
            this.Label_Heading.Text = "The Real Life Company";
            // 
            // BorderLess_Admin
            // 
            this.BorderLess_Admin.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_HOR_POSITIVE;
            this.BorderLess_Admin.BorderRadius = 12;
            this.BorderLess_Admin.ContainerControl = this;
            this.BorderLess_Admin.DockIndicatorColor = System.Drawing.Color.IndianRed;
            this.BorderLess_Admin.DockIndicatorTransparencyValue = 0.6D;
            this.BorderLess_Admin.TransparentWhileDrag = true;
            // 
            // panel_sidebar
            // 
            this.panel_sidebar.AutoScroll = true;
            this.panel_sidebar.Controls.Add(this.tablePanel_DangXuat);
            this.panel_sidebar.Controls.Add(this.Panel_MasterHeThong);
            this.panel_sidebar.Controls.Add(this.Panel_MasterBanHang);
            this.panel_sidebar.Controls.Add(this.Panel_MasterNhapHang);
            this.panel_sidebar.Controls.Add(this.Panel_MasterCauHinh);
            this.panel_sidebar.Controls.Add(this.Panel_Logo);
            this.panel_sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sidebar.FillColor = System.Drawing.Color.White;
            this.panel_sidebar.Font = new System.Drawing.Font("Candara", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_sidebar.Location = new System.Drawing.Point(0, 0);
            this.panel_sidebar.Margin = new System.Windows.Forms.Padding(0);
            this.panel_sidebar.Name = "panel_sidebar";
            this.panel_sidebar.Padding = new System.Windows.Forms.Padding(7);
            this.panel_sidebar.Size = new System.Drawing.Size(226, 726);
            this.panel_sidebar.TabIndex = 11;
            // 
            // tablePanel_DangXuat
            // 
            this.tablePanel_DangXuat.BackColor = System.Drawing.Color.White;
            this.tablePanel_DangXuat.ColumnCount = 2;
            this.tablePanel_DangXuat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.80374F));
            this.tablePanel_DangXuat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.19626F));
            this.tablePanel_DangXuat.Controls.Add(this.btn_DangXuat, 1, 0);
            this.tablePanel_DangXuat.Controls.Add(this.lbLogout, 0, 0);
            this.tablePanel_DangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tablePanel_DangXuat.Location = new System.Drawing.Point(7, 682);
            this.tablePanel_DangXuat.Name = "tablePanel_DangXuat";
            this.tablePanel_DangXuat.RowCount = 1;
            this.tablePanel_DangXuat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel_DangXuat.Size = new System.Drawing.Size(212, 37);
            this.tablePanel_DangXuat.TabIndex = 22;
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_DangXuat.ImageRotate = 0F;
            this.btn_DangXuat.Location = new System.Drawing.Point(114, 3);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(34, 31);
            this.btn_DangXuat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_DangXuat.TabIndex = 0;
            this.btn_DangXuat.TabStop = false;
            // 
            // lbLogout
            // 
            this.lbLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbLogout.AutoSize = true;
            this.lbLogout.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogout.Location = new System.Drawing.Point(17, 7);
            this.lbLogout.Name = "lbLogout";
            this.lbLogout.Size = new System.Drawing.Size(91, 23);
            this.lbLogout.TabIndex = 0;
            this.lbLogout.Text = "Đăng xuất";
            // 
            // Panel_MasterHeThong
            // 
            this.Panel_MasterHeThong.BackColor = System.Drawing.Color.White;
            this.Panel_MasterHeThong.Controls.Add(this.btnNguoiDung);
            this.Panel_MasterHeThong.Controls.Add(this.btnKhachHang);
            this.Panel_MasterHeThong.Controls.Add(this.btnNhanVien);
            this.Panel_MasterHeThong.Controls.Add(this.btn_MasterHeThong);
            this.Panel_MasterHeThong.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_MasterHeThong.Location = new System.Drawing.Point(7, 347);
            this.Panel_MasterHeThong.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_MasterHeThong.MaximumSize = new System.Drawing.Size(213, 220);
            this.Panel_MasterHeThong.MinimumSize = new System.Drawing.Size(213, 35);
            this.Panel_MasterHeThong.Name = "Panel_MasterHeThong";
            this.Panel_MasterHeThong.Size = new System.Drawing.Size(213, 176);
            this.Panel_MasterHeThong.TabIndex = 21;
            // 
            // btnNguoiDung
            // 
            this.btnNguoiDung.Animated = true;
            this.btnNguoiDung.AnimatedGIF = true;
            this.btnNguoiDung.BorderRadius = 8;
            this.btnNguoiDung.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNguoiDung.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnNguoiDung.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnNguoiDung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNguoiDung.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnNguoiDung.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnNguoiDung.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnNguoiDung.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnNguoiDung.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNguoiDung.FillColor = System.Drawing.Color.Transparent;
            this.btnNguoiDung.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNguoiDung.ForeColor = System.Drawing.Color.Black;
            this.btnNguoiDung.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnNguoiDung.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNguoiDung.ImageSize = new System.Drawing.Size(10, 10);
            this.btnNguoiDung.Location = new System.Drawing.Point(0, 105);
            this.btnNguoiDung.Margin = new System.Windows.Forms.Padding(0);
            this.btnNguoiDung.Name = "btnNguoiDung";
            this.btnNguoiDung.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNguoiDung.PressedColor = System.Drawing.Color.RoyalBlue;
            this.btnNguoiDung.PressedDepth = 100;
            this.btnNguoiDung.Size = new System.Drawing.Size(213, 35);
            this.btnNguoiDung.TabIndex = 17;
            this.btnNguoiDung.Tag = "children|nguoidung.view";
            this.btnNguoiDung.Text = "Người dùng";
            this.btnNguoiDung.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNguoiDung.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Animated = true;
            this.btnKhachHang.AnimatedGIF = true;
            this.btnKhachHang.BorderRadius = 8;
            this.btnKhachHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKhachHang.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnKhachHang.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhachHang.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FillColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.Black;
            this.btnKhachHang.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnKhachHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhachHang.ImageSize = new System.Drawing.Size(10, 10);
            this.btnKhachHang.Location = new System.Drawing.Point(0, 70);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(0);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnKhachHang.PressedColor = System.Drawing.Color.RoyalBlue;
            this.btnKhachHang.PressedDepth = 100;
            this.btnKhachHang.Size = new System.Drawing.Size(213, 35);
            this.btnKhachHang.TabIndex = 16;
            this.btnKhachHang.Tag = "children|khachhang.view";
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhachHang.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Animated = true;
            this.btnNhanVien.AnimatedGIF = true;
            this.btnNhanVien.BorderRadius = 8;
            this.btnNhanVien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNhanVien.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnNhanVien.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhanVien.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnNhanVien.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnNhanVien.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVien.FillColor = System.Drawing.Color.Transparent;
            this.btnNhanVien.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.Black;
            this.btnNhanVien.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnNhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhanVien.ImageSize = new System.Drawing.Size(10, 10);
            this.btnNhanVien.Location = new System.Drawing.Point(0, 35);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNhanVien.PressedColor = System.Drawing.Color.RoyalBlue;
            this.btnNhanVien.PressedDepth = 100;
            this.btnNhanVien.Size = new System.Drawing.Size(213, 35);
            this.btnNhanVien.TabIndex = 15;
            this.btnNhanVien.Tag = "children|nhanvien.view";
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhanVien.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btn_MasterHeThong
            // 
            this.btn_MasterHeThong.Animated = true;
            this.btn_MasterHeThong.AnimatedGIF = true;
            this.btn_MasterHeThong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.btn_MasterHeThong.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btn_MasterHeThong.Checked = true;
            this.btn_MasterHeThong.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterHeThong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MasterHeThong.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btn_MasterHeThong.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btn_MasterHeThong.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterHeThong.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btn_MasterHeThong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MasterHeThong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_MasterHeThong.Font = new System.Drawing.Font("Candara", 12.75F, System.Drawing.FontStyle.Bold);
            this.btn_MasterHeThong.ForeColor = System.Drawing.Color.White;
            this.btn_MasterHeThong.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterHeThong.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_MasterHeThong.ImageSize = new System.Drawing.Size(10, 10);
            this.btn_MasterHeThong.Location = new System.Drawing.Point(0, 0);
            this.btn_MasterHeThong.Margin = new System.Windows.Forms.Padding(0);
            this.btn_MasterHeThong.Name = "btn_MasterHeThong";
            this.btn_MasterHeThong.PressedColor = System.Drawing.Color.Transparent;
            this.btn_MasterHeThong.Size = new System.Drawing.Size(213, 35);
            this.btn_MasterHeThong.TabIndex = 9;
            this.btn_MasterHeThong.Tag = "parent|nhanvien.view,khachhang.view,nguoidung.view,vaitro.view";
            this.btn_MasterHeThong.Text = "Quản lý hệ thống";
            this.btn_MasterHeThong.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_MasterHeThong.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Panel_MasterBanHang
            // 
            this.Panel_MasterBanHang.BackColor = System.Drawing.Color.White;
            this.Panel_MasterBanHang.Controls.Add(this.btnTinhTrangDon);
            this.Panel_MasterBanHang.Controls.Add(this.btnThemHopDongMoi);
            this.Panel_MasterBanHang.Controls.Add(this.btn_MasterBanHang);
            this.Panel_MasterBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_MasterBanHang.Location = new System.Drawing.Point(7, 229);
            this.Panel_MasterBanHang.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_MasterBanHang.MaximumSize = new System.Drawing.Size(213, 140);
            this.Panel_MasterBanHang.MinimumSize = new System.Drawing.Size(213, 35);
            this.Panel_MasterBanHang.Name = "Panel_MasterBanHang";
            this.Panel_MasterBanHang.Size = new System.Drawing.Size(213, 118);
            this.Panel_MasterBanHang.TabIndex = 20;
            // 
            // btnTinhTrangDon
            // 
            this.btnTinhTrangDon.Animated = true;
            this.btnTinhTrangDon.AnimatedGIF = true;
            this.btnTinhTrangDon.BorderRadius = 8;
            this.btnTinhTrangDon.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTinhTrangDon.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnTinhTrangDon.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnTinhTrangDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTinhTrangDon.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnTinhTrangDon.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnTinhTrangDon.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnTinhTrangDon.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnTinhTrangDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTinhTrangDon.FillColor = System.Drawing.Color.Transparent;
            this.btnTinhTrangDon.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhTrangDon.ForeColor = System.Drawing.Color.Black;
            this.btnTinhTrangDon.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnTinhTrangDon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTinhTrangDon.ImageSize = new System.Drawing.Size(10, 10);
            this.btnTinhTrangDon.Location = new System.Drawing.Point(0, 70);
            this.btnTinhTrangDon.Margin = new System.Windows.Forms.Padding(0);
            this.btnTinhTrangDon.Name = "btnTinhTrangDon";
            this.btnTinhTrangDon.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnTinhTrangDon.PressedColor = System.Drawing.Color.RoyalBlue;
            this.btnTinhTrangDon.PressedDepth = 100;
            this.btnTinhTrangDon.Size = new System.Drawing.Size(213, 35);
            this.btnTinhTrangDon.TabIndex = 16;
            this.btnTinhTrangDon.Tag = "children|tinhtrangdon.view";
            this.btnTinhTrangDon.Text = "Cập nhật hợp đồng";
            this.btnTinhTrangDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTinhTrangDon.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnTinhTrangDon.Click += new System.EventHandler(this.btnTinhTrangDon_Click);
            // 
            // btnThemHopDongMoi
            // 
            this.btnThemHopDongMoi.Animated = true;
            this.btnThemHopDongMoi.AnimatedGIF = true;
            this.btnThemHopDongMoi.BorderRadius = 8;
            this.btnThemHopDongMoi.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnThemHopDongMoi.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThemHopDongMoi.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThemHopDongMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemHopDongMoi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThemHopDongMoi.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThemHopDongMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThemHopDongMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThemHopDongMoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemHopDongMoi.FillColor = System.Drawing.Color.White;
            this.btnThemHopDongMoi.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHopDongMoi.ForeColor = System.Drawing.Color.Black;
            this.btnThemHopDongMoi.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnThemHopDongMoi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThemHopDongMoi.ImageSize = new System.Drawing.Size(10, 10);
            this.btnThemHopDongMoi.Location = new System.Drawing.Point(0, 35);
            this.btnThemHopDongMoi.Margin = new System.Windows.Forms.Padding(0);
            this.btnThemHopDongMoi.Name = "btnThemHopDongMoi";
            this.btnThemHopDongMoi.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnThemHopDongMoi.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThemHopDongMoi.PressedDepth = 100;
            this.btnThemHopDongMoi.Size = new System.Drawing.Size(213, 35);
            this.btnThemHopDongMoi.TabIndex = 15;
            this.btnThemHopDongMoi.Tag = "children|taodh.view";
            this.btnThemHopDongMoi.Text = "Thêm hợp đồng mới";
            this.btnThemHopDongMoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThemHopDongMoi.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnThemHopDongMoi.Click += new System.EventHandler(this.btnThemHopDongMoi_Click);
            // 
            // btn_MasterBanHang
            // 
            this.btn_MasterBanHang.Animated = true;
            this.btn_MasterBanHang.AnimatedGIF = true;
            this.btn_MasterBanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.btn_MasterBanHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btn_MasterBanHang.Checked = true;
            this.btn_MasterBanHang.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterBanHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MasterBanHang.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btn_MasterBanHang.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btn_MasterBanHang.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterBanHang.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btn_MasterBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MasterBanHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_MasterBanHang.Font = new System.Drawing.Font("Candara", 12.75F, System.Drawing.FontStyle.Bold);
            this.btn_MasterBanHang.ForeColor = System.Drawing.Color.White;
            this.btn_MasterBanHang.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterBanHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_MasterBanHang.ImageSize = new System.Drawing.Size(10, 10);
            this.btn_MasterBanHang.Location = new System.Drawing.Point(0, 0);
            this.btn_MasterBanHang.Margin = new System.Windows.Forms.Padding(0);
            this.btn_MasterBanHang.Name = "btn_MasterBanHang";
            this.btn_MasterBanHang.PressedColor = System.Drawing.Color.Transparent;
            this.btn_MasterBanHang.Size = new System.Drawing.Size(213, 35);
            this.btn_MasterBanHang.TabIndex = 9;
            this.btn_MasterBanHang.Tag = "parent|taodh.view,tinhtrangdon.view,taokm.view";
            this.btn_MasterBanHang.Text = "Quản lý hợp đồng bảo hiểm";
            this.btn_MasterBanHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_MasterBanHang.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Panel_MasterNhapHang
            // 
            this.Panel_MasterNhapHang.BackColor = System.Drawing.Color.White;
            this.Panel_MasterNhapHang.Controls.Add(this.btnNhaCC);
            this.Panel_MasterNhapHang.Controls.Add(this.btnMasterNhapHang);
            this.Panel_MasterNhapHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_MasterNhapHang.Location = new System.Drawing.Point(7, 155);
            this.Panel_MasterNhapHang.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_MasterNhapHang.MaximumSize = new System.Drawing.Size(213, 120);
            this.Panel_MasterNhapHang.MinimumSize = new System.Drawing.Size(213, 35);
            this.Panel_MasterNhapHang.Name = "Panel_MasterNhapHang";
            this.Panel_MasterNhapHang.Size = new System.Drawing.Size(213, 74);
            this.Panel_MasterNhapHang.TabIndex = 21;
            // 
            // btnNhaCC
            // 
            this.btnNhaCC.Animated = true;
            this.btnNhaCC.AnimatedGIF = true;
            this.btnNhaCC.BorderRadius = 8;
            this.btnNhaCC.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNhaCC.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNhaCC.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnNhaCC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhaCC.DisabledState.BorderColor = System.Drawing.Color.White;
            this.btnNhaCC.DisabledState.CustomBorderColor = System.Drawing.Color.Honeydew;
            this.btnNhaCC.DisabledState.FillColor = System.Drawing.Color.White;
            this.btnNhaCC.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnNhaCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhaCC.FillColor = System.Drawing.Color.White;
            this.btnNhaCC.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaCC.ForeColor = System.Drawing.Color.Black;
            this.btnNhaCC.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnNhaCC.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnNhaCC.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhaCC.ImageSize = new System.Drawing.Size(10, 10);
            this.btnNhaCC.Location = new System.Drawing.Point(0, 35);
            this.btnNhaCC.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhaCC.Name = "btnNhaCC";
            this.btnNhaCC.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnNhaCC.PressedDepth = 100;
            this.btnNhaCC.Size = new System.Drawing.Size(213, 35);
            this.btnNhaCC.TabIndex = 19;
            this.btnNhaCC.Tag = "children|nhacc.view";
            this.btnNhaCC.Text = "Thanh toán hóa đơn";
            this.btnNhaCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhaCC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNhaCC.Click += new System.EventHandler(this.btnNhaCC_Click);
            // 
            // btnMasterNhapHang
            // 
            this.btnMasterNhapHang.Animated = true;
            this.btnMasterNhapHang.AnimatedGIF = true;
            this.btnMasterNhapHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.btnMasterNhapHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnMasterNhapHang.Checked = true;
            this.btnMasterNhapHang.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnMasterNhapHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasterNhapHang.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnMasterNhapHang.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnMasterNhapHang.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnMasterNhapHang.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnMasterNhapHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMasterNhapHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnMasterNhapHang.Font = new System.Drawing.Font("Candara", 12.75F, System.Drawing.FontStyle.Bold);
            this.btnMasterNhapHang.ForeColor = System.Drawing.Color.White;
            this.btnMasterNhapHang.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnMasterNhapHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMasterNhapHang.ImageSize = new System.Drawing.Size(10, 10);
            this.btnMasterNhapHang.Location = new System.Drawing.Point(0, 0);
            this.btnMasterNhapHang.Margin = new System.Windows.Forms.Padding(0);
            this.btnMasterNhapHang.Name = "btnMasterNhapHang";
            this.btnMasterNhapHang.PressedColor = System.Drawing.Color.Transparent;
            this.btnMasterNhapHang.Size = new System.Drawing.Size(213, 35);
            this.btnMasterNhapHang.TabIndex = 9;
            this.btnMasterNhapHang.Tag = "parent|nhacc.view,nhaphang.view";
            this.btnMasterNhapHang.Text = "Quản lý thanh toán";
            this.btnMasterNhapHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMasterNhapHang.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Panel_MasterCauHinh
            // 
            this.Panel_MasterCauHinh.BackColor = System.Drawing.Color.White;
            this.Panel_MasterCauHinh.Controls.Add(this.btnCauHinh);
            this.Panel_MasterCauHinh.Controls.Add(this.btn_MasterCauHinh);
            this.Panel_MasterCauHinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_MasterCauHinh.Location = new System.Drawing.Point(7, 85);
            this.Panel_MasterCauHinh.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_MasterCauHinh.MaximumSize = new System.Drawing.Size(213, 70);
            this.Panel_MasterCauHinh.MinimumSize = new System.Drawing.Size(213, 35);
            this.Panel_MasterCauHinh.Name = "Panel_MasterCauHinh";
            this.Panel_MasterCauHinh.Size = new System.Drawing.Size(213, 70);
            this.Panel_MasterCauHinh.TabIndex = 18;
            // 
            // btnCauHinh
            // 
            this.btnCauHinh.Animated = true;
            this.btnCauHinh.AnimatedGIF = true;
            this.btnCauHinh.BorderRadius = 8;
            this.btnCauHinh.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCauHinh.CheckedState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnCauHinh.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnCauHinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCauHinh.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnCauHinh.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnCauHinh.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnCauHinh.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnCauHinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCauHinh.FillColor = System.Drawing.Color.White;
            this.btnCauHinh.Font = new System.Drawing.Font("Candara", 12F);
            this.btnCauHinh.ForeColor = System.Drawing.Color.Black;
            this.btnCauHinh.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnCauHinh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCauHinh.ImageSize = new System.Drawing.Size(10, 10);
            this.btnCauHinh.Location = new System.Drawing.Point(0, 35);
            this.btnCauHinh.Margin = new System.Windows.Forms.Padding(0);
            this.btnCauHinh.Name = "btnCauHinh";
            this.btnCauHinh.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnCauHinh.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnCauHinh.PressedDepth = 100;
            this.btnCauHinh.Size = new System.Drawing.Size(213, 35);
            this.btnCauHinh.TabIndex = 19;
            this.btnCauHinh.Tag = "children|cauhinh.view";
            this.btnCauHinh.Text = "Gói bảo hiểm";
            this.btnCauHinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCauHinh.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnCauHinh.Click += new System.EventHandler(this.btnCauHinh_Click);
            // 
            // btn_MasterCauHinh
            // 
            this.btn_MasterCauHinh.Animated = true;
            this.btn_MasterCauHinh.AnimatedGIF = true;
            this.btn_MasterCauHinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.btn_MasterCauHinh.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btn_MasterCauHinh.Checked = true;
            this.btn_MasterCauHinh.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterCauHinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MasterCauHinh.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btn_MasterCauHinh.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btn_MasterCauHinh.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterCauHinh.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btn_MasterCauHinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MasterCauHinh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_MasterCauHinh.Font = new System.Drawing.Font("Candara", 13.2F, System.Drawing.FontStyle.Bold);
            this.btn_MasterCauHinh.ForeColor = System.Drawing.Color.White;
            this.btn_MasterCauHinh.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btn_MasterCauHinh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_MasterCauHinh.ImageSize = new System.Drawing.Size(10, 10);
            this.btn_MasterCauHinh.Location = new System.Drawing.Point(0, 0);
            this.btn_MasterCauHinh.Margin = new System.Windows.Forms.Padding(0);
            this.btn_MasterCauHinh.Name = "btn_MasterCauHinh";
            this.btn_MasterCauHinh.PressedColor = System.Drawing.Color.Transparent;
            this.btn_MasterCauHinh.Size = new System.Drawing.Size(213, 35);
            this.btn_MasterCauHinh.TabIndex = 9;
            this.btn_MasterCauHinh.Tag = "parent|cauhinh.view";
            this.btn_MasterCauHinh.Text = "Bảo hiểm";
            this.btn_MasterCauHinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_MasterCauHinh.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Panel_Logo
            // 
            this.Panel_Logo.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Logo.BorderRadius = 12;
            this.Panel_Logo.Controls.Add(this.btn_newIndex);
            this.Panel_Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Logo.FillColor = System.Drawing.Color.White;
            this.Panel_Logo.Location = new System.Drawing.Point(7, 7);
            this.Panel_Logo.Name = "Panel_Logo";
            this.Panel_Logo.Size = new System.Drawing.Size(212, 78);
            this.Panel_Logo.TabIndex = 0;
            // 
            // btn_newIndex
            // 
            this.btn_newIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_newIndex.Image = global::GUI.Properties.Resources._16517369629130_aia_la_gi;
            this.btn_newIndex.ImageRotate = 0F;
            this.btn_newIndex.Location = new System.Drawing.Point(0, 0);
            this.btn_newIndex.Name = "btn_newIndex";
            this.btn_newIndex.Size = new System.Drawing.Size(212, 78);
            this.btn_newIndex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_newIndex.TabIndex = 2;
            this.btn_newIndex.TabStop = false;
            // 
            // TableLayoutPanel_Body
            // 
            this.TableLayoutPanel_Body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TableLayoutPanel_Body.ColumnCount = 2;
            this.TableLayoutPanel_Body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.TableLayoutPanel_Body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Body.Controls.Add(this.panel_sidebar, 0, 0);
            this.TableLayoutPanel_Body.Controls.Add(this.panel_container, 1, 0);
            this.TableLayoutPanel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel_Body.Location = new System.Drawing.Point(7, 30);
            this.TableLayoutPanel_Body.Name = "TableLayoutPanel_Body";
            this.TableLayoutPanel_Body.RowCount = 1;
            this.TableLayoutPanel_Body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel_Body.Size = new System.Drawing.Size(891, 726);
            this.TableLayoutPanel_Body.TabIndex = 10;
            // 
            // panel_container
            // 
            this.panel_container.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_container.Location = new System.Drawing.Point(235, 2);
            this.panel_container.Margin = new System.Windows.Forms.Padding(9, 2, 3, 2);
            this.panel_container.Name = "panel_container";
            this.panel_container.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel_container.Size = new System.Drawing.Size(653, 722);
            this.panel_container.TabIndex = 12;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Black;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(160, 50);
            this.guna2ImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton1.Image")));
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(150, 50);
            this.guna2ImageButton1.Location = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(62, 60);
            this.guna2ImageButton1.TabIndex = 0;
            // 
            // frmTabBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(905, 763);
            this.Controls.Add(this.TableLayoutPanel_Body);
            this.Controls.Add(this.TableLayoutPanel_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTabBar";
            this.Padding = new System.Windows.Forms.Padding(7, 0, 7, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sản phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TableLayoutPanel_Header.ResumeLayout(false);
            this.TableLayoutPanel_Header.PerformLayout();
            this.panel_sidebar.ResumeLayout(false);
            this.tablePanel_DangXuat.ResumeLayout(false);
            this.tablePanel_DangXuat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_DangXuat)).EndInit();
            this.Panel_MasterHeThong.ResumeLayout(false);
            this.Panel_MasterBanHang.ResumeLayout(false);
            this.Panel_MasterNhapHang.ResumeLayout(false);
            this.Panel_MasterCauHinh.ResumeLayout(false);
            this.Panel_Logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_newIndex)).EndInit();
            this.TableLayoutPanel_Body.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button button8;
        private Guna.UI2.WinForms.Guna2ResizeForm Resize_Admin;
        private Guna.UI2.WinForms.Guna2DragControl DragControl_Admin;
        private Guna.UI2.WinForms.Guna2BorderlessForm BorderLess_Admin;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private TableLayoutPanel TableLayoutPanel_Header;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Label Label_Heading;
        private TableLayoutPanel TableLayoutPanel_Body;
        private Guna.UI2.WinForms.Guna2Panel panel_sidebar;
        private Guna.UI2.WinForms.Guna2Panel Panel_MasterHeThong;
        private Guna.UI2.WinForms.Guna2Button btnNguoiDung;
        private Guna.UI2.WinForms.Guna2Button btnKhachHang;
        private Guna.UI2.WinForms.Guna2Button btnNhanVien;
        private Guna.UI2.WinForms.Guna2Button btn_MasterHeThong;
        private Guna.UI2.WinForms.Guna2Panel Panel_MasterBanHang;
        private Guna.UI2.WinForms.Guna2Button btnTinhTrangDon;
        private Guna.UI2.WinForms.Guna2Button btnThemHopDongMoi;
        private Guna.UI2.WinForms.Guna2Button btn_MasterBanHang;
        private Guna.UI2.WinForms.Guna2Panel Panel_MasterNhapHang;
        private Guna.UI2.WinForms.Guna2Button btnNhaCC;
        private Guna.UI2.WinForms.Guna2Button btnMasterNhapHang;
        private Guna.UI2.WinForms.Guna2Panel Panel_MasterCauHinh;
        private Guna.UI2.WinForms.Guna2Button btnCauHinh;
        private Guna.UI2.WinForms.Guna2Button btn_MasterCauHinh;
        private Panel panel_container;
        private Guna.UI2.WinForms.Guna2Panel Panel_Logo;
        private Guna.UI2.WinForms.Guna2PictureBox btn_newIndex;
        private TableLayoutPanel tablePanel_DangXuat;
        private Label lbLogout;
        private Guna.UI2.WinForms.Guna2PictureBox btn_DangXuat;
        private Label labelWelcome;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.libraries
{
    public class MyLibrary
    {
        private static Thread thread;
        public static int maND { get; set; }
        public static string UserName { get; set; }
        public static void CloseThisOpenThat(Form pOldForm, Form pNewForm)
        {
            pOldForm.Close();
            thread = new Thread(() =>
            {
                Application.Run(pNewForm);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static void LoadForm(Control pBody, Control pControl, DockStyle? dockStyle = DockStyle.Fill)
        {
            pBody.Controls.Clear();
            if (pControl is Form form)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                pBody.Controls.Add(form);
                form.Dock = (DockStyle)dockStyle;
                form.Show();
            }
            else
            {

                AddControl(pBody, pControl, (DockStyle)dockStyle);
            }
        }

        public static void Collapse(bool collapse, Control container)
        {

            if (collapse)
            {
                container.Size = container.MinimumSize;
            }
            else
            {
                container.Size = container.MaximumSize;
            }
        }
        public static void AddControl(Control parent, Control chil, DockStyle dockStyle)
        {
            chil.Dock = dockStyle;
            parent.Controls.Add(chil);
        }


        //public static bool CheckControlPermission(Control control, int userId)
        //{
        //    if (control.Tag == null)
        //    {
        //        return false;
        //    }
        //    string[] tags = control.Tag.ToString().Split('|');
        //    if (tags.Length < 1)
        //    {
        //        return true;
        //    }
        //    string controlType = tags[0];
        //    string permissionName = tags[1];
        //    using (var db = new QuanLy_CellPhoneSDataContext())
        //    {
        //        var userPermissions = db.QuyenNguoiDungs
        //            .Where(qnd => qnd.MAND == userId && !(qnd.IsDeleted ?? false))
        //            .Join(db.QuyenChucNangs,
        //                   qnd => qnd.MaQuyen,
        //                   qcn => qcn.MaQuyen,
        //                   (qnd, qcn) => new { qnd, qcn })
        //            .Join(db.ChucNangs,
        //                   temp => temp.qcn.MaCN,
        //                   cn => cn.MaCN,
        //                   (temp, cn) => cn.TenCN)
        //            .ToList();
        //        switch (controlType)
        //        {
        //            case "parent":
        //                string[] requiredPermissions = permissionName.Split(',');
        //                foreach (string requiredPermission in requiredPermissions)
        //                {
        //                    if (userPermissions.Contains(requiredPermission))
        //                    {
        //                        return true;
        //                    }
        //                }
        //                return false;
        //            case "children":
        //                if (userPermissions.Contains(permissionName))
        //                {
        //                    return true;
        //                }
        //                return false;

        //            default:
        //                return true;
        //        }
        //    }
        //}

        public static void RemoveChildFrom(Control parent, int from)
        {
            int length = parent.Controls.Count - from;

            for (int i = 0; i < length; i++)
            {
                parent.Controls.RemoveAt(0);
            }
        }

        //public static bool CheckPermission(int userId, string permission)
        //{
        //    using (var db = new QuanLy_CellPhoneSDataContext())
        //    {
        //        var userPermissions = db.QuyenNguoiDungs
        //            .Where(qnd => qnd.MAND == userId && !(qnd.IsDeleted ?? false))
        //            .Join(db.QuyenChucNangs,
        //                   qnd => qnd.MaQuyen,
        //                   qcn => qcn.MaQuyen,
        //                   (qnd, qcn) => new { qnd, qcn })
        //            .Join(db.ChucNangs,
        //                   temp => temp.qcn.MaCN,
        //                   cn => cn.MaCN,
        //                   (temp, cn) => cn.TenCN)
        //            .ToList();
        //        return userPermissions.Contains(permission);
        //    }
        //}
        //public static string GenerateCustomerCode()
        //{
        //    KhachHangBUS khang = new KhachHangBUS();
        //    var maxCode = khang.LoadKH()
        //                       .Where(kh => kh.MaNB.StartsWith("KH") && kh.MaNB.Length == 6)
        //                       .OrderByDescending(kh => kh.MaNB)
        //                       .Select(kh => kh.MaNB)
        //                       .FirstOrDefault();

        //    if (maxCode == null)
        //    {
        //        return "KH0001";
        //    }

        //    int maxNumber = int.Parse(maxCode.Substring(2));
        //    int newNumber = maxNumber + 1;
        //    return "KH" + newNumber.ToString("D4");
        //}
    }
}

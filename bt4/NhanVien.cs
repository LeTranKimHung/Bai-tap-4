using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bt4
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        public string MSNV => txtMSNV.Text;
        public string Ten => txtTen.Text;
        public string Luong => txtLuong.Text;
        public void SetData(string maso, string ten, string luong)
        {
            txtMSNV.Text = maso;
            txtTen.Text = ten;
            txtLuong.Text = luong;



        }
        private void NhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MSNV) || string.IsNullOrWhiteSpace(Ten) || string.IsNullOrWhiteSpace(Luong))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

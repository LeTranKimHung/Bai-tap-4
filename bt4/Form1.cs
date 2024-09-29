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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int GetSelectedRow(string NVID)
        {
            for (int i = 0;i < dgvForm1.Rows.Count;i++)
            {
                if (dgvForm1.Rows[i].Cells[0].Value?.ToString() == NVID) 
                {
                    return i;
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectedRow, NhanVien frm)
        {
            dgvForm1.Rows[selectedRow].Cells[0].Value = frm.MSNV;
            dgvForm1.Rows[selectedRow].Cells[1].Value = frm.Ten;
            dgvForm1.Rows[selectedRow].Cells[2].Value = frm.Luong;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (NhanVien frm = new NhanVien())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int selectedRow = GetSelectedRow(frm.MSNV);
                    if (selectedRow == -1)
                    {
                        selectedRow = dgvForm1.Rows.Add();
                        InsertUpdate(selectedRow, frm);
                    }
                    else
                    {
                        MessageBox.Show("Mã số nhân viên đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dgvForm1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvForm1.SelectedRows.Count > 0)
            {
                DataGridViewRow dataGrid = dgvForm1.SelectedRows[0];

            }
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            if (dgvForm1.CurrentRow != null)
            {
                int selectedRow = dgvForm1.CurrentRow.Index;
                string currentID = dgvForm1.Rows[selectedRow].Cells[0].Value.ToString();

                using (NhanVien frm = new NhanVien())
                {
                    frm.SetData(currentID, dgvForm1.Rows[selectedRow].Cells[1].Value.ToString(), dgvForm1.Rows[selectedRow].Cells[2].Value.ToString());
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        InsertUpdate(selectedRow, frm);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvForm1.CurrentRow != null)
            {
                var result = MessageBox.Show("Bạn có muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int selectedRow = dgvForm1.CurrentRow.Index;
                    dgvForm1.Rows.RemoveAt(selectedRow);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát chương trình hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

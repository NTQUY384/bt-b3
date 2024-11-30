using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bt_b3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(txtStt.Text);

            lvi.SubItems.Add(txtMa.Text);
            lvi.SubItems.Add(txtTen.Text);
            lvNhanVien.Items.Add(lvi);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = null;

            foreach (ListViewItem item in lvNhanVien.Items)
            {
                if (item.Checked)
                {
                    if (selectedItem != null)
                    {                      
                        MessageBox.Show("vui long chon 1 o .", "loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    selectedItem = item;
                }
            }
            if (selectedItem != null)
            {
                selectedItem.SubItems[0].Text = txtStt.Text;
                selectedItem.SubItems[1].Text = txtMa.Text;
                selectedItem.SubItems[2].Text = txtTen.Text;
            }
            else
            {
                MessageBox.Show("vui chon 1 dong de sua.", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            for (int i = lvNhanVien.Items.Count - 1; i >= 0; i--)
            {
                if (lvNhanVien.Items[i].Checked)
                {
                    lvNhanVien.Items.RemoveAt(i); 
                }
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvNhanVien.SelectedItems[0];
                string STT = lvi.SubItems[0].Text;
                string ma = lvi.SubItems[1].Text;
                string ten = lvi.SubItems[2].Text;
                txtStt.Text = STT;
                txtMa.Text = ma;
                txtTen.Text = ten;
            }
        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != -1)
            {
                ColumnHeader culo = lvNhanVien.Columns[e.Column];
                MessageBox.Show("chon cot");
            }
        }
    }
}

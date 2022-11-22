using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class f_DangNhap : Form
    {
        public f_DangNhap()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState.ToString() == "Checked")
            {
                txt_MatKhau.PasswordChar = '\0';
            } else
            {
                txt_MatKhau.PasswordChar = '*';
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            f_SanPham frm = new f_SanPham();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

    
    }
}

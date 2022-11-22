using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBanHang
{
    public partial class f_SanPham : Form
    {
        private string strConnectionString = @"Data source = FBK; Initial Catalog = Demo01; Integrated Security = True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;

        private DataSet ds;
        private DataTable dt;
        private DataGridView dataGridView1;

        public f_SanPham()
        {
            InitializeComponent();
            LoadData();
        }

        public void connect()
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open();
            MessageBox.Show("Connection open!");
            conn.Close();
        }

        public void LoadData()
        {
            //Tạo phương thức lấy giữ liệu
            conn = new SqlConnection(strConnectionString);
            conn.Open();

            string sqlStr = "SELECT * From SANPHAM";
            myAdapter = new SqlDataAdapter(sqlStr, conn);
            
            ds = new DataSet();
            myAdapter.Fill(ds, "SANPHAM");
            dt = ds.Tables["SANPHAM"];
            //Tắt tự động thêm thuộc tính, trường thuộc tính vào cột
            //dataGridView1.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt;


            conn.Close();
        }

        public void Create()
        {
            
            SANPHAM sp = new SANPHAM()
            {
                IDSanpham = Int32.Parse(textBox1.Text),
                Tensp = textBox2.Text,
                Gia = decimal.Parse(textBox3.Text)                  
            };

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConnectionString);
            conn.Open();

            SqlCommand cmd;
            SqlDataReader dr;
            String sql, Output = "";

            sql = "Select * from SANPHAM";

            cmd = new SqlCommand(sql, conn);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Output = Output + dr.GetValue(0) + " - " + dr.GetValue(1) + " - " + dr.GetValue(2) + " - " + dr.GetValue(3) + "\n";
            }

            MessageBox.Show(Output);

            dr.Close();
            cmd.Dispose();
            conn.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            textBox1.Text = dt.Rows[row]["IDSanpham"].ToString();
            textBox2.Text = dt.Rows[row]["Tensp"].ToString();
            textBox3.Text = dt.Rows[row]["Gia"].ToString();


        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = e.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

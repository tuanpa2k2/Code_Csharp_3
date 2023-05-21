using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1._3_ADO
{
    public partial class Form1 : Form
    {
        private string _sqlConnectionStr = @"Data Source=DESKTOP-V4BEME9\SQLEXPRESS01;
                                            Initial Catalog=CSharp3_tuanpa_18296;
                                            Persist Security Info=True;User ID=tuanpa03;
                                            Password=2002"; //Chuỗi kết nối csdl
        private SqlConnection _conn;
        private SqlCommand _cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_KetNoi_Click(object sender, EventArgs e)
        {
            //1. Khởi tạo kết nối csdl
            _conn = new SqlConnection(_sqlConnectionStr);
            //2. Mở kết nối
            _conn.Open();
            //3. Sau khi kết nối thực hiện 1 hđ nào đó
            //4. Thực thi 1 câu lệnh SqlCommand
            _cmd = new SqlCommand("Select * from Accounts_ADO", _conn);
            //5. Thực thi và hứng dữ liệu vào SqlDataAdapter
            SqlDataAdapter dataAdapter = new SqlDataAdapter(_cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table); //Đổ dữ liệu vào Table
            dataGridView1.DataSource = table;
            //6. Sau khi thực hiện xong thì đóng kết nối
            _conn.Close();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1._3_ADO
{
    public partial class QLTV_QuanLiSach : Form
    {
        public QLTV_QuanLiSach()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Mã sách";
            dataGridView1.Columns[1].Name = "Tên sách";
            dataGridView1.Columns[2].Name = "Tác giả";
            dataGridView1.Columns[3].Name = "Thể loại";
            dataGridView1.Columns[4].Name = "Nhà XB";
            dataGridView1.Columns[5].Name = "Năm XB";
            dataGridView1.Columns[6].Name = "Số lượng";
            dataGridView1.Columns[7].Name = "Ngôn ngữ";
            dataGridView1.Columns[8].Name = "Tình trạng";
        }
        
    }
}

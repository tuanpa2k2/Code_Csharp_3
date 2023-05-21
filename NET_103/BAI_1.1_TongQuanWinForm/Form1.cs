using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1._1_TongQuanWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_Ten.Text = "Chao cac ban";
            namSinh();
            loadTable();
        }
        void namSinh()
        {
            int temp = 1800;
            for (int i = 0; i <= 2021-1800; i++)
            {
                cbo_NamSinh.Items.Add(temp);
                temp++;
            }
            cbo_NamSinh.SelectedIndex = 2021 - 1800;
        }
        void loadTable()
        {
            TheLoai tl = new TheLoai();
            //*C1:
            //dgrip_Table.DataSource = tl.GetListTheLoais();
            ///----------------------------------------------

            ////*C2: DataTable
            DataTable table = new DataTable();
            //Tao ten cot kieu dieu lieu
            table.Columns.Add("Mã_TL", typeof(string));
            table.Columns.Add("Tên_TL", typeof(string));
            table.Columns.Add("Trạng_Thái", typeof(string));
            table.Columns.Add("Trạng_Thái_Sửa", typeof(string));

            //Fill data
            foreach (var x in tl.GetListTheLoais())
            {
                table.Rows.Add(x.MaTheLoai, x.TenTheLoai, x.TrangThai, x.statuEdit);
            }
            dgrip_Table.DataSource = table;
            ///----------------------------------------------

            ////C3: 
            //dgrip_Table.ColumnCount = 3;
            //dgrip_Table.Columns[0].Name = "Tên";
            //dgrip_Table.Columns[1].Name = "TT";
            //dgrip_Table.Columns[2].Name = "TT Sửa";
            //////Fill data
            //foreach (var x in tl.GetListTheLoais())
            //{
            //    dgrip_Table.Rows.Add(x.TenTheLoai, x.TrangThai, x.statuEdit);
            //}
        }

    }
}

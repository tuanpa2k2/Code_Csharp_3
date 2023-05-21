using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment_C3.Models;
using Assignment_C3.Service;

namespace Assignment_C3
{
    public partial class Form1 : Form
    {
        private ServiceDanhba _sv;
        private Nguoi _nguoisss;
        public Form1()
        {
            _sv = new ServiceDanhba();
            InitializeComponent();
            LoadCbx();
            LoadDataView();
        }
        void LoadCbx()
        {
            foreach (var x in _sv.GetYearOfBirth())
            {
                cbx_Namsinh.Items.Add(x);
            }
            cbx_Namsinh.SelectedIndex = 0;
        }
        void LoadDataView()
        {
            //var ligbig = (from a in _sv.GetlstNguoi()
            //              join b in _sv.GetlstDanhba() on a.DanhbaId equals b.Id
            //              select new { a.Id, a.Ho, a.Tendem, a.Ten, a.Namsinh, a.Gioitinh, b.Sdt1, b.Sdt2, b.Email, b.Ghichu }).ToList();

            dgr_Table.ColumnCount = 10;
            dgr_Table.Columns[0].Name = "Họ";
            dgr_Table.Columns[1].Name = "Tên đệm";
            dgr_Table.Columns[2].Name = "Tên";
            dgr_Table.Columns[3].Name = "Năm sinh";
            dgr_Table.Columns[4].Name = "Giới tính";
            dgr_Table.Columns[5].Name = "Sdt 1";
            dgr_Table.Columns[6].Name = "Sdt 2";
            dgr_Table.Columns[7].Name = "Gmail";
            dgr_Table.Columns[8].Name = "Ghi chú";
            dgr_Table.Columns[9].Name = "ID";
            dgr_Table.Columns[9].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in _sv.GetlstNguoi())
            {
                var danhba = _sv.GetlstDanhba().Where(c =>c.Id == x.DanhbaId).FirstOrDefault();
                dgr_Table.Rows.Add(x.Ho, x.Tendem, x.Ten, x.Namsinh, x.Gioitinh == 1 ? "Nam" : "Nữ",
                    danhba.Sdt1, danhba.Sdt2, danhba.Email, danhba.Ghichu, danhba.Id);
            }
        }

        private void dgr_Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (_sv.GetlstNguoi().Count == 0 || rd == -1) return;
            _nguoisss = _sv.GetlstNguoi().FirstOrDefault(c => c.Id == Convert.ToInt32(dgr_Table.Rows[rd].Cells[9].Value.ToString()));

            txt_Ho.Text = dgr_Table.Rows[rd].Cells[0].Value.ToString();
            txt_Tendem.Text = dgr_Table.Rows[rd].Cells[1].Value.ToString();
            txt_Ten.Text = dgr_Table.Rows[rd].Cells[2].Value.ToString();
            cbx_Namsinh.Text = dgr_Table.Rows[rd].Cells[3].Value.ToString();
            rbtn_Nam.Checked = dgr_Table.Rows[rd].Cells[4].Value.ToString() == "Nam" ? true : false;
            rbtn_Nu.Checked = dgr_Table.Rows[rd].Cells[4].Value.ToString() == "Nữ" ? true : false;
            txt_Sdt1.Text = dgr_Table.Rows[rd].Cells[5].Value.ToString();
            txt_Sdt2.Text = dgr_Table.Rows[rd].Cells[6].Value.ToString();
            txt_Email.Text = dgr_Table.Rows[rd].Cells[7].Value.ToString();
            txt_Ghichu.Text = dgr_Table.Rows[rd].Cells[8].Value.ToString();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            DialogResult cn;

            Nguoi ngu = new Nguoi();
            ngu.Id = _sv.GetlstNguoi().Max(c => c.Id) + 1;
            ngu.Ho = txt_Ho.Text;
            ngu.Tendem = txt_Tendem.Text;
            ngu.Ten = txt_Ten.Text;
            ngu.Namsinh = cbx_Namsinh.Text;
            ngu.Gioitinh = rbtn_Nam.Checked ? 1 : 0;

            DanhBa danhbas = new DanhBa();
            danhbas.Id = _sv.GetlstDanhba().Max(c => c.Id) + 1;
            danhbas.Sdt1 = txt_Sdt1.Text;
            danhbas.Sdt2 = txt_Sdt2.Text;
            danhbas.Email = txt_Email.Text;
            danhbas.Ghichu = txt_Ghichu.Text;

            cn = MessageBox.Show(_sv.AddNguoi(ngu, danhbas), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _sv.GetlistFromDB();
            LoadDataView();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {

        }
    }
}

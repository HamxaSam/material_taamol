﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;

namespace taamol
{
    public partial class MembersTab : UserControl
    {
        Managment managment;
        DataView dv;




        public MembersTab()
        {
            InitializeComponent();
        }

        private void MembersTab_Load(object sender, EventArgs e)
        {
            managment = new Managment();


        }
        public void getMembers(int id)
        {


            OrderedDictionary dic = managment.getgymsnamesAndid(id, panel1);
            managment.readAllmembers((int)dic[0], Dgv_allmembers);
        }

        

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {




        }



        private void Img_addmember_Click(object sender, EventArgs e)
        {

        }

        private void Dgv_allmembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = Dgv_allmembers.Rows[index];
            MessageBox.Show(selectedRow.Cells[1].Value + "");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            
            managment.DView.RowFilter = "member_meli_code like '" + Txt_search.text.ToString() + "%'";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taamol
{


    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand com;






        private void login_Load(object sender, EventArgs e)
        {
            


        }

       


        private void Btn_login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void login_Shown(object sender, EventArgs e)
        {
            Txt_username.Focus();
        }

        private void login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Login();
            }
        }
        private void Login() {
            if (Txt_username.Text.Length < 5 || Txt_password.Text.Length < 5)
            {
                MessageBox.Show("You need to write at least 5 characters");
            }
            else
            {

                // SqlConnection c;
                //connect c1 = new connect();
                //c = c1.conn();
                //c.Open();
                //c.Close();
                //ss


                con = connect.conn();
                com = new SqlCommand();




                try
                {
                    
                    com.CommandText = "exec loginManager @username, @password";
                    com.Connection = con;
                    com.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = Txt_username.Text.ToString();
                    com.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = Txt_password.Text.ToString();
                    if (com.Connection.State == ConnectionState.Closed)
                    {
                        com.Connection.Open();

                    }

                    int n = (int)com.ExecuteScalar();
                    if (n != -29)
                    {

                        main main = new main(n);
                        this.Hide();

                        main.ShowDialog();
                        this.Close();



                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect!");
                    }


                }
                catch (Exception)
                {
                    MessageBox.Show("errror ");
                }
                finally
                {
                    com.Connection.Close();
                    
                }
            }

        }
    }
}

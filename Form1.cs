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

namespace FYP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            string usr, pass;

            usr = txtusrid.Text;
            pass = txtpass.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=Dell;Initial Catalog=FinalYearProj;Integrated Security=True";

            con.Open();

            string LogQ = "select UserName,Password from UserReg where UserName='" + usr + "'";
            SqlCommand cmd = new SqlCommand(LogQ, con);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                if (usr.Equals(dr["UserName"].ToString()) && pass.Equals(dr["Password"].ToString()))
                {
                    MessageBox.Show("SUCCESSFULL LOGIN!!");
                    //  MainApp ma = new MainApp();
                    //ma.Show();
                    MainApplication ma = new MainApplication();
                    ma.Show();
                    ma.SendData(usr);
            //        MessageBox.Show(usr);
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password!!!");
                }

                con.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            New_User nu = new New_User();
            nu.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

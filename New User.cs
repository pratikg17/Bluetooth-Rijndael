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
    public partial class New_User : Form
    {
        public New_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fn = txtFname.Text;
            string email = txtEmail.Text;
            string username = txtUser.Text;
            string pass = txtPass.Text;
            string cpass = txtCpass.Text;
            float mob = float.Parse(txtMob.Text);
            if (pass != cpass)
            {
                MessageBox.Show("Please enter correct password", "Alert!", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=Dell;Initial Catalog=FinalYearProj;Integrated Security=True";
                con.Open();

                string insQry = "insert into UserREG values('" + fn + "','" + email + "','" + username + "','" + pass + "','" + cpass + "'," + mob + ")";




                SqlCommand cmd = new SqlCommand(insQry, con);

                int csucc = cmd.ExecuteNonQuery();

                if (csucc > 0)
                {
                    MessageBox.Show(csucc + " User Registered  Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
                Clear();

            }


        }
        public void Clear()
        {
            txtCpass.Text = "";
            txtEmail.Text = "";
            txtFname.Text = "";
            txtMob.Text = "";
            txtPass.Text = "";
            txtUser.Text = "";

        }
    }
}

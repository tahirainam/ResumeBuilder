using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ResumeBuilder
{
    public partial class RegistrationForm: Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPhone_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtBoxPassword.Text, "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"))
            {
                txtPassword.Text = "Weak Password";
                txtPassword.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtPassword.Text = "Strong Password";
                txtPassword.ForeColor = System.Drawing.Color.Green;


            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Required Field
            if (txtBoxUserName.Text == "" || txtBoxEmail.Text == "")
            {
                MessageBox.Show("Please Fill all required Fields Properly..", "Incomplete Form");
                return;
            }


            //Password Matching
            if (txtBoxPassword.Text != txtBoxCPass.Text)
            {
                MessageBox.Show("Password do not match. Please Try Again", "Incomplete Form");
                return;
            }


            //Email Validation
            if (!Regex.IsMatch(txtBoxEmail.Text, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$"))
            {
                MessageBox.Show("Email is not in correct format", "Incomplete Form");
                return;
            }

            //Password Strenth
            if (!Regex.IsMatch(txtBoxPassword.Text, "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"))
            {
                MessageBox.Show("Password must contaain an upercase, a lower a symbol and must be 8 characters long ", "Weak Password");
                return;
            }

            using (SqlConnection con = new SqlConnection(
        @"Data Source=(LocalDB)\MSSQLLocalDB;
          AttachDbFilename=|DataDirectory|\RegistrationDB.mdf;
          Integrated Security=True"))
            {
                const string sql =
                    "INSERT INTO Table (Username, Email, Password) " +
                    "VALUES (@username, @email, @password)";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@username", txtBoxUserName.Text);
                    cmd.Parameters.AddWithValue("@email", txtBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtBoxPassword.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            MessageBox.Show("Account registered.");
        }
    }
}

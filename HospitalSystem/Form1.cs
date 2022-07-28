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

namespace HospitalSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=hospital;Integrated Security=True");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //String username = txtUserName.Text;
            //String pass = txtPassword.Text;

            //if (username == "alsamh" && pass == "17155943")
            //{
            //    //MessageBox.Show("Giriş Yapıldı");
            //    this.Hide();
            //    Dashboard ds = new Dashboard();
            //    ds.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Kullanıcı adı yada Şifre hatalı");
            //}

            String username = txtUserName.Text;
            String pass = txtPassword.Text;
            try
            {
                String querry = "SELECT * FROM Login_new WHERE username = '" + txtUserName.Text + "' AND password = '"+ txtPassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username = txtUserName.Text;
                    pass = txtPassword.Text;

                    MessageBox.Show("Giriş Yapıldı");
                    this.Hide();
                    Dashboard ds = new Dashboard();
                    ds.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı yada Şifre hatalı","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtUserName.Clear();
                    txtPassword.Clear();

                    txtUserName.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

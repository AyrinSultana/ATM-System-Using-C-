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

namespace ATM_System
{
    public partial class ChangePIN : Form
    {
        
        public ChangePIN()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AYRIN\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Pin1Tb.Text == "" ||Pin2Tb.Text == "")
            {
                MessageBox.Show("Enter and Confirm The New Pin");
            }
            else if(Pin2Tb.Text !=Pin1Tb.Text)

            {
                MessageBox.Show("Pin1 and Pin2 are Different");
            }
            else
            {

                
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set PIN=" + Pin1Tb.Text + "where Accnum='" + Acc + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIN Succesfully Updated");
                    Con.Close();
                    Login home = new Login();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();

        }

        private void ChangePIN_Load(object sender, EventArgs e)
        {

        }
    }
}

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

namespace ATM_System
{
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AYRIN\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;


        private void Deposit_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(DepoAmtTb.Text == "" || Convert.ToInt32(DepoAmtTb.Text) <= 0)
            {
                MessageBox.Show("Enter the Amount To Deposit");
            }
            else
            {
               
                newbalance = oldbalance + Convert.ToInt32(DepoAmtTb.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTbl set Balance="+ newbalance +" where Accnum='" + Acc + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sucess Deposit");
                    addtransaction();
                    Con.Close();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                    
            }
        }

        private void addtransaction()
        {
            string TrType = "Deposit";

            try
            {

                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "'," + DepoAmtTb.Text + ",'" + DateTime.Today.Date.ToString() + "')";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();

                Login log = new Login();
                log.Show();
                this.Hide();

            }
            catch (Exception Ex)
            { 
               MessageBox.Show(Ex.Message);          
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }
        int oldbalance, newbalance;

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           oldbalance = Convert.ToInt32 (dt.Rows[0][0].ToString());
            Con.Close();
        }

       
    }
}

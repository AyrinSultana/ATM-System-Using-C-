using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

          
        int starting = 0;
 

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            starting += 1;
            MyProgressBar.Value = starting;
            Percentage.Text = starting + "%";
            if (MyProgressBar.Value == 100)
            {
                MyProgressBar.Value = 0;
                timer1.Stop();
                Login log = new Login();
                this.Hide();
                log.Show();
            }
        }


  
    }

   
   
        
    }


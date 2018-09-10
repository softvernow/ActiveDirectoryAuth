using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveDirectoryAuth
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("advapi32.dll")]
        public static extern Boolean LogonUser(string name, string domain, string pass, int logType, int logpv, ref IntPtr pht);

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Username");
                return;
            }

            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Password");
                return;
            }
            IntPtr th = IntPtr.Zero;
            Boolean is_user_auth = LogonUser(txtUserName.Text, "HCA", txtPassword.Text, 2, 0,  ref th);


            if (is_user_auth)
                MessageBox.Show("User Authorized");
            else
                MessageBox.Show("Access Denied");

        }
    }
}

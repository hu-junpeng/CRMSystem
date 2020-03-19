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

namespace CRM_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbUser.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入用户名！");
                tbUser.Focus();
                return;
            }
            if(tbPWD.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入密码！");
              tbPWD.Focus();
                return;
            }
            common com = new common();
            database db = new database();
            int t = 0;
            string sql = "select count(*)from manager where username='" +tbUser.Text.Trim()+ "'and password='" + com.md5(tbPWD.Text.Trim()) + "'";
            t = db.runSqlInt(sql);
            if(t>0)
            {
                this.Hide();
                main fmain = new main();
                fmain.User = tbUser.Text.Trim();
                fmain.Show();
            }
            else
            {
                MessageBox.Show("用户名或者密码错误！");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ClientRegister cr = new ClientRegister();
            cr.Show();
        }
    }
}

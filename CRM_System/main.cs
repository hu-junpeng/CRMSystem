using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_System
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        private string user;

        public string User
        {
            get { return user; }
            set {  user= value; }
        }
        private void main_Load(object sender, EventArgs e)
        {

        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定退出系统?","退了对话框",MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定退出系统?", "退了对话框", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
            
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定退出系统?", "退了对话框", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }

        }

        private void lklblAddclient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Addclient ac = new Addclient();
            ac.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Addservice addservice = new Addservice();
            addservice.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddComplaint aC = new AddComplaint();
            aC.Show();
        }

        private void 管理客户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client cli = new client();
            cli.Show();
        }

        private void 添加服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addservice addservice = new Addservice();
            addservice.Show();
        }

        private void 添加投诉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddComplaint aC = new AddComplaint();
            aC.Show();
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePWD cp = new ChangePWD();
            cp.Show();
        }

        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }
    }
}

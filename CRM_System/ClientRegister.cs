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
    public partial class ClientRegister : Form
    {
        public ClientRegister()
        {
            InitializeComponent();
        }
        database db = new database();
        common com = new common();
        private void ClientRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i = db.runSqlInt("select count(*) from manager ");
            if (tbClient.Text.Trim().Length<=0)
            {
                MessageBox.Show("请输入用户名");
                tbClient.Focus();
                return;
            }
            if(tbPWD.Text.Trim().Length<=0)
            {
                MessageBox.Show("请输入密码");
                tbPWD.Focus();
                return;
            }
            if(tbPWDConfirm.Text.Trim().Length<=0)
            {
                MessageBox.Show("请再次输入确认密码");
                tbPWDConfirm.Focus();
                return;
            }
            if(db.runSqlInt("select count(*) from manager where username='"+tbClient.Text.Trim()+"'")>0)
            {
                
                db.runSql("update manager set password='" + com.md5(tbPWD.Text.Trim()) +"'where username='" + tbClient.Text.Trim() + "'");
                MessageBox.Show("该用户名已被注册");
            }
            else
            {
                db.runSql("insert into manager(id,username,password)values " + "('" +(i+1)+"','" + tbClient.Text.Trim() + "','" + com.md5(tbPWD.Text.Trim()) + "')");
                MessageBox.Show("注册成功！");
            }
            
        }
    }
}

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
    public partial class Addservice : Form
    {
        public Addservice()
        {
            InitializeComponent();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        database db = new database();

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectClient sc = new SelectClient();
            if(sc.ShowDialog()==DialogResult.OK)
            {
                tbServiceClient.Text = sc.Person;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(tbServiceTitle.Text.Trim().Length<=0)
            {
                MessageBox.Show("请输入服务的标题！");
                tbServiceTitle.Focus();
                return;
            }
            if(tbServiceClient.Text.Trim().Length<=0)
            {
                MessageBox.Show("请点击右侧按钮进行选择客户！");
                btnSelect.Focus();
                return;
            }
            if(tbServiceContent.Text.Trim().Length<=0)
            {
                MessageBox.Show("请输入服务内容");
                tbServiceContent.Focus();
                return;
            }
            db.runSql("insert into services(title,userName,serviceType,serviceMode,StartTime,EndTime,ServiceContent,feedback,note,result)values"+
                "('"+tbServiceTitle.Text.Trim()+"','"+tbServiceClient.Text.Trim()+"','"+ cbbServiceType.Text+"','"+cbbServiceMode.Text+"','"+
                dtpStartTime.Text+"','"+dtpEndTime.Text+"','"+tbServiceContent.Text+"','"+cbbServiceFeedBack.Text+"','"+tbServiceNote+"','"+cbbResult.Text+"')");
            MessageBox.Show("添加成功！");
        }
    }
}

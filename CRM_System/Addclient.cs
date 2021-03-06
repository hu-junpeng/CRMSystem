﻿using System;
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
    public partial class Addclient : Form
    {
        public Addclient()
        {
            InitializeComponent();
        }
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        common com = new common();
        database db = new database();

        private void Addclient_Load(object sender, EventArgs e)
        {
            try
            {
                com.bindComboBox(cbbNation, "select id,nation from nation order by id asc ");
                com.bindComboBox(cbbProvince,"select id,province from province order by id asc");
                com.bindComboBox(cbbCity, "select id,city from city order by id asc");
                cbbMarriage.SelectedIndex = 0;
                cbbGender.SelectedIndex = 0;
                cbbMarriage.SelectedIndex = 0;
                cbbSource.SelectedIndex = 0;
                cbbLevel.SelectedIndex = 0;
                cbbCulture.SelectedIndex = 0;
                cbbCon.SelectedIndex = 0;
                cbbEarning.SelectedIndex = 0;
                if (ID != 0)
                {
                    Text = "客户资料修改";
                    btnAdd.Text = "修改";
                    showClient(ID);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        private void showClient(int t)
        {
            SqlDataReader dr;
            db.runSql("select * from customer where id=" + t, out dr);
            if (dr.Read())
            {
                tbName.Text = dr["username"].ToString();
                com.cbbIndexByText(cbbNation, dr["nation"].ToString());
                dtpBirthday.Value = DateTime.Parse(dr["birthday"].ToString());
                com.cbbIndexByText(cbbGender, dr["gender"].ToString());
                tbIDCard.Text = dr["IDcard"].ToString();
                tbHobby.Text = dr["hobby"].ToString();
                com.cbbIndexByText(cbbMarriage, dr["marriage"].ToString());
                com.cbbIndexByText(cbbSource, dr["source"].ToString());
                com.cbbIndexByText(cbbLevel, dr["level"].ToString());
                com.cbbIndexByText(cbbEarning, dr["earning"].ToString());
                com.cbbIndexByText(cbbCon, dr["concernment"].ToString());
                tbMobile.Text = dr["mobile"].ToString();
                tbTel.Text = dr["tel"].ToString();
                tbQQ.Text = dr["qq"].ToString();
                tbEmail.Text = dr["email"].ToString();
                com.cbbIndexByText(cbbCulture, dr["culture"].ToString());
                com.cbbIndexByText(cbbProvince, dr["province"].ToString());
                com.cbbIndexByText(cbbCity, dr["city"].ToString());
                tbAddress.Text = dr["address"].ToString();
            }
            else
            {
                MessageBox.Show("你所要修改的项不存在，系统将自动关闭此窗体！");
                Close();
            }
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(tbName.Text.Trim().Length<=0)
            {
                MessageBox.Show("请输入客户名称");
                tbName.Focus();
                btnAdd.DialogResult = DialogResult.None;
                return;
            }
            if(cbbGender.SelectedIndex<0)
            {
                MessageBox.Show("请选择性别！");
                cbbGender.Focus();
                btnAdd.DialogResult = DialogResult.None;
                return;
            }
            if (cbbLevel.SelectedIndex < 0)
            {
                MessageBox.Show("请选择重要程度！");
                cbbLevel.Focus();
                btnAdd.DialogResult = DialogResult.None;
                return;
            }
            if(tbMobile.Text.Trim().Length<=0||tbTel.Text.Trim().Length<=0)
            {
                MessageBox.Show("请将电话号码和手机至少输入一个！");
                tbMobile.Focus();
                btnAdd.DialogResult = DialogResult.None;
                return;
            }
            string sql = "";
            string Rstatus = "添加";
            if(ID==0)
            {
                sql = @"insert into customer(username,nation,birthday,gender,IDcard,hobby,marriage,source,levels,earning,concernment,mobile,tel,QQ,Culture,Email,province,city,address,addtime)values" 
                + "('" + tbName.Text.Trim() + "','" + cbbNation.Text + "','" + dtpBirthday.Value + "','" + cbbGender.Text + "','" + cbbMarriage.Text + "','" + tbIDCard.Text.Trim() +
                "','" + tbHobby.Text.Trim() + "','" + cbbSource.Text + "','" + cbbEarning.Text + "','" + cbbLevel.SelectedItem + "','" + cbbCon.Text + "','" + tbMobile.Text.Trim() +
                "','" + tbTel.Text.Trim() + "','" + tbQQ.Text.Trim() + "','" + cbbCulture.Text + "','" + tbEmail.Text.Trim() + "','" + cbbProvince.Text + "','" + cbbCity.Text +
                "','" + tbAddress.Text.Trim() +"','"+DateTime.Now.ToString()+"')";

            }
            else
            {
                Rstatus = "修改";
                sql = "update customer set username='" + tbName.Text.Trim() + "',nation='" + cbbNation.Text + "',birthday='" + dtpBirthday.Value + "',gender='" + cbbGender.Text + "',marriage='" +
                cbbMarriage.Text + "',IDcard='" + tbIDCard.Text.Trim() + "',hobby='" + tbHobby.Text.Trim() + "',source='" + cbbSource.Text + "',levels='" + cbbLevel.SelectedItem + "',earning='" +
                cbbEarning.Text + "',concernment='" + cbbCon.Text + "',mobile='" + tbMobile.Text.Trim() + "',tel='" + tbTel.Text.Trim() + "',QQ='" + tbQQ.Text.Trim() + "',Culture='" + cbbCulture.Text +
                "',Email='" + tbEmail.Text.Trim() + "',province='" + cbbProvince.Text + "',city='" + cbbCity.Text + "',address='" + tbAddress.Text.Trim() + "',addtime='" + DateTime.Now.ToString() + "'where id='" + _id+"'";
            }
            db.runSql(sql);
            MessageBox.Show(Rstatus + "成功！");

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace silicon
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
             /*方法1 不连数据库
            //if (textBox1.Text == "cola")
            //if (textBox1.Text == "cola") 
            //{ 
               // MessageBox.Show("用户名cola,密码cola正确，正在跳转到主界面，登陆成功");
               // mf.Show();
            }*/
            /*方法2 不连数据库
            string name = textBox1.Text;
            string password = textBox2.Text;
            name = name.Trim();     // 空格不会有影响
            password = password.Trim();
            if (name.Equals("cola") && password.Equals("cola") || name.Equals("peisi") && password.Equals("peisi"))
            {
                MessageBox.Show("登陆成功！！！!");
                mf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("输入的用户名或密码有误，请重新输入！");
            }*/
            //方法3 连接数据库
            Mainforms mf = new Mainforms();
            if (username.Text.Trim() == "" | password.Text.Trim() == "")
            {
                MessageBox.Show("用户名跟密码不能为空");
                return;
            }
            string conn = @"Data Source=DESKTOP-FICTVAJ\SQLRXPRESS;Initial Catalog=Student;Integrated Security=True";
            SqlConnection connn = new SqlConnection(conn);
            connn.Open();
            string StrSQL = "select username from mima where username ='" + username.Text + "'and password ='" + password.Text + "'";
            SqlCommand com = new SqlCommand(StrSQL, connn);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                MessageBox.Show("登陆成功！！！!");
                mf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！请重新输入！");
                return;
            }
        }
        public string connectionString { get; set; }

    }
}

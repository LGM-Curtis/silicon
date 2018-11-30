using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace silicon
{
    public partial class serch : Form
    {
        public serch()
        {
            InitializeComponent();
        }

        private void studentsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.studentDataSet);

        }

        private void serch_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“studentDataSet.students”中。您可以根据需要移动或删除它。
            this.studentsTableAdapter.Fill(this.studentDataSet.students);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainforms mf1 = new Mainforms();
            mf1.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hang = studentsDataGridView.Rows.Count;//得到总行数     
            string strTxt = textBox1.Text;
            Regex r = new Regex(strTxt);
            for (int k = 0; k < hang; k++)
            {
                if (k == hang - 1)
                {
                    MessageBox.Show("查询失败,没有该学生，请重新查询");
                    return;
                }
                Match m = r.Match(studentsDataGridView.Rows[k].Cells[0].Value.ToString()); // 在字符串中模糊匹配   
                if (m.Success)
                {   //对比TexBox中的值是否与dataGridView中的值相同（上面这句）  
                    studentsDataGridView.CurrentCell = studentsDataGridView[0, k];//定位到相同的单元格  
                    if (MessageBox.Show("是否需要继续查找？", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        //如果选择了取消就会返回，可以接着输入进行查询；如果选择了确定,就会继续查找匹配的（其实已经找到匹配的数据，但再次寻找会直接报查询失败）.  
                        return;//返回  
                    }
                }
            }
        }
    }
}

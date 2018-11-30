using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace silicon
{
    public partial class Mainforms : Form
    {
        public Mainforms()
        {
            InitializeComponent();
        }

        private void studentsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.studentDataSet);

        }

        private void Mainforms_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“studentDataSet.students”中。您可以根据需要移动或删除它。
            this.studentsTableAdapter.Fill(this.studentDataSet.students);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serch s = new serch();
            s.Show();
        }
    }
}

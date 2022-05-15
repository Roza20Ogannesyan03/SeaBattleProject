using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattleProject
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            dGVLevel1.Rows.Add(4);
            GridField df1 = new GridField(4, 4, dGVLevel1);
            df1.LoadLevel();
            df1.ColorTheField();

            dGVLevel2.Rows.Add(5);
            GridField df2 = new GridField(5, 5, dGVLevel2);
            df2.LoadLevel();
            df2.ColorTheField();

            dGVLevel3.Rows.Add(6);
            GridField df3 = new GridField(6, 6, dGVLevel3);
            df3.LoadLevel();
            df3.ColorTheField();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLevel1 form1 = new FormLevel1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLevel2 form2 = new FormLevel2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormLevel3 form3 = new FormLevel3();
            form3.Show();
        }

        private void InstructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExample instr = new FormExample();
            instr.Show();
        }

       
    }
}

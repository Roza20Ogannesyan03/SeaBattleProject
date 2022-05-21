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
    public partial class FormLevel1 : Form
    {
        GridField gf;
        int stepIndex = 4;
        public FormLevel1()
        {
            InitializeComponent();
        }

        private void FormLevel1_Load(object sender, EventArgs e)
        {
            dgvMove1.Rows.Add(stepIndex);
            dgvMove1.ClearSelection();

            dgvField1.Rows.Add(4);
            gf = new GridField(4, 4, dgvField1,dgvMove1);
            gf.LoadLevel();
            gf.ColorTheField();

        }

        public void buttonMove_Click(object sender, EventArgs e)
        {
            gf.Click(sender,e);
        }

        private void buttonToRun_Click(object sender, EventArgs e)
        {
            gf.ToRun(stepIndex);
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            gf.Restart(stepIndex);
        }
    }
}

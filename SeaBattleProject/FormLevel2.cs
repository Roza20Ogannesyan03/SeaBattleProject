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
    public partial class FormLevel2 : Form
    {
        GridField gf;
        int stepIndex = 7;
        public FormLevel2()
        {
            InitializeComponent();
        }

        private void FormLevel2_Load(object sender, EventArgs e)
        {
            dgvMove2.Rows.Add(stepIndex);
            dgvMove2.ClearSelection();

            dgvField2.Rows.Add(5);
            gf = new GridField(5, 5, dgvField2, dgvMove2);
            gf.LoadLevel();
            gf.ColorTheField();

            dgvExample2.Rows.Add(5);
            dgvExample2.ClearSelection();

            dgvExample2.Rows[3].Cells[3].Style.BackColor = Color.FromArgb(128, 102, 255);
            dgvExample2.Rows[3].Cells[4].Style.BackColor = Color.FromArgb(128, 102, 255);
            dgvExample2.Rows[4].Cells[3].Style.BackColor = Color.FromArgb(128, 102, 255);

            dgvExample2.Rows[2].Cells[0].Style.BackColor = Color.FromArgb(255, 77, 166);
            dgvExample2.Rows[3].Cells[0].Style.BackColor = Color.FromArgb(255, 77, 166);
            dgvExample2.Rows[4].Cells[0].Style.BackColor = Color.FromArgb(255, 77, 166);

            dgvExample2.Rows[0].Cells[0].Style.BackColor = Color.FromArgb(179, 102, 255);
            dgvExample2.Rows[0].Cells[1].Style.BackColor = Color.FromArgb(179, 102, 255);
        }

        public void buttonMove_Click(object sender, EventArgs e)
        {
            gf.Click(sender, e);
        }

        private void buttonToRun_Click(object sender, EventArgs e)
        {
            gf.ToRun(stepIndex);
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            gf = new GridField(5, 5, dgvField2, dgvMove2);
            gf.LoadLevel();
            gf.ColorTheField();
            gf.Restart(stepIndex);
        }
    }
}

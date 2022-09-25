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
    public partial class FormLevel3 : Form
    {
        GridField gf;
        int stepIndex = 8;
        public FormLevel3()
        {
            InitializeComponent();
        }

        private void FormLevel3_Load(object sender, EventArgs e)
        {
            dgvMove3.Rows.Add(stepIndex);
            dgvMove3.ClearSelection();

            dgvField3.Rows.Add(6);
            gf = new GridField(6, 6, dgvField3, dgvMove3);
            gf.LoadLevel();
            gf.ColorTheField();

            dgvExample3.Rows.Add(6);
            dgvExample3.ClearSelection();

            dgvExample3.Rows[5].Cells[3].Style.BackColor = Color.FromArgb(255, 204, 255);
            dgvExample3.Rows[5].Cells[4].Style.BackColor = Color.FromArgb(255, 204, 255);
            dgvExample3.Rows[5].Cells[5].Style.BackColor = Color.FromArgb(255, 204, 255);

            dgvExample3.Rows[3].Cells[0].Style.BackColor = Color.FromArgb(179, 102, 255);
            dgvExample3.Rows[3].Cells[1].Style.BackColor = Color.FromArgb(179, 102, 255);
            dgvExample3.Rows[4].Cells[1].Style.BackColor = Color.FromArgb(179, 102, 255);
            dgvExample3.Rows[5].Cells[1].Style.BackColor = Color.FromArgb(179, 102, 255);

            dgvExample3.Rows[0].Cells[0].Style.BackColor = Color.FromArgb(255, 153, 238);
            dgvExample3.Rows[0].Cells[1].Style.BackColor = Color.FromArgb(255, 153, 238);
            dgvExample3.Rows[1].Cells[0].Style.BackColor = Color.FromArgb(255, 153, 238);
            dgvExample3.Rows[1].Cells[1].Style.BackColor = Color.FromArgb(255, 153, 238);

            dgvExample3.Rows[0].Cells[4].Style.BackColor = Color.FromArgb(128, 102, 255);
            dgvExample3.Rows[1].Cells[4].Style.BackColor = Color.FromArgb(128, 102, 255);
            dgvExample3.Rows[1].Cells[5].Style.BackColor = Color.FromArgb(128, 102, 255);
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
            gf = new GridField(6, 6, dgvField3, dgvMove3);
            gf.LoadLevel();
            gf.ColorTheField();
            gf.Restart(stepIndex);
        }
    }
}

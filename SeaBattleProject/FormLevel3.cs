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
        public FormLevel3()
        {
            InitializeComponent();
        }

        private void FormLevel3_Load(object sender, EventArgs e)
        {
            dgvMove3.Rows.Add(8);
            dgvMove3.ClearSelection();

            dgvField3.Rows.Add(6);
            gf = new GridField(6, 6, dgvField3, dgvMove3);
            gf.LoadLevel();
            gf.ColorTheField();
        }

        public void buttonMove_Click(object sender, EventArgs e)
        {
            gf.Click(sender, e);
        }

        private void buttonToRun_Click(object sender, EventArgs e)
        {
            gf.ToRun(8);
        }
    }
}

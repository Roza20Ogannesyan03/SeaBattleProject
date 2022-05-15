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
        public FormLevel2()
        {
            InitializeComponent();
        }

        private void FormLevel2_Load(object sender, EventArgs e)
        {
            dgvMove2.Rows.Add(6);
            dgvMove2.ClearSelection();

            dgvField2.Rows.Add(5);
            gf = new GridField(5, 5, dgvField2, dgvMove2);
            gf.LoadLevel();
            gf.ColorTheField();
        }

        public void buttonMove_Click(object sender, EventArgs e)
        {
            gf.Click(sender, e);
        }

        private void buttonToRun_Click(object sender, EventArgs e)
        {
            gf.ToRun(6);
        }
    }
}

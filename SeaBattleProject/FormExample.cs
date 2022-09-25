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
    public partial class FormExample : Form
    {
        GridField gf;
        public FormExample()
        {
            InitializeComponent();
        }

        private void FormExample_Load(object sender, EventArgs e)
        {

            dgvField1.Rows.Add(4);
            gf = new GridField(4, 4, dgvField1);
            gf.LoadLevel();
            gf.ColorTheField();

            dgvEnd.Rows.Add(4);
            dgvEnd.ClearSelection();
            dgvEnd.Enabled = false;

            dgvEnd.Rows[0].Cells[1].Style.BackColor = Color.Violet;
            dgvEnd.Rows[1].Cells[1].Style.BackColor = Color.Violet;
            dgvEnd.Rows[1].Cells[0].Style.BackColor = Color.Violet;

            dgvEnd.Rows[2].Cells[3].Style.BackColor = Color.Yellow;
            dgvEnd.Rows[2].Cells[2].Style.BackColor = Color.Yellow;
            dgvEnd.Rows[3].Cells[2].Style.BackColor = Color.Yellow;

            label1.Text = " Суть этой игры заключается в том,\n\nчтобы поменять кораблики расположенные\n\n" +
                    "друг напротив друга(на одной диагонали) \n\nместами. Форма корабликов не меняется!\n\n" +
               " Ходить корабликами по очереди,\n\n (сначала первый,потом второй и т.д.)\n\n не в разброс!";
        }
    }
}

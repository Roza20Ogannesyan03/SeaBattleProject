﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattleProject
{
    class GridField
    {
        public int Height;
        public int Width;
        public DataGridView Dgv;
        public DataGridView DgvMove;
        public int[,] field;
        public int[,] end;
        public int[,] move;
        public Button button;


        public GridField(int height, int width, DataGridView dgv)
        {
            Height = height;
            Width = width;
            Dgv = dgv;
            field = new int[Height, Width];
            end = new int[Height, Width];
            move = new int[8, 4];
        }

        public GridField(int height, int width, DataGridView dgv, DataGridView dgvMove)
        {
            Height = height;
            Width = width;
            Dgv = dgv;
            DgvMove = dgvMove;
            field = new int[Height, Width];
            end = new int[Height, Width];
            move = new int[8, 4];
        }
        public void LoadLevel()
        {
            var curDir = Environment.CurrentDirectory + @"/files";

            StreamReader file1 = new StreamReader(curDir + "/field2.txt");

            StreamReader file2 = new StreamReader(curDir + "/EndGame2.txt");

            if (new int[] { 4, 5, 6 }.Contains(Height))
            {
                file1 = new StreamReader(curDir + $"/field{Height - 3}.txt");
                file2 = new StreamReader(curDir + $"/EndGame{Height - 3}.txt");
            }

            for (int i = 0; i < Height; i++)
            {
                string[] s1 = file1.ReadLine().Split();
                string[] s2 = file2.ReadLine().Split();
                for (int j = 0; j < Width; j++)
                {
                    field[i, j] = int.Parse(s1[j]);
                    end[i, j] = int.Parse(s2[j]);
                }
            }
            file1.Close();
            file2.Close();
        }
        public void Colors(Color[] colors)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (field[i, j] == 1)
                        Dgv.Rows[i].Cells[j].Style.BackColor = colors[0];

                    else if (field[i, j] == 2)
                        Dgv.Rows[i].Cells[j].Style.BackColor = colors[1];

                    else if (field[i, j] == 3)
                        Dgv.Rows[i].Cells[j].Style.BackColor = colors[2];

                    else if (field[i, j] == 4)
                        Dgv.Rows[i].Cells[j].Style.BackColor = colors[3];

                    else Dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }
        public void ColorTheField()
        {
            Dgv.ClearSelection();
            Dgv.Enabled = false;
            int level = Height - 3;
            Color[] temp_mas1 = { Color.Yellow, Color.Violet, Color.White };
            Color[] temp_mas2 = { Color.DarkMagenta, Color.DeepPink, Color.BlueViolet, Color.White };
            Color[] temp_mas3 = { Color.FromArgb(255, 179, 242), Color.DarkOrchid, Color.Indigo, Color.HotPink, Color.White };
            if (level == 1)
                Colors(temp_mas1);
            if (level == 2)
                Colors(temp_mas2);
            if (level == 3)
                Colors(temp_mas3);
        }

        public void Click(object sender, EventArgs e)
        {
            button = (Button)sender;
            DgvMove.CurrentCell.Value = button.Image;
            move[DgvMove.CurrentCell.RowIndex, DgvMove.CurrentCell.ColumnIndex] =
                Convert.ToInt32(button.Tag.ToString());
            DgvMove.CurrentCell.Selected = false;
        }
       
        public bool TryStep(int StepShip, int y, int x, int[,] tempField)
        {

            if (StepShip == 4 && y - 1 >= 0)
            {
                if (field[x, y - 1] != 0 && tempField[x, y - 1] != field[x, y-1])
                {
                    korablivrezalis = true;
                    return false;
                }
                if (tempField[x, y - 1] == 0 || tempField[x, y] == tempField[x, y - 1])
                {
                    tempField[x, y - 1] = field[x, y];
                    return true;
                }
                return false;
            }

            if (StepShip == 3 && y + 1 < Height)
            {
                if (field[x, y + 1] != 0 && tempField[x, y + 1] != field[x, y + 1])
                {
                    korablivrezalis = true;
                    return false;
                }
                if (tempField[x, y + 1] == 0 || tempField[x, y] == tempField[x, y + 1])
                {
                    tempField[x, y + 1] = field[x, y];
                    return true;
                }
                return false;
            }

            if (StepShip == 2 && x + 1 <= Width - 1)
            {
                if (field[x + 1, y] != 0 && tempField[x + 1, y] != field[x + 1, y])
                {
                    korablivrezalis = true;
                    return false;
                }
                if (tempField[x + 1, y] == 0 || tempField[x, y] == tempField[x + 1, y])
                {
                    tempField[x + 1, y] = field[x, y];
                    return true;
                }
                return false;
            }

            if (StepShip == 1 && x - 1 >= 0)
            {
                if (field[x - 1, y] != 0 && tempField[x - 1, y] != field[x - 1, y])
                {
                    korablivrezalis = true;
                    return false;
                }
                if (tempField[x - 1, y] == 0 || tempField[x, y] == tempField[x - 1, y])
                {
                    tempField[x - 1, y] = field[x, y];
                    return true;
                }
            }
            return false;
        }

        public void Join(int[,] a, int number, int[,] a2)
        {
            int cnt = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (a[i, j] == number)
                    {
                        cnt++;
                        break;
                    }
                }
            }
            if (cnt != 0)
            {
                Delete(number, a2);
                ChangingLocationShip(a, a2);
            }

        }
        public void Delete(int num, int[,] arr2)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (arr2[i, j] == num)
                        arr2[i, j] = 0;
                }
            }
        }
        public void ChangingLocationShip(int[,] a1, int[,] a2)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (a1[i, j] != 0)
                        a2[i, j] = a1[i, j];
                }
            }
        }
        public bool korablivrezalis = false;
        public async void ToRun(int stepIndex)
        {
            var tempField = new int[Height, Width];
            bool win = true;
            for (int i = 0; i < stepIndex; i++)
            {
                win = true;
                var step1 = move[i, 0];
                var step2 = move[i, 1];
                var step3 = move[i, 2];
                var step4 = move[i, 3];

                var tempField1 = new int[Height, Width];
                var tempField2 = new int[Height, Width];
                var tempField3 = new int[Height, Width];
                var tempField4 = new int[Height, Width];
                for (int x = 0; x < Height; x++)
                {
                    for (int y = 0; y < Width; y++)
                    {

                        if (field[x, y] == 1 && step1 != 0)
                            win = TryStep(step1, y, x, tempField1);

                        else if (field[x, y] == 2 && step2 != 0)
                            win = TryStep(step2, y, x, tempField2);

                        else if (field[x, y] == 3 && step3 != 0)
                            win = TryStep(step3, y, x, tempField3);

                        else if (field[x, y] == 4 && step4 != 0)
                            win = TryStep(step4, y, x, tempField4);

                        if (win == false)
                        {
                            goto finish;
                        }
                    }
                }
                switch (Height)
                {
                    case 4:
                        Join(tempField1, 1, tempField);
                        Join(tempField2, 2, tempField);
                        break;
                    case 5:
                        Join(tempField1, 1, tempField);
                        Join(tempField2, 2, tempField);
                        Join(tempField3, 3, tempField);
                        break;
                    case 6:
                        Join(tempField1, 1, tempField);
                        Join(tempField2, 2, tempField);
                        Join(tempField3, 3, tempField);
                        Join(tempField4, 4, tempField);
                        break;
                }
                field = tempField;
                await Task.Delay(1000);
            }
            finish:
            ColorTheField();
            if (win && CheckWin()) MessageBox.Show("Поздравляю, вы выиграли!");
            else MessageBox.Show("Вы проиграли");
            if (korablivrezalis)
                MessageBox.Show("Корабли не должны столкнуться!");
        }


        public bool CheckWin()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (field[i, j] != end[i, j])
                    {
                        ColorTheField();
                        return false;
                    }
                }
            }
            return true;
        }

        public void Restart(int stepindex)
        {
            for (int i = 0; i < stepindex; i++)
            {
                switch (Height)
                {
                    case 4:
                        for (int j = 0; j < 2; j++)
                        {
                            DgvMove.Rows[i].Cells[j].Value = null;
                        }
                        break;
                    case 5:
                        for (int j = 0; j < 3; j++)
                        {
                            DgvMove.Rows[i].Cells[j].Value = null;
                        }
                        break;
                    case 6:
                        for (int j = 0; j < 4; j++)
                        {
                            DgvMove.Rows[i].Cells[j].Value = null;
                        }
                        break;
                }
            }
        }

    }
}


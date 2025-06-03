using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBolls3._0
{
    public partial class FormLevels : Form
    {
        int steps = 0;
        //public string level /*= "1"*/;
        public string claslevel;
        string[,] GameField = new string[6, 15];
        CreateField field = new CreateField();
        ClassClick clas = new ClassClick();

        public FormLevels()
        {
            InitializeComponent();
            field.ImgEmpty = Bitmap.FromFile("Images/Empty.png");
            field.ImgRedBall = Bitmap.FromFile("Images/RedBaloon_100.png");
            field.ImgOrangeBall = Bitmap.FromFile("Images/OrangeBaloon_100.png");
            field.ImgColumn = Bitmap.FromFile("Images/Column.png");
            field.ImgBottom = Bitmap.FromFile("Images/Bottom.png");
            field.ImgBlueBall = Bitmap.FromFile("Images/BlueBallon_100.png");
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CurrentColumn = e.ColumnIndex;
            int CurrentRow = e.RowIndex;
            bool RightColumn = clas.IsColumnRight(CurrentColumn, claslevel); 
            bool RighRow = clas.IsRowRight(CurrentRow, claslevel); 
            if (RightColumn && RighRow)
            {
                if (clas.IsNoCurrentBall(GameField, claslevel))
                {
                    bool RightPos = clas.IsPositionRight(GameField, claslevel, CurrentRow, CurrentColumn); 
                    if (RightPos)
                    {
                        clas.CooseBall(claslevel, dataGridView1, GameField, CurrentRow, CurrentColumn);
                    }
                    else MessageBox.Show("Нельзя так ходить!");
                }
                else
                {
                    while (GameField[CurrentRow + 1, CurrentColumn] == "N")
                    {
                        CurrentRow += 1;
                    }
                    if (GameField[CurrentRow, CurrentColumn] == "N")
                    {
                        bool IsBallPlaced = clas.PlaceBall(claslevel, dataGridView1, GameField, CurrentRow, CurrentColumn);
                        if (IsBallPlaced) steps++;
                    }
                    else MessageBox.Show("Нельзя так ходить");
                }
            }
            if (clas.IsFieldReady(GameField,claslevel)) 
            {
                FormUserName formUserName = new FormUserName();
                formUserName.steps = steps;
                formUserName.level = claslevel;
                formUserName.ShowDialog();
                DialogResult result = MessageBox.Show("Обновить поле?", "Вы победили!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    steps = 0;
                    field.BollColour(GameField, claslevel);
                    field.drawField(dataGridView1, GameField, claslevel);
                }
            }
        }
        private void FormLevel1_Load(object sender, EventArgs e)
        {
            dataGridView1.GridColor = Color.White;
            dataGridView1.Rows.Add(5);
            field.BollColour( GameField, claslevel);
            field.drawField(dataGridView1, GameField, claslevel);
        }
    }
}

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
        string[,] GameField = new string[6, 15];// Матрица, в которой будет программно создаваться поле
        CreateField field = new CreateField();
        ClassClick clas = new ClassClick();

        public FormLevels()//Присвоение в конструкторе класса значения фотографий к их переменным в классе креатефилд
        {
            InitializeComponent();
            field.ImgEmpty = Bitmap.FromFile("Images/Empty.png");
            field.ImgRedBall = Bitmap.FromFile("Images/RedBaloon_100.png");
            field.ImgOrangeBall = Bitmap.FromFile("Images/OrangeBaloon_100.png");
            field.ImgColumn = Bitmap.FromFile("Images/Column.png");
            field.ImgBottom = Bitmap.FromFile("Images/Bottom.png");
            field.ImgBlueBall = Bitmap.FromFile("Images/BlueBallon_100.png");
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//Всё, что является тыканьем пользователя по форме
        {
            int CurrentColumn = e.ColumnIndex;//Индекс тыкнутой колонки (берём из е)
            int CurrentRow = e.RowIndex;//Индекс тыкнутой строки
            bool RightColumn = clas.IsColumnRight(CurrentColumn, claslevel); //Тыкнул ли пользователь в колбочку
            bool RighRow = clas.IsRowRight(CurrentRow, claslevel); 
            if (RightColumn && RighRow)// Если тыкнул в колбочкуы
            {
                if (clas.IsNoCurrentBall(GameField, claslevel))//Нет ли уже взятого шарика
                {
                    bool RightPos = clas.IsPositionRight(GameField, claslevel, CurrentRow, CurrentColumn);//Тыкнул ли именно на шарик
                    if (RightPos)
                    {
                        clas.CooseBall(claslevel, dataGridView1, GameField, CurrentRow, CurrentColumn);//Метод, отвечает за выбор шарика
                    }
                    else MessageBox.Show("Нельзя так ходить!");
                }
                else//Если шарик уже был выбран
                {
                    while (GameField[CurrentRow + 1, CurrentColumn] == "N")//Сделано для того, чтобы шарик падал
                    {
                        CurrentRow += 1;//Если ниже выбранной ячейки пусто, то мы выбирвем нижнюю
                    }
                    if (GameField[CurrentRow, CurrentColumn] == "N")//Если выбранная ячейка пуста
                    {
                        bool IsBallPlaced = clas.PlaceBall(claslevel, dataGridView1, GameField, CurrentRow, CurrentColumn);//Ставим шарик
                        if (IsBallPlaced) steps++; 
                    }
                    else MessageBox.Show("Нельзя так ходить");
                }
            }
            if (clas.IsFieldReady(GameField,claslevel)) // Если игра окончена
            {
                FormUserName formUserName = new FormUserName();//Вызов формы ввода имени
                formUserName.steps = steps;//Присваиваем переменным steps и level из FormUserName значения переменных
                formUserName.level = claslevel;// steps и claslevel из этой формы
                formUserName.ShowDialog();
                DialogResult result = MessageBox.Show("Обновить поле?", "Вы победили!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    steps = 0;
                    field.BollColour(GameField, claslevel);//в матрице создаётся новое поле
                    field.drawField(dataGridView1, GameField, claslevel);//По этой матрице отрисовывается новое поле
                }
            }
        }
        private void FormLevel1_Load(object sender, EventArgs e)//При загрузке формы:
        {
            dataGridView1.GridColor = Color.White;
            dataGridView1.Rows.Add(5);
            field.BollColour( GameField, claslevel);//в матрице создаётся поле
            field.drawField(dataGridView1, GameField, claslevel);//По этой матрице отрисовывается  поле
        }
    }
}

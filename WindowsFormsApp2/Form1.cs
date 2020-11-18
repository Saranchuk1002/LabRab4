using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<Drinks> drinksList = new List<Drinks>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill(object sender, EventArgs e)
        {
            this.drinksList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2 (ну остаток от деления на 3)
                {
                    case 0:
                        this.drinksList.Add(Juice.Generate());
                        break;
                    case 1:
                        this.drinksList.Add(Alcohol.Generate());
                        break;
                    case 2:
                        this.drinksList.Add(Soda.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {

        }
        private void ShowInfo()
        {
            // заведем счетчики под каждый тип
            int juiceCount = 0;
            int alcoholCount = 0;
            int sodaCount = 0;

            // пройдемся по всему списку
            foreach (var fruit in this.drinksList)
            {
                // помните, что в списки у нас лежат фрукты,
                // то есть объекты типа Fruit
                // поэтому чтобы проверить какой именно фрукт
                // мы в данный момент обозреваем, мы используем ключевое слово is
                if (fruit is Juice) // читается почти как чистый инглиш, "если fruit есть Мандарин"
                {
                    juiceCount += 1;
                }
                else if (fruit is Alcohol)
                {
                    alcoholCount += 1;
                }
                else if (fruit is Soda)
                {
                    sodaCount += 1;
                }
            }

            // а ну и вывести все это надо на форму
            txtInfo.Text = "\tСок\tАлкоголь\tГазировка"; // буквы экнмлю, чтобы влезло на форму
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("\t{0}\t{1}\t\t{2}", juiceCount, alcoholCount, sodaCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.drinksList.Count == 0)
            {
                txtOut.Text = "В автомате не осталось напитков";
                return;
            }

            // взяли первый фрукт
            var drinks = this.drinksList[0];
            // тут вам не реальность, взятие это на самом деле создание указателя на область в памяти
            // где хранится экземпляр класса, так что если хочешь удалить, делай это сам
            this.drinksList.RemoveAt(0);

            txtOut.Text = drinks.GetInfo();

            // обновим информацию о количестве товара на форме
            ShowInfo();
        }
    }
}


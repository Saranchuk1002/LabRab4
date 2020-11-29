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
        private void NextElement()
        {
            var drink = new Drinks();

            if (drinksList.Count == 0)
            {
                txtInfo.Text = "";
            }
            else if (drinksList.Count == 0)
            {
                drink = new Drinks();
            }

            else
            {
                drink = drinksList[0];
            }
            txtInfo.Text += String.Format("\t{0}", drink.GetName());
           
            switch (drink.GetName())
           {
                case "Сок":
                    break;
                case "Газировка":
                    break;
                case "Алкоголь":
                    break;
                default:
                    break;
           }
            
        }
        private void btnRefill(object sender, EventArgs e)
        {
            this.drinksList.Clear();
            var rnd = new Random();
            txtOut.Text = "";
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // генерируем случайное число от 0 до 2 (ну остаток от деления на 3)
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
            NextElement();
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
            foreach (var drinks1 in this.drinksList)
            {

                if (drinks1 is Juice) 
                {
                    juiceCount += 1;
                }
                else if (drinks1 is Alcohol)
                {
                    alcoholCount += 1;
                }
                else if (drinks1 is Soda)
                {
                    sodaCount += 1;
                }
            }


            txtInfo.Text = "\tСок\tАлкоголь\tГазировка\tВам будет выдан:"; 
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("\t{0}\t{1}\t\t{2}", juiceCount, alcoholCount, sodaCount);
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.drinksList.Count == 0)
            {
                txtOut.Text = "В автомате не осталось напитков";
                return;
            }
            
            var drinks = this.drinksList[0];
            this.drinksList.RemoveAt(0);
            txtOut.Text = drinks.GetInfo();

            ShowInfo();
            NextElement();

        }
    }
}


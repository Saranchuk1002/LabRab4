using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp2
{
    public class Drinks
    {
        public static Random rnd = new Random();
        public int Volume = 0; // объем (общий у всех)
        public virtual String GetInfo()
        {
            var str = "Напиток";
            str += String.Format("\nОбъем (литры): {0}", this.Volume);
            return str;
        }
    }
    public enum FruiteType { Apple, Apricot, Banana, Grapefruit, Mango };
    public class Juice : Drinks
    {

        public FruiteType type = FruiteType.Apple;//Используемый фрукт
        public bool WithPulp = false; // наличие мякоти
        public override String GetInfo()
        {
            var str = "Сок-";
            str += base.GetInfo();
            str += String.Format("\nИспользуемый фрукт: {0}", this.type);
            str += String.Format("\nНаличие мякоти: {0}", this.WithPulp);
            return str;
        }
        public static Juice Generate()
        {
            return new Juice
            {
                Volume = 1 + rnd.Next(5) , // объем
                type = (FruiteType)rnd.Next(5), // рандомный фрукт
                WithPulp = rnd.Next() % 2 == 0 // наличие мякоти
            };
        }
    }

    public enum AlcoholType { Strong, Lite };
    public class Alcohol : Drinks
    {

        public int Fortress = 0; // крепость
        public AlcoholType type = AlcoholType.Strong; // тип
        public override String GetInfo()
        {
            var str = "Алкоголь-";
            str += base.GetInfo();
            str += String.Format("\nКрепость %: {0}", this.Fortress);
            str += String.Format("\nТип: {0}", this.type);
            return str;
        }
        public static Alcohol Generate()
        {
            var test = new Alcohol
            {
                Volume = rnd.Next(1, 5),
                type = (AlcoholType)rnd.Next(2),
                Fortress = 5
            };
            if (test.type == AlcoholType.Strong)
            {
                test.Fortress = rnd.Next(30, 41);
            }
            else 
            {
                test.Fortress = rnd.Next(3, 10);
            }
            return test;
        }
    }
        public enum SodaType { Fanta, Sprite, CocaCola, SevenUp };
        public class Soda : Drinks
        {

            public int BubblesNumber = 0; // количество пузырьков
            public SodaType type = SodaType.Sprite; // вид
            public override String GetInfo()
            {
                var str = "Газировка-";
                str += base.GetInfo();
                str += String.Format("\nКоличество пузырьков: {0}", this.BubblesNumber);
                str += String.Format("\nВид: {0}", this.type);
                return str;
            }
            public static Soda Generate()
            {
                return new Soda
                {
                    Volume = 1 + rnd.Next(5), // спелость от 0 до 100
                    BubblesNumber = 5 + rnd.Next() % 20, // количество долек от 5 до 25
                    type = (SodaType)rnd.Next(4)
                };
            }
        }
    }


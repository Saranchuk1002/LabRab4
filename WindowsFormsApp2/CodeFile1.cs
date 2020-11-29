using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp2
{
    public class Drinks
    {
        
        public int Volume = 0; // объем (общий у всех)
        public virtual String GetInfo()
        {
            var str = "Напиток";
            str += String.Format("\nОбъем (литры): {0}", this.Volume);
            return str;
        }
        public virtual string GetName() 
        { 
            return "\tЭто последний элемент"; 
        }
        public static Random rnd = new Random();
    }
    public enum FruiteType { Apple, Apricot, Banana, Grapefruit, Mango };//фрукты
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
        public override string GetName()
        {
            return "\tСок";
        }
    }

    public enum AlcoholType { Strong, Lite };
    public class Alcohol : Drinks
    {

        public int Fortress = 0; // крепость
        public AlcoholType type = AlcoholType.Strong; // тип алкоголя
        public override String GetInfo()
        {
            var str = "Алкоголь-";
            str += base.GetInfo();// объем
            str += String.Format("\nКрепость %: {0}", this.Fortress);// крепость
            str += String.Format("\nТип: {0}", this.type);// тип алкоголя
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
            // вывод типа алкоголя, согласно напитку (если Lite, то от 3 до 10 )
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
        public override string GetName() 
        { 
            return "\tАлкоголь"; 
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
                    Volume = 1 + rnd.Next(5), // объем
                    BubblesNumber = 5 + rnd.Next() % 20, // количество пузырьков
                    type = (SodaType)rnd.Next(4)//вид напитка
                };
            }
        public override string GetName() 
        { 
            return "\tГазировка"; 
        }
    }
    }


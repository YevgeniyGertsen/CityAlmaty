using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace City.AlmatyLib
{
    public delegate void myDel(string msg, DateTime date, int type=104);
    public class Firefighter
    {
        myDel FireDel;
        public Firefighter()
        {

        }
        public Firefighter(myDel del)
        {
            FireDel = del;
        }
        public void DoEvent(string Address)
        {
            Random rnd = new Random();

            FireDel?.Invoke("Вызов принят", DateTime.Now);
            FireDel?.Invoke("Бригада выехала на ", DateTime.Now);
            for(int i = 0; i < rnd.Next(10, 30); i++)
            {
                Thread.Sleep(50);
                Console.Write(".");
            }
            Console.WriteLine("");
            FireDel?.Invoke("Бригада приехала",DateTime.Now);
            for (int i = 0; i < rnd.Next(10, 30); i++)
            {
                Thread.Sleep(50);
                Console.Write(".");
            }
            Console.WriteLine("");
            FireDel?.Invoke("Пожар потушен ", DateTime.Now);

        }
    }
}

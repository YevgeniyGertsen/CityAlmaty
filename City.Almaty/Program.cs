using System;
using System.Threading;
using City.AlmatyLib;
using LiteDB;
namespace City.Almaty
{
    class Program
    {
        public enum Events
        {
            Fire=104,
            Ambulance=103,
            Police=102
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Firefighter fr = new Firefighter(WriteMSG);
            for (int i = 0; i < rnd.Next(); i++)
            {
                Thread.Sleep(100);
                int ev = rnd.Next(102,104);
                fr.DoEvent("Улица пушкина");
            }
        }
        public void WriteMSG(string msg, DateTime time, int evt)
        {
            using (var db = new LiteDatabase(@"myDataDb.db"))
            {
                var evtLogs = db.GetCollection<EventsLog>("EventsLog");
                EventsLog evt = new EventsLog(msg, time, evt);
                col.Insert(evt);
                Console.WriteLine(evt);
            }
        }


    }
}

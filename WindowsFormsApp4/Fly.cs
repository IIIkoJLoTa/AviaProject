using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    internal class Fly
    {
        internal string departure;
        internal DateTime departuretime;
        internal string arrival;
        internal DateTime arrivaltime;
        internal double price;

        internal Fly(string Departure, DateTime DepartureTime, string Arrival, DateTime ArrivalTime, double Price)
        {
            departure = Departure;
            departuretime = DepartureTime;
            arrival = Arrival;
            arrivaltime = ArrivalTime;
            price = Price;
        }
    }
}

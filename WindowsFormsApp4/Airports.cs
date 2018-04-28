using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    //Класс для определения связи между аэропортами 
    internal class Airports
    {
        internal string iataCode; 
        internal string City;
        internal double latitude; // Координаты по широте
        internal double longitude; // Координаты по долготе
        internal List<string> routes = new List<string>(); // Список с путями 
        internal Airports(string iatacode, string city, double lat, double longi, List<string> rotes)
        {
            iataCode = iatacode;
            City = city;
            latitude = lat;
            longitude = longi;
            routes = rotes;
        }
    }
}

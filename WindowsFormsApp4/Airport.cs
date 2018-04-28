using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    // Класс для определения аэропорта
    internal class Airport
    {
        internal string iataCode; // Код аэропорта
        internal string City; 
        internal double latitude; // Координаты по широте
        internal double longitude; // Координаты по долготе
        internal Airport(string iatacode, string city, double lat, double longi)
        {
            iataCode = iatacode;
            City = city;
            latitude = lat;
            longitude = longi;
        }
    }
}

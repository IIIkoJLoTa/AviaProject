using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FlyInfo : UserControl
    {
        Fly fly;
        internal FlyInfo(Fly fl)
        {
            fly = fl;
            InitializeComponent();
            
        }

        private void FlyInfo_Load(object sender, EventArgs e)
        {
            departuretime.Text = fly.departuretime.Hour.ToString()+ ":"+fly.departuretime.Minute.ToString();
            arrivaltime.Text = fly.arrivaltime.Hour.ToString() + ":" + fly.arrivaltime.Minute.ToString();
            arrival.Text = fly.arrival;
            depatrure.Text = fly.departure;
            departureDate.Text = fly.departuretime.ToShortDateString().ToString() + "," + fly.departuretime.DayOfWeek.ToString();
            arrivalDate.Text = fly.departuretime.ToShortDateString().ToString() + "," + fly.departuretime.DayOfWeek.ToString();
            price.Text = fly.price + ((char)0x20AC).ToString();
        }
    }
}

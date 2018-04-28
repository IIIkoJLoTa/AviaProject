using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
namespace WindowsFormsApp4
{
    internal partial class RyanAirApi : Form
    {
        public WebClient _web = new WebClient();
        GMapOverlay MarkersOverlay = new GMapOverlay();
        List<Fly> FlyList = new List<Fly>();
        List<Airport> allAirpots = new List<Airport>();
        List<Country> countries = new List<Country>();
        public string departure { get; set; } // Выбытие 
        public string arrival { get; set; } // Прибытие 

        public RyanAirApi()
        {
            InitializeComponent();
        }
        //Метод для загрузки стран с их названиями и кодом
        public void LoadAllCountries()
        {
            dynamic dataCountrys = JsonConvert.DeserializeObject(_web.DownloadString("https://api.ryanair.com/aggregate/3/common?embedded=countries"));
            foreach (var c in dataCountrys.countries)
            {
                countries.Add(new Country(Convert.ToString(c.code), Convert.ToString(c.name)));
            }
        }
        // Прогрузка карты
        public void LoadMap()
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(54.8993, 25.3239);
            gMapControl1.MinZoom = 3;
            gMapControl1.MaxZoom = 11;
            gMapControl1.Zoom = 4;
            gMapControl1.AutoScroll = true;
            dynamic dataAirports = JsonConvert.DeserializeObject(_web.DownloadString("https://api.ryanair.com/aggregate/3/common?embedded=airports"));
            foreach (var c in countries)
            {
                foreach (var s in dataAirports.airports)
                {
                    if (c.CountryCode == Convert.ToString(s.countryCode))
                    {
                        List<string> routes = new List<string>();
                        foreach (var a in s.routes)
                        {
                            string value = Convert.ToString(a);
                            if (value.Contains("airport"))
                            {
                                value = value.Split(':')[1];
                                routes.Add(value);
                            }
                        }
                        allAirpots.Add(new Airport(Convert.ToString(s.iataCode), Convert.ToString(s.name), Convert.ToDouble(s.coordinates.latitude), Convert.ToDouble(s.coordinates.longitude)));
                        c.airports.Add(new Airports(Convert.ToString(s.iataCode), Convert.ToString(s.name), Convert.ToDouble(s.coordinates.latitude), Convert.ToDouble(s.coordinates.longitude), routes));
                        AddMarker(Convert.ToDouble(s.coordinates.latitude), Convert.ToDouble(s.coordinates.longitude), Convert.ToString(s.name), Convert.ToString(s.iataCode));
                    }
                }
            }
            ShowOverlay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.Orange;
            button1.FlatAppearance.BorderSize = 1;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.Orange;
            button2.FlatAppearance.BorderSize = 1;
            LoadAllCountries();
            LoadMap();
        }
        //Метод для добавления маркера на карту в зависимости от местоположения аэропорта
        private void AddMarker(double latitude,double longitude,string name,string iataCode)
        {
            var marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(latitude), Convert.ToDouble(longitude)), new Bitmap("marker1.png"));
            marker.ToolTipText = Convert.ToString(name + "(" + iataCode + ")");
            marker.ToolTip.Foreground = Brushes.DeepPink;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(20, 20);
           // marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTip.Format.Trimming = StringTrimming.EllipsisWord;
            MarkersOverlay.Markers.Add(marker);
        }
        //Работа со слоями
        private void ShowOverlay()
        {
            gMapControl1.Overlays.Add(MarkersOverlay);
            gMapControl1.Zoom++;
            gMapControl1.Zoom--;
        }
        // Обработчки событий при нажатии на маркер
        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (String.IsNullOrEmpty(departure))
            {
                departure = GetIOTA(item.ToolTipText.ToString());
                textBox1.Text = item.ToolTipText.ToString();
                showRoutes();
            }
            else
            {
                arrival = GetIOTA(item.ToolTipText.ToString());
                textBox2.Text = item.ToolTipText.ToString();
                ShowRoute();
            }
        }

        private string GetIOTA(string item)
        {
            return item.Split('(')[1].Split(')')[0];
        }
        //Метод для отображения маршрута
        private void showRoutes()
        {
            MarkersOverlay.Clear();
            foreach (var c in countries)
            {
                foreach (var s in c.airports)
                {
                    if (s.iataCode == departure)
                    {
                        foreach (var a in s.routes)
                        {
                            foreach (var q in allAirpots) {
                                if (q.iataCode == a) {
                                    AddMarker(Convert.ToDouble(q.latitude), Convert.ToDouble(q.longitude),Convert.ToString(q.City), Convert.ToString(q.iataCode));
                                }
                            }
                        }
                    }
                }
            }
            ShowOverlay();
        }
        //Метод для поиска всех рейсов в зависимости от выбранных стран и времени 
        private void Search(object sender, EventArgs e)
        {
            FlyList.Clear();
            for (DateTime departureDateT = dateTimePicker1.Value; departureDateT <= dateTimePicker2.Value; departureDateT = departureDateT.AddDays(1))
            {
                string outboundDepartureDateFrom = departureDateT.ToString("yyyy-MM-dd");
                dynamic dataAirports = JsonConvert.DeserializeObject(_web.DownloadString("https://api.ryanair.com/farefinder/3/oneWayFares?&arrivalAirportIataCode=" + arrival + "&departureAirportIataCode=" + departure + "&language=en&market=en-gb&offset=0&outboundDepartureDateFrom=" + outboundDepartureDateFrom + "&outboundDepartureDateTo=" + outboundDepartureDateFrom + "&currency=EUR"));
                if (dataAirports.total > 0)
                {

                    string departurename = Convert.ToString(dataAirports.fares[0].outbound.departureAirport.name) + "(" + dataAirports.fares[0].outbound.departureAirport.iataCode + ")";
                    string arrivalname = Convert.ToString(dataAirports.fares[0].outbound.arrivalAirport.name) + "(" + dataAirports.fares[0].outbound.arrivalAirport.iataCode + ")";
                    DateTime departureDate = Convert.ToDateTime(dataAirports.fares[0].outbound.departureDate);
                    DateTime arrivalDate = Convert.ToDateTime(dataAirports.fares[0].outbound.arrivalDate);
                    double price = Convert.ToDouble(dataAirports.fares[0].outbound.price.value);
                    FlyList.Add(new Fly(departurename, departureDate, arrivalname, arrivalDate, price));
                }
            }
            ShowFly();
        }
        //Отображения полноценной информации о перелёте
        public void ShowFly()
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                MessageBox.Show("Вы не выбрали страну вылета (прилёта)!");
            }
            else
            {
                FlyInfoModal fl = new FlyInfoModal(FlyList);
                fl.StartPosition = FormStartPosition.CenterParent;
                fl.Show();
                this.Hide();
            }
            //if (FlyList.Count > 0)
            //{
            //    foreach (var x in FlyList)
            //    {
            //        richTextBox1.Text += "Вылет из " + x.departure + " в " + x.departuretime + " Прилёт в " + x.arrival + " в " + x.arrivaltime + " Цена:" + x.price + " EUR\n";
            //    }
            //}
            //else {
            //    richTextBox1.Text += "Нет перелётов";
            //}
        }
        // Очистка полей для повторного выбора
        private void ClearData(object sender, EventArgs e)
        {
            MarkersOverlay.Clear();
            gMapControl1.Overlays.Clear();
            LoadMap();
            departure = null;
            arrival = null;
            textBox1.Text = null;
            textBox2.Text = null;
        }
        // Отображения маршрута 
        private void ShowRoute()
        {
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            MarkersOverlay.Clear();
            foreach (var c in allAirpots)
            {
                if (c.iataCode == departure)
                {
                    AddMarker(Convert.ToDouble(c.latitude), Convert.ToDouble(c.longitude), Convert.ToString(c.City), Convert.ToString(c.iataCode));
                    points.Add(new PointLatLng(c.latitude, c.longitude));
                }
                else if (c.iataCode == arrival)
                {
                    AddMarker(Convert.ToDouble(c.latitude), Convert.ToDouble(c.longitude), Convert.ToString(c.City), Convert.ToString(c.iataCode));
                    points.Add(new PointLatLng(c.latitude, c.longitude));
                }
            }
            GMapRoute route = new GMapRoute(points, " ");
            route.Stroke.Width = 2;
            route.Stroke.Color = Color.DeepPink;
            routes.Routes.Add(route);
            gMapControl1.Overlays.Add(routes);
            gMapControl1.Zoom++;
            gMapControl1.Zoom--;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.Models;

namespace lawrukmvc.ViewModels
{
    public class MetroStationsViewModel
    {
        public List<MetroStation> RedStations { get; set; }
        public List<MetroStation> BlueOrangeStations { get; set; }
        public List<MetroStation> GreenYellowStations { get; set; }
    }
}

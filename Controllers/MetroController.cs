using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;
using lawrukmvc.Helpers;

namespace lawrukmvc.Controllers
{
    public class MetroController : Controller
    {
        public ActionResult Index(string tag)
        {
            if (tag != "")
            {
                return View("Metro", GetStation(tag));
            }
            else
            {
                return View(GetMetroStations());
            }            
        }

        private MetroViewModel GetStation(string tag)
        {
            List<MetroStation> metroStations = GetStations();
            tag = tag.ToLower().Replace("-", "").Replace("_", "");
            var metroStation = metroStations.FirstOrDefault(m => m.Tag.Replace("-", "") == tag);            
            var viewModel = new MetroViewModel();
            viewModel.CurrentMetroStation = metroStation;
            viewModel.CurrentMetroStation.Body = MetroStationBody(viewModel.CurrentMetroStation.Id);
            viewModel.MetroStations = metroStations;
            return viewModel;                      
        }

        private MetroStationsViewModel GetMetroStations()
        {
            var model = new MetroStationsViewModel();
            var stations = GetStations();
            model.RedStations = stations.Where(m => m.Lines.Contains(MetroLine.Red)).ToList();
            model.BlueOrangeStations = stations.Where(m => m.Lines.Contains(MetroLine.Orange)
                || m.Lines.Contains(MetroLine.Blue)).ToList();               
            model.GreenYellowStations = stations.Where(m => m.Lines.Contains(MetroLine.Green) 
                || m.Lines.Contains(MetroLine.Yellow)).ToList();
            return model;
        }

        private static string MetroStationBody(int id)
        {
            string tables = HTMLParser.GetTables("http://www.wmata.com/rider_tools/pids/showpid.cfm?station_id=" + id.ToString());
            
            tables = tables.Replace("<img src=\"/img/icon-marble-","");

            //TODO:foreach upper
            string[] lines = new string[] { "red", "orange", "blue", "green", "yellow" };
            foreach (string line in lines)
            {
                tables = tables.Replace(".gif\" alt=\"" + line + "\">","");
                tables = tables.Replace(line, "<span class=\"circle circle-" + line + "\">&nbsp;</span>");            
            }
            //tables = tables.Replace("Line", "LINE").Replace("Cars", "CARS").Replace("Destination", "DEST").Replace("Minutes", "MIN");
            return tables;
            //string html = "";
            //string url = "http://www.wmata.com/rider_tools/pids/showpid.cfm?station_id=" + id.ToString();
            //html = DownloadString(url);            
            //int start = html.IndexOf("<table");
            //int end = html.IndexOf("Last Data Update");
            //html = html.Substring(start, end - start - 15);
            //html = html.Replace("/img/", "http://www.wmata.com/img/");
            //html = html.Replace("width: 300px;", "float:left; width: 300px;");
            //html = html.Replace("margin: 10px auto;", "margin: 10px auto; margin-right:200px;");            
            //return html;
        }

        private List<MetroStation> GetStations()
        {
            var metroStations = new List<MetroStation>()
            {
                {new MetroStation(1, "metro-center","Metro Center", new MetroLine[] {MetroLine.Red, MetroLine.Orange, MetroLine.Blue})},
                {new MetroStation(82, "lenfant-plaza","L'Enfant Plaza", new MetroLine[] {MetroLine.Yellow, MetroLine.Green, MetroLine.Orange, MetroLine.Blue})},
                {new MetroStation(59, "capitol-south","Capitol South", new MetroLine[] {MetroLine.Orange, MetroLine.Blue})},
                {new MetroStation(25, "union-station","Union Station",new MetroLine[] {MetroLine.Red})},
                {new MetroStation(6, "dupont-circle","Dupont Cirle",new MetroLine[] {MetroLine.Red})},
                {new MetroStation(8, "cleveland-park","Cleveland Park",new MetroLine[] {MetroLine.Red})},
                {new MetroStation(10, "tenleytown-au","Tenleytown-AU",new MetroLine[] {MetroLine.Red})},
                {new MetroStation(12, "bethesda","Bethesda",new MetroLine[] {MetroLine.Red})},
                {new MetroStation(17 , "rockville","Rockville",new MetroLine[] {MetroLine.Red})},
                {new MetroStation(41, "rosslyn","Rosslyn", new MetroLine[] {MetroLine.Orange, MetroLine.Blue})},
                {new MetroStation(100, "east-falls-church","East Falls Church", new MetroLine[] {MetroLine.Orange})},
                {new MetroStation(101, "west-falls-church","West Falls Church", new MetroLine[] {MetroLine.Orange})},
                {new MetroStation(63, "stadium","Statium Armory", new MetroLine[] {MetroLine.Orange})},
                {new MetroStation(48, "king-street","King Street", new MetroLine[] {MetroLine.Yellow})},
                {new MetroStation(93, "reagan","Reagan", new MetroLine[] {MetroLine.Green, MetroLine.Yellow})},
                {new MetroStation(43, "pentagon","Pentagon", new MetroLine[] {MetroLine.Green, MetroLine.Yellow})},                             
                {new MetroStation(28, "fort-totten","Fort Totten", new MetroLine[] {MetroLine.Green, MetroLine.Red})},
                {new MetroStation(75, "columbia-heights","Columbia Heights", new MetroLine[] {MetroLine.Green})},
                {new MetroStation(85, "anacostia","Anacostia", new MetroLine[] {MetroLine.Green})},
                {new MetroStation(14, "grosvenor","Grosvenor", new MetroLine[] {MetroLine.Red})}
             };
            //metroStations.Add(new MetroStation(, MetroLine.Green));
            //metroStations.Add(new MetroStation(85, "anacostia","Anacostia",MetroLine.Green));
            //metroStations.Add(new MetroStation(14, "grosvenor","Grosvenor",MetroLine.Red));  
            metroStations =  metroStations.OrderBy(s=>s.Title).ToList();
            return metroStations;
        }

    }
}

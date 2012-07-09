using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Data;
using System.Text.RegularExpressions;
using lawrukmvc.Models;
using lawrukmvc.ViewModels;
using lawrukmvc.Helpers;
using HtmlAgilityPack;

namespace lawrukmvc.Controllers
{
    public class MarcController : Controller
    {        

        public ActionResult Index(string tag)
        { 
            var viewModel = new ViewModels.MarcLineViewModel();

            HtmlNode tableNode = HTMLParser.GetTable2("http://www.marctracker.com/PublicView/status.html", 2);
            tableNode = HTMLParser.GetNode(tableNode, "tr", 1);
            tableNode = HTMLParser.GetNode(tableNode, "td", 1);
           
            var lines = new Dictionary<string, int[]>();
            lines.Add("Camden", new int [] {0,1});
            lines.Add("Penn", new int [] {4,5});
            lines.Add("Brunswick", new int [] {2,3});         


            int[] indexes = {2,3};//brunswick is the default
            KeyValuePair<string, int[]> line = lines.FirstOrDefault(kvp => kvp.Key.ToLower() == tag.ToLower());
            if (line.Key != null)
            {
                indexes = line.Value;
                viewModel.Title = line.Key;
            }
            else
            {
                viewModel.Title = lines.Where(kvp => kvp.Value.Contains(3)).First().Key;
            }

            var trains = new List<MarcTrainViewModel>();            
            
            foreach (int i in indexes)
            {
                var node = HTMLParser.GetNode(tableNode, "table", i);
                var trs = node.SelectNodes("tr");
                foreach (HtmlNode tr in trs)
                {
                    if (!tr.OuterHtml.ToLower().Contains("colspan"))
                    {
                        var tds = tr.SelectNodes("td");
                        if (tds != null)
                        {
                            var train = new MarcTrainViewModel();
                            train.TrainNumber = tds[1].InnerText;
                            //Penn Hack
                            if (i == 4)
                            {
                                train.TrainNumber = "North " + train.TrainNumber;
                            }
                            else if (i==5)
                            {
                                train.TrainNumber = "South " + train.TrainNumber;
                            }
                            train.NextStation = tds[2].InnerText;
                            train.EstDepart = tds[3].InnerText;
                            train.Status = tds[4].InnerText;
                            train.Delay = tds[5].InnerText;
                            train.LastUpdate = tds[6].InnerText;
                            train.Message = tds[7].InnerText;
                            trains.Add(train);
                        }
                    }
                }                
            }
            viewModel.Trains = trains;
            return View(viewModel);
        }

    }
}

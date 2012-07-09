using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;
using lawrukmvc.Helpers;

namespace lawrukmvc.ViewModels
{
    public class VideoViewModel : ListItem, ITitleUrl
    {
        public Video Video { get; set; }
        public List<VideoViewModel> RelatedVideos { get; set; }

        public override string ThumbnailUrl
        {
            get
            {
                return "http://i.ytimg.com/vi/" + Video.YouTubeId + "/default.jpg";
            }
            set
            {
                base.ThumbnailUrl = value;
            }
        }

        public VideoViewModel() {}

        public VideoViewModel(Video video)
        {
            this.Video = video;            
        }
    }
      
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lawrukmvc.ViewModels;
using System.Data;
using System.Data.Objects.DataClasses;

namespace lawrukmvc.Controllers
{
    public class VideoController : BaseController
    {        


        public override object GetListModel(bool editMode)
        {
            var videos = lawrukRepository.GetVideoViewModels();
            var thumbnailList = new ThumbnailListViewModel();
            thumbnailList.Items = videos;
            thumbnailList.EditMode = editMode;
            return thumbnailList;
        }

        public override object GetTaggedList(string tag)
        {
            return base.GetTaggedList(tag);
        }

        public override EntityObject NewItem()
        {
            return new Video();
        }

        public override EntityObject GetItem(int id)
        {
            return GetVideo(id);
        }

        private Video GetVideo(int id)
        {
            return lawrukEntities.Videos.FirstOrDefault(i => i.Id == id);
        }

        public override object GetDetailModel(int id)
        {
            var video = GetVideo(id);
            var viewModel = new VideoViewModel(video);
            //viewModel.RelatedVideos = lawrukRepository.GetVideoViewModels();
            viewModel.RelatedVideos = new List<VideoViewModel>();
            return viewModel;
        }

        public override EntityObject PopulateItem(EntityObject item)        
        {
            Video video = item as Video;
            video.YouTubeId = Request.Params["youtubeid"];
            video.Title = Request.Params["title"];
            video.Date = DateTime.Parse(Request.Params["date"]);
            return video;
        }

    }
}

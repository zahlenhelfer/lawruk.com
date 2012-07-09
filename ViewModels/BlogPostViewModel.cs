using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lawrukmvc.Models;
using lawrukmvc.Helpers;

namespace lawrukmvc.ViewModels
{
    public class BlogPostListViewModel
    {
        public List<BlogPostViewModel> BlogPostViewModels { get; set; }
        public bool EditMode { get; set; }
    }

    public class BlogPostViewModel : ITitleUrl
    {
        public BlogPost BlogPost { get; set; }
        public List<ListItem> RelatedPosts { get; set; }
        public bool EditView { get; set; }
        public string DisplayDate
        {
            get { return this.BlogPost.Date.GetShortDisplay(); }
        }

        public string Url
        {
            get { return "/blog/" + this.BlogPost.Id + "/" + this.BlogPost.Title.ToUrl(); }
        }

        public BlogPostViewModel(BlogPost blogPost)
        {
            this.BlogPost = blogPost;
            this.RelatedPosts = new List<ListItem>();
        }

        public string Title
        {
            get { return BlogPost.Title; }
        }        

        public string EditLink
        {
            get
            {
                return "<a href=\"/blog/edit/" + BlogPost.Id + "\">Edit</a>";
            }

        }
    }
}

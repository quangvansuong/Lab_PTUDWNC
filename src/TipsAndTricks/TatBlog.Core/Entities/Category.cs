using System;
using System.Collections.Generic;
using System.Text;
using TatBlog.Core.Constracts;


namespace TatBlog.Core.Entities
{
    public class Category
    {
       public int ID {get; set;}
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Decsription { get; set; }
        public bool ShowOnMenu { get; set; } 
        public IList<Post> Posts { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using TatBlog.Core.Entities;
using TatBlog.Core.Constracts;

namespace TatBlog.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDesciption { get; set; }
        public string Decsription { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public string ImageUrl { get; set; }
        public int ViewCount { get; set; }
        public bool Published { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime? ModifedDate { get; set; }

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
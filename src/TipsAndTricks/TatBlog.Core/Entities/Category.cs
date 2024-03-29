﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities;

// Chuyên mục chủ đề
public class Category : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Định danh dùng để tạo URL
    public string UrlSlug { get; set; }
    public string Description { get; set; }
    public bool ShowOnMenu { get; set; }
    public IList<Post> Posts { get; set; }

}

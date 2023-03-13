using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;
        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();
            if (_dbContext.Posts.Any()) return;

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
        }
        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName = "Jason Mouth",
                    UrlSlug = "jason-mouth",
                    Email = "json@gmail.com",
                    JoinedDate = new DateTime(2022,10,21)
                },
                 new()
                {
                    FullName = "Tom",
                    UrlSlug = "tom-mouth",
                    Email = "M10@gmail.com",
                    JoinedDate = new DateTime(2022,10,21)
                },
                  new()
                {
                    FullName = "Jason",
                    UrlSlug = "jason-key",
                    Email = "json@gmail.com",
                    JoinedDate = new DateTime(2022,10,21)
                },
                new()
                {
                    FullName = "Jessica Wonder",
                    UrlSlug = "jessica-wonder",
                    Email = "jessoca665@motip.com",
                    JoinedDate = new DateTime(2020,4,19)

                }
            };
            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }
        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
            new() {Name = ".NET Core",  UrlSlug =  ".net-core", Description = ".NET Core",ShowOnMenu = false},
            new() {Name = "Architecture",UrlSlug = "architecture", Description = "Architecture",  ShowOnMenu = false},
            new() { Name = "Messagin", UrlSlug = "messagin", Description = "Messagin", ShowOnMenu = false},
            new() {Name = "OOP", UrlSlug = "oop", Description = "Object-Oriented Program", ShowOnMenu = false},
            new() {Name = "Design Patterns", UrlSlug = "design-patterns", Description = "Design Patterns", ShowOnMenu = false}
            };
            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();
            return categories;
        }
        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new() {Name = "Google", Description = "Google application", UrlSlug = "Google"},
                new() {Name = "ASP.NET MVC", Description = "ASP.NET MVC", UrlSlug = "ASP.NET MVC"},
                new() {Name = "Razor Page", Description = "Razor Page", UrlSlug = "Razor Page"},
                new() {Name = "Blazor", Description = "Blazor", UrlSlug = "Blazor"},
                new() {Name = "Deep Learning", Description = "Deep Learning", UrlSlug = "Deep Learning"},
                new() {Name = "Neural Network", Description = "Neural Network", UrlSlug = "Neural Network"}

            };
            _dbContext.AddRange(tags);
            _dbContext.SaveChanges();
            return tags;
        }
        private IList<Post> AddPosts
            (IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags)
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title = "APS.NET Core Diagnostic Scenarios",
                    ShortDescription = "David and friends has a great repos",
                    Description  = "Here's a few great DON'T and DO examples",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/image_1.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    Category = categories[0],
                    Author = authors[0],

                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },

                 new()
                {
                    Title = "M10 Messi",
                    ShortDescription = "David and friends has a great repos",
                    Description  = "Here's a few great DON'T and DO examples",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/image_8.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    Category = categories[0],
                    Author = authors[0],

                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },

                  new()
                {
                    Title = "Tomy Tom",
                    ShortDescription = "David and friends has a great repos",
                    Description  = "Here's a few great DON'T and DO examples",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/image_2.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2023, 9, 20, 11, 20, 0),
                    ModifiedDate = null,
                    Category = categories[0],
                    Author = authors[0],

                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },

                   new()
                {
                    Title = "CR7",
                    ShortDescription = "David and friends has a great repos",
                    Description  = "Here's a few great DON'T and DO examples",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/image_3.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    Category = categories[0],
                    Author = authors[0],

                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },
            };
            _dbContext.AddRange(posts);
            _dbContext.SaveChanges();
            return posts;
        }
    }
}
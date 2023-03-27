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
                    Title = "Tomy Tom",
                    ShortDescription = "Được dịch từ tiếng Anh-Thomas Michael Shelby OBE DSM MM MP là một nhân vật hư cấu và là nhân vật chính của bộ phim truyền hình tội phạm thời kỳ Anh Peaky",
                    Description  = "Được dịch từ tiếng Anh-Thomas Michael Shelby OBE DSM MM MP là một nhân vật hư cấu và là nhân vật chính của bộ phim truyền hình tội phạm thời kỳ Anh Peaky",
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
                    ShortDescription = "Lionel Andrés Messi, còn được gọi là Leo Messi, là một cầu thủ bóng đá chuyên nghiệp người Argentina",
                    Description  = "Lionel Andrés Messi, còn được gọi là Leo Messi, là một cầu thủ bóng đá chuyên nghiệp người Argentina",
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
                    Title = "N'Golo Kanté",
                    ShortDescription = "N'Golo Kanté là một cầu thủ bóng đá chuyên nghiệp người Pháp",
                    Description  = "N'Golo Kanté là một cầu thủ bóng đá chuyên nghiệp người Pháp",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/kante.jpg",
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
                    ShortDescription = "Cristiano Ronaldo dos Santos Aveiro là một cầu thủ bóng đá chuyên nghiệp người Bồ Đào Nha ",
                    Description  = "Cristiano Ronaldo dos Santos Aveiro là một cầu thủ bóng đá chuyên nghiệp người Bồ Đào Nha   ",
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
                     new()
                {
                    Title = "Neymar",
                    ShortDescription = "Neymar da Silva Santos Júnior, thường được biết đến với tên gọi Neymar, là một cầu thủ bóng đá người Brasil ",
                    Description  = "Neymar da Silva Santos Júnior, thường được biết đến với tên gọi Neymar, là một cầu thủ bóng đá người Brasil ",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/naymarjr.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2022, 2, 16, 12, 20, 0),
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
                    Title = "Kylian Mbappé",
                    ShortDescription = "Kylian Mbappé Lottin (sinh ngày 20 tháng 12 năm 1998) là một cầu thủ bóng đá chuyên nghiệp người Phápủ bóng đá chuyên nghiệp người Việt Nam ",
                    Description  = "Hà ĐKylian Mbappé Lottin (sinh ngày 20 tháng 12 năm 1998) là một cầu thủ bóng đá chuyên nghiệp người Phápức Chinh (sinh ngày 22 tháng 9 năm 1997) là một cầu thủ bóng đá chuyên nghiệp người Việt Nam ",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/mpape.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2022, 2, 10, 12, 20, 0),
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
                    Title = "Suarez",
                    ShortDescription = "Luis Alberto Suárez Díaz là một cầu thủ bóng đá chuyên nghiệp người Uruguay ",
                    Description  = "Luis Alberto Suárez Díaz là một cầu thủ bóng đá chuyên nghiệp người Uruguay ",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/suarez.jpg",
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
                    Title = "Công Phượng",
                    ShortDescription = "Nguyễn Công Phượng là một cầu thủ bóng đá chuyên nghiệp người Việt Nam",
                    Description  = "Nguyễn Công Phượng là một cầu thủ bóng đá chuyên nghiệp người Việt Nam",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/congphuong.jpg",
                    ViewCount = 10,
                    Published = true,
                   PostedDate = new DateTime(2023, 9, 30, 10, 20, 0),
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
                    Title = "Đặng Văn Lâm",
                    ShortDescription = "Đặng Văn Lâm là một cầu thủ bóng đá chuyên nghiệp người Việt–Nga và đội tuyển bóng đá quốc gia Việt Nam",
                    Description  = "Đặng Văn Lâm là một cầu thủ bóng đá chuyên nghiệp người Việt–Nga và đội tuyển bóng đá quốc gia Việt Nam",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/dangvanlam.jpg",
                    ViewCount = 10,
                    Published = true,
                   PostedDate = new DateTime(2022, 9, 30, 10, 20, 0),
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
                    Title = "Đoàn Văn Hậu",
                    ShortDescription = "Đoàn Văn Hậu là một cầu thủ bóng đá chuyên nghiệp người Việt Nam",
                    Description  = "Đoàn Văn Hậu là một cầu thủ bóng đá chuyên nghiệp người Việt Nam",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/doanvanhau.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2023, 9, 30, 10, 20, 0),
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
                    Title = "Hà Đức Chinh",
                    ShortDescription = "Hà Đức Chinh (sinh ngày 22 tháng 9 năm 1997) là một cầu thủ bóng đá chuyên nghiệp người Việt Nam ",
                    Description  = "Hà Đức Chinh (sinh ngày 22 tháng 9 năm 1997) là một cầu thủ bóng đá chuyên nghiệp người Việt Nam ",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/haducchinh.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2021, 11, 30, 12, 20, 0),
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
                    Title = "Nguyễn Quang Hải",
                    ShortDescription = "Nguyễn Quang Hải là một cầu thủ bóng đá chuyên nghiệp người Việt Nam ",
                    Description  = "Nguyễn Quang Hải là một cầu thủ bóng đá chuyên nghiệp người Việt Nam ",
                    Meta = "David and friends has a great repository filled",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    ImageUrl = "/images/quanghai.jpg",
                    ViewCount = 10,
                    Published = true,
                    PostedDate = new DateTime(2022, 8, 30, 8, 20, 0),
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
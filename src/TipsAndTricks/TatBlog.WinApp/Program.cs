using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TatBlog.Core.Constracts;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.Services.Extensions;

namespace TatBlog.WinApp;

public class Program
{
    static async Task Main(string[] args)
{
    // PHẦN B
    {
        //var context = new BlogDbContext();

        //var seeder = new DataSeeder(context);

        //seeder.Initialize();

        //IBlogRepository blogRepo = new BlogRepository(context);
        //var posts = await blogRepo.GetPopularArticlesAsync(3);
        //foreach (var post in posts) 
        //{
        //    Console.WriteLine("ID   : {0}", post.Id);
        //    Console.WriteLine("Title   : {0}", post.Title);
        //    Console.WriteLine("View   : {0}", post.ViewCount);
        //    Console.WriteLine("Date   : {0: MM/dd/yyyy}", post.PostedDate);
        //    Console.WriteLine("Author   : {0}", post.Author.FullName);
        //    Console.WriteLine("Category   : {0}", post.Category.Name);
        //    Console.WriteLine("".PadRight(80, '-'));
        //}

        //var categories = await blogRepo.GetCategoriesAsync();

        //Console.WriteLine("{0,-5}{1,-50}{2,10}",
        //    "ID", "Name", "Count");
        //foreach (var item in categories)
        //{
        //    Console.WriteLine("{0,-5}{1,-50}{2,10}",
        //    item.Id, item.Name, item.PostCount);
        //}

        //var pagingParams = new PagingParams
        //{
        //    PageNumber = 1,
        //    PageSize = 5,
        //    SortColumn = "Name",
        //    SortOrder = "DESC"
        //};
        //var tagList = await blogRepo.GetPagedTagAsync(pagingParams);
        //Console.WriteLine("{0,-5}{1,-50}{2,10}",
        //    "ID", "Name", "Count");

        //foreach (var item in tagList)
        //{
        //    Console.WriteLine("{0,-5}{1,-50}{2,10}",
        //        item.Id,item.Name, item.PostCount);
        //}

        //Console.WriteLine("Nhập tên định danh của thẻ cần tìm: ");
        //string temp = Console.ReadLine();
        //var context = new BlogDbContext();
        //var tag = context.Tags
        //    .Where(p => p.UrlSlug == temp)
        //    .Select(p => new
        //    {
        //        Id = p.Id,
        //        Name = p.Name,
        //        UrlSlug = p.UrlSlug,

        //    })
        //    .ToList();


        //foreach (var item in tag)
        //{
        //    Console.WriteLine("id   : {0}", item.Id);
        //    Console.WriteLine("Name   : {0}", item.Name);
        //}
        }
    }
}



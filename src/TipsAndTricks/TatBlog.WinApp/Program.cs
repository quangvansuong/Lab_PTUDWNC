using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;

namespace TatBlog.WinApp;

public class Program
{
    static async Task Main(string[] args)
    {
        var context = new BlogDbContext();

        var seeder = new DataSeeder(context);

        seeder.Initialize();

        IBlogRepository blogRepo = new BlogRepository(context);
        var posts = await blogRepo.GetPopularArticlesAsync(3);
        foreach (var post in posts) 
        {
            Console.WriteLine("ID   : {0}", post.Id);
            Console.WriteLine("Title   : {0}", post.Title);
            Console.WriteLine("View   : {0}", post.ViewCount);
            Console.WriteLine("Date   : {0: MM/dd/yyyy}", post.PostedDate);
            Console.WriteLine("Author   : {0}", post.Author.FullName);
            Console.WriteLine("Category   : {0}", post.Category.Name);
            Console.WriteLine("".PadRight(80, '-'));
        }
        var categories = await blogRepo.GetCategoriesAsync();

        Console.WriteLine("{0,-5}{1,-50}{2,10}",
            "ID", "Name", "Count");
        foreach (var item in categories)
        {
            Console.WriteLine("{0,-5}{1,-50}{2,10}",
            item.Id, item.Name, item.PostCount);
        }
        var pagingParams = new PagingParams
        {
            PageNumber = 1,
            PageSize = 5,
            SortColumn = "Name",
            SortOrder = "DESC"
        };
        var tagList = await blogRepo.GetPagedTagAsync(pagingParams);
        Console.WriteLine("{0,-5}{1,-50}{2,10}",
            "ID", "Name", "Count");
        foreach (var item in tagList)
        {
            Console.WriteLine("{0,-5}{1,-50}{2,10}",
                item.Id,item.Name, item.PostCount);
        }
        
        //var authors = context.authors.tolist();

        //console.writeline("{0,4}{1,-30}{2,-30}{3,12}", "id", "full name", "email", "joined date");
        //foreach (var author in authors) {
        //    console.writeline("{0,-4}{1,-30}{2,-30}{3,12:mm/dd/yyyy}",
        //                    author.id, author.fullname, author.email, author.joineddate);

        //}

        //VAR POSTS = CONTEXT.POSTS
        //    .WHERE(P => P.PUBLISHED)
        //    .ORDERBY(P => P.TITLE)
        //    .SELECT(P => NEW
        //    {
        //        ID = P.ID,
        //        TITLE = P.TITLE,
        //        VIEWCOUNT = P.VIEWCOUNT,
        //        POSTEDDATE = P.POSTEDDATE,
        //        AUTHOR = P.AUTHOR.FULLNAME,
        //        CATEGORY = P.CATEGORY.NAME,
        //    })
        //    .TOLIST();
        //FOREACH (VAR POST IN POSTS)
        //{
        //    CONSOLE.WRITELINE("ID   :{0}", POST.ID);
        //    CONSOLE.WRITELINE("TITLE   :{0}", POST.TITLE);
        //    CONSOLE.WRITELINE("VIEW   :{0}", POST.VIEWCOUNT);
        //    CONSOLE.WRITELINE("DATE   :{0:MM/DD/YYYY}", POST.POSTEDDATE);
        //    CONSOLE.WRITELINE("AUTHOR   :{0}", POST.AUTHOR);
        //    CONSOLE.WRITELINE("CATEGORY   :{0}", POST.CATEGORY);
        //    CONSOLE.WRITELINE("".PADRIGHT(80,'-'));

        //}
    }
}




﻿using System.Text;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.WinApp;

Console.OutputEncoding = Encoding.UTF8;
Console.ForegroundColor = ConsoleColor.Green;

//var context = new BlogDbContext();
//DataSeeder seeder = new DataSeeder(context);
//IBlogRepository blogRepo = new BloggRepository(context);

//seeder.Initialize();

//var authors = context.Authors.ToList();
//foreach (var author in authors)
//{
//	Console.WriteLine("{0,-4}{1,-50}{2,-30}{3,12:MM/dd/yyyy}",
//		author.Id, author.FullName, author.Email, author.JoinedDate);
//}

// Tìm 3 bài viết được xem nhiều nhất
//var posts = await blogRepo.GetPopularArticlesAsync(3);
//foreach (var post in posts)
//{
//	Console.WriteLine("ID		: {0}", post.Id);
//	Console.WriteLine("Title		: {0}", post.Title);
//	Console.WriteLine("View		: {0}", post.ViewCount);
//	Console.WriteLine("Date		: {0:MM/dd/yyyy}", post.PostedDate);
//	Console.WriteLine("Author		: {0}", post.Author.FullName);
//	Console.WriteLine("Category	: {0}", post.Category.Name);
//	Console.WriteLine("".PadRight(80, '-'));
//}

// Lấy danh sách chuyên mục
//var categories = await blogRepo.GetCategoriesAsync();
//foreach (var item in categories)
//{
//	Console.WriteLine("{0,-5}{1,-60}{2,10}",
//		item.Id, item.Name, item.PostCount);
//}

//var posts = context.Posts
//	.Where(p => p.Published)
//	.OrderBy(p => p.Title)
//	.Select(p => new
//	{
//		Id = p.Id,
//		Title = p.Title,
//		ViewCount = p.ViewCount,
//		PostedDate = p.PostedDate,
//		Author = p.Author.FullName,
//		Category = p.Category.Name,
//	}).ToList();

//Console.WriteLine("{0,-4}{1,-60}{2,-30}{3,12}",
//	"ID", "Full Name", "Email", "Joined Date");

//Console.WriteLine("{0,-5}{1,-60}{2,10}",
//	"ID", "Name", "Count");


//Tạo đối tượng chứa params phân trang
//var pagingParams = new PagingParams
//{
//	PageNumber = 1,
//	PageSize = 5,
//	SortColumn = "Name",
//	SortOrder = "DESC"
//};

//Lấy danh sách từ khóa
//var tagsList = await blogRepo.GetPagedTagsAsync(pagingParams);

//Console.WriteLine("{0,-5}{1,-50}{2,10}",
//			"ID", "Name", "Count");

//foreach (var item in tagsList)
//{
//	Console.WriteLine("{0,-5},{1,-50}{2,10}",
//		item.Id, item.Name, item.PostCount);
//}


// Câu 1a
//var tslug = await blogRepo.GetTagsAsync("google-application");

//Console.WriteLine("{0,-5}{1,-50}{2,10}",
//		tslug.Id, tslug.Name, tslug.UrlSlug);

// Câu 1c
//var tag = await blogRepo.GetAllTagsList();

//Console.WriteLine("{0,-30} {1,-30} {2}",
//			"Name", "UrlSlug", "Description");

//foreach (var item in tag)
//{
//	Console.WriteLine("{0,-30} {1,-30} {2}",
//		 item.Name, item.UrlSlug, item.Description);
//}

//Câu 1d
//var tag = await blogRepo.GetAllTagsList();
//Console.WriteLine("Danh sách trước khi xóa:");
//Console.WriteLine("{0,-30} {1,-30} {2}",
//			"Name", "UrlSlug", "Description");
//foreach (var item in tag)
//{
//	Console.WriteLine("{0,-30} {1,-30} {2}",
//		 item.Name, item.UrlSlug, item.Description);
//}

//var rmTag = await blogRepo.RemoveTagsByIdAsync(5);
//Console.WriteLine("Danh sách sau khi xóa:");
//Console.WriteLine("{0,-30} {1,-30} {2}", rmTag.Name, rmTag.UrlSlug, rmTag.Description);







﻿using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TatBlog.Core.Entities;
using TatBlog.Services.Blogs;
using TatBlog.Services.Media;
using TatBlog.WebApp.Areas.Admin.Models;

namespace TatBlog.WebApp.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();

        //}
        private readonly IValidator<PostEditModel> _postValidator;
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            // ID = 0 <==. Thêm bài viết mới
            // ID > 0 : đọc dữ liệu bài viết từ csdl
            var post = id > 0
                ? await  _blogRepository.GetPostByIdAsync(id, true) 
                : null;
            // Tạo view model từ dữ liệu của bài viết
            var model = post == null
                ? new PostEditModel()
                : _mapper.Map<PostEditModel>(post);
            await PopulatePostEditModelAsync(model);

            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> VerifyPostSlug(
            int id, string urlSlug)
        {
            var slugExisted = await _blogRepository
                .IsPostSlugExitsedAsync(id, urlSlug);

            return slugExisted
                ? Json($"Slug'{urlSlug}' đã được sử dụng")
                : Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            
            PostEditModel model)

        {
            var validationResult = await _postValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
            }
            if (!ModelState.IsValid)
            {
                await PopulatePostEditModelAsync(model);
                return View(model);
            }

            var post = model.Id > 0
               ? await _blogRepository.GetPostByIdAsync(model.Id)
               : null;
            if (post == null) 
            {
                post = _mapper.Map<Post>(model);

                post.Id = 0;
                post.PostedDate= DateTime.Now;
            }
            else
            {
                _mapper.Map(model, post);

                post.Category = null;
                post.ModifiedDate = DateTime.Now;
            }

            //Nếu người dùng có upload hình ảnh minh họa cho bài viết
            if (model.ImageFile?.Length > 0) 
            {
                //Thì thực hiện việc lưu tập tin vào thư mục uploads
                var newImagePath = await _mediaManager.SaveFileAsync(
                    model.ImageFile.OpenReadStream(),
                    model.ImageFile.FileName,
                    model.ImageFile.ContentType);

                // Nếu lưu thành công, xóa tập tinh hình anh cũ (nếu có)
                if (!string.IsNullOrWhiteSpace(newImagePath))
                {
                    await _mediaManager.DeleteFileAsync(post.ImageUrl);
                    post.ImageUrl = newImagePath;
                }
            }

            await _blogRepository.CreateOrUpdatePostAsync(
                post, model.GetSelectedTags());

            return RedirectToAction(nameof(Index));
        }
       

        private async Task PopulatePostEditModelAsync(PostEditModel model)
        {
            

            var authors = await _blogRepository.GetAuthorsAsync();
            var categories = await _blogRepository.GetCategoriesAsync();

            model.AuthorList = authors.Select(a => new SelectListItem()
            {
                Text = a.FullName,
                Value = a.Id.ToString()
            });
            model.CategoryList = categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IMediaManager _mediaManager;

        public PostsController(
            IBlogRepository blogRepository,
            IMediaManager mediaManager,
            IMapper mapper,
            IValidator<PostEditModel> postValidator)
        {
            _blogRepository = blogRepository;
            _mediaManager = mediaManager;
            _mapper = mapper;
            _postValidator = postValidator;
        }


        private async Task PopulatePostFilterModelAsync(PostFilterModel model)
        {
            var authors = await _blogRepository.GetAuthorsAsync();
            var categories = await _blogRepository.GetCategoriesAsync();

            model.AuthorList = authors.Select(a => new SelectListItem()
            {
                Text = a.FullName,
                Value = a.Id.ToString()
            });
            model.CategoryList = categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }
        public async Task<IActionResult> Index(PostFilterModel model)
        {
            // Sử dụng Mapster để tạo đôi tượng PostQuery
            // từ đối tượng PostFilterModel model
            var postQuery = _mapper.Map<PostQuery>(model);

            //var postQuery = new PostQuery()
            //{
            //    Keyword = model.Keyword,
            //    CategoryId = model.CategoryId,
            //    AuthorId = model.AuthorId,
            //    Year = model.Year,
            //    Month = model.Month
            //};
            ViewBag.PostsList = await _blogRepository
                .GetPagedPostsAsync(postQuery, 1, 10);

            await PopulatePostFilterModelAsync(model);
            return View(model);
        }

    }
}

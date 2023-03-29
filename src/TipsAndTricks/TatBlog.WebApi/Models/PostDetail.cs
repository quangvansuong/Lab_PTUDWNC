﻿using System.Collections.Generic;
using System;

namespace TatBlog.WebApi.Models
{
    public class PostDetail
    {
        // Mã bài viết
        public int Id { get; set; }
        //Tiêu đề bài viết
        public string Title { get; set; }
        //Mô tả hay giới thiệu ngắn về nội dung
        public string ShortDescription { get; set; }
        //Nội dung chi tiết bài viết
        public string Description { get; set; }
        //Metadata
        public string Meta { get; set; }
        //Tên định danh để tạo URL
        public string UrlSlug { get; set; }
        //Đường dẫn đế tập tin hình ảnh
        public string ImageUrl { get; set; }
        //Số lượt xem, đọc bài viết
        public int ViewCount { get; set; }
        // Ngày giờ đăng bài
        public DateTime PostedDate { get; set; }
        // Ngày giờ cập nhật lần cuối
        public DateTime? ModifiedDate { get; set; }
        // Chuyên mục của bài viết
        public CategoryDto Category { get; set; }
        // Tác giả bài viết
        public AuthorDto Author { get; set; }
        // Danh sách từ khóa của bài viết
        public IList<TagDto> Tags { get; set; }
    }
}

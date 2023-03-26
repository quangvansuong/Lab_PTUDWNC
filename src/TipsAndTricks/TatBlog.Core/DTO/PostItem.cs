using TatBlog.Core.Entities;

namespace TatBlog.WebApp.Mapsters
{
    public class PostItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public string ImageUrl { get; set; }
        public int ViewCount { get; set; }
        // Trạng thái bài viét
        public bool Published { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        // Mã chuyên mục
        public int CategoryId { get; set; }

        // Mã tác giả bài viết
        public int AuthorId { get; set; }

        // Chuyên mục bài viết
        public Category Category { get; set; }
        // Tác giả bài viết
        public Author Author { get; set; }

        // Danh sách từ khóa bài viết
        public IList<Tag> Tags { get; set; }
        public string CategoryName { get; set; }
        public string PublishedOnly { get; set; }
    }
}
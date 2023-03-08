using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TatBlog.Core.Constracts;
using TatBlog.Core.DTO;
using TatBlog.Core.Entities;

namespace TatBlog.Services.Blogs
{
    public interface IBlogRepository
    {
        Task<Post> GetPostAsync(
            int year,
            int month,
            string slug,
            CancellationToken cancellationToken = default);

        Task<IList<Post>> GetPopularArticlesAsync(
            int numPosts,
            CancellationToken cancellationToken = default);
        Task<bool>IsPostSlugExistendAsync(
            int postId, string slug,
            CancellationToken cancellationToken = default);

        Task IncreaseViewCountAsync(
            int postId,
            CancellationToken cancellationToken = default);
        Task<IList<CategoryItem>> GetCategoriesAsync(
            bool showOnMenu = false,
            CancellationToken cancellationToken = default);
        Task<IPagedList<TagItem>> GetPagedTagAsync(
            IPagingParams pagingParams,
            CancellationToken cancellationToken = default);

        /* public async*/
        Task<IPagedList<Post>> GetPagedPostsAsync(
        PostQuery condition,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);
        //{
        //    return await FilterPosts(condition).ToPagedListAsync(
        //        pageNumber, pageSize,
        //        nameof(Post.PostedDate), "DESC",
        //        cancellationToken);
        //}

        //public async Task<IPagedList<T>> GetPagedPostsAsync<T>(
        //    PostQuery condition,
        //    IPagingParams pagingParams,
        //    Func<IQueryable<Post>, IQueryable<T>> mapper)
        //{
        //    var posts = FilterPosts(condition);
        //    var projectedPosts = mapper(posts);

        //    return await projectedPosts.ToPagedListAsync(pagingParams);
        //}

    }

}

using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Shared.Services;

namespace MgChitDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;

        public DA_Blog(AppDbContext context)
        {
            _context = context;
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _context.Blog.ToList();
            var blogs = lst.Select(x=> new BlogModel
            {
                BlogAuthor = x.BlogAuthor,
                BlogContent = x.BlogContent,
                BlogTitle = x.BlogTitle,
            }).ToList();
            return blogs;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogId == id);
            var blog = new BlogModel
            {
                BlogAuthor = item.BlogAuthor,
                BlogContent = item.BlogContent,
                BlogTitle = item.BlogTitle,
            };
            return blog;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            var model = new BlogDataModel
            {
                BlogAuthor = requestModel.BlogAuthor,
                BlogTitle = requestModel.BlogTitle,
                BlogContent= requestModel.BlogContent,
            };
            _context.Blog.Add(model);
            var result = _context.SaveChanges();
            return result;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            var result = _context.SaveChanges();
            return result;
        }

        public int DeleteBlog(int id)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            _context.Blog.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }
    }
}

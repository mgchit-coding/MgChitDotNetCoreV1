using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Shared;
using MgChitDotNetCore.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MgChitDotNetCore.WebAPI.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogs = await _context.Blog.AsNoTracking().ToListAsync();
            return Ok(blogs.ToFormattedJson());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _context
                .Blog
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);
            return Ok(blog.ToFormattedJson());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogModel requestModel)
        {
            var model = new BlogDataModel
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent,
            };
            await _context.Blog.AddAsync(model);
            var result = await _context.SaveChangesAsync();
            string message = result > 0 ? "Successfully Create." : "Failed To Create";
            var response = new BlogResponseModel
            {
                Message = message
            };
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BlogModel requestModel)
        {
            var response = new BlogResponseModel();
            string message = "";
            var blog = await _context.Blog.FirstOrDefaultAsync(x => x.BlogId == id);
            if (blog == null)
            {
                message = "Data not found.";
                response.Message = message;
                goto result;
            }
            blog.BlogTitle = requestModel.BlogTitle;
            blog.BlogAuthor = requestModel.BlogAuthor;
            blog.BlogContent = requestModel.BlogContent;
            _context.Blog.Update(blog);
            var result = await _context.SaveChangesAsync();
            message = result > 0 ? "Successfully Update." : "Failed To Update";
            response.Message = message;
        result:
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new BlogResponseModel();
            string message = "";
            var blog = await _context.Blog.FirstOrDefaultAsync(x => x.BlogId == id);
            if (blog == null)
            {
                message = "Data not found.";
                response.Message = message;
                goto result;
            }
            _context.Blog.Remove(blog);
            var result = await _context.SaveChangesAsync();
            message = result > 0 ? "Successfully Delete." : "Failed To Delete";
            response.Message = message;
        result:
            return Ok(response);
        }

        [HttpGet, Route("Encrypt")]
        public async Task<IActionResult> Encrypt()
        {
            var blog = new BlogModel
            {
                BlogAuthor = "Author",
                BlogContent = "content",
                BlogTitle = "Title",
            }.ToUrlObject().ToBase3264UrlEncoder();

            return Ok(blog);
        }

        [HttpGet, Route("Decrypt")]
        public async Task<IActionResult> Decrypt(string base64Str)
        {
            var blog = base64Str.ToBase3264UrlDecoder().ToUrlObject<BlogModel>();

            return Ok(blog);
        }
    }
}

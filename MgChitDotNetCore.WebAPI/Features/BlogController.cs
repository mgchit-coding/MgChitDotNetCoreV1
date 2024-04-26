﻿using MgChitDotNetCore.Model.Models;
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
                .FirstOrDefaultAsync(x=> x.BlogId == id);
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
            return Ok(message);
        }
    }
}

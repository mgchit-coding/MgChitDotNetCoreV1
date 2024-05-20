using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Model;
using MgChitDotNetCore.Shared.Services;
using MgChitDotNetCore.Shared;
using Newtonsoft.Json;
using Refit;

namespace MgChitDotNetCore.ConsoleApp;

public class Run
{
    public void Ado()
    {
        AdoService service = new AdoService();

        #region Get Blog 

        var blogLst = service.GetLst<List<BlogDataModel>>(SqlQuery.Blog);
        Console.WriteLine(blogLst.ToJson());

        #endregion

        #region Blog By Id

        var blogById = new
        {
            BlogId = 2
        };
        var blog = service.GetItem<BlogDataModel>(SqlQuery.BlogById, blogById.ToDictionary());
        Console.WriteLine(blog.ToJson());

        #endregion

        #region Blog Create

        var blogCreate = new
        {
            BlogTitle = "Title",
            BlogAuthor = "Author",
            BlogContent = "content",
        };
        var result = service.Execute(SqlQuery.BlogCrate, blogCreate.ToDictionary());

        #endregion

        #region Blog Update

        var blogUpdate = new
        {
            BlogId = 2,
            BlogTitle = "Title",
            BlogAuthor = "Author",
            BlogContent = "content",
        };
        var update = service.Execute(SqlQuery.BlogUpdate, blogUpdate.ToDictionary());

        #endregion

        #region Blog Delete

        var blogDelete = new
        {
            BlogId = 2
        };
        var delete = service.Execute(SqlQuery.BlogDelete, blogDelete.ToDictionary());

        #endregion
    }

    public void Dapper()
    {
        DapperService service = new DapperService();

        #region Get Blog 

        var blogLst = service.Get<List<BlogDataModel>>(SqlQuery.Blog);
        Console.WriteLine(blogLst.ToJson());

        #endregion

        #region Blog By Id

        var blogById = new
        {
            BlogId = 2
        };
        var blog = service.GetItem<BlogDataModel>(SqlQuery.BlogById, blogById);
        Console.WriteLine(blog.ToJson());

        #endregion

        #region Blog Create

        var blogCreate = new
        {
            BlogTitle = "Title",
            BlogAuthor = "Author",
            BlogContent = "content",
        };
        var result = service.Execute(SqlQuery.BlogCrate, blogCreate);

        #endregion

        #region Blog Update

        var blogUpdate = new
        {
            BlogId = 2,
            BlogTitle = "Title",
            BlogAuthor = "Author",
            BlogContent = "content",
        };
        var update = service.Execute(SqlQuery.BlogUpdate, blogUpdate);

        #endregion

        #region Blog Delete

        var blogDelete = new
        {
            BlogId = 2
        };
        var delete = service.Execute(SqlQuery.BlogDelete, blogDelete);

        #endregion
    }

    public void EFCore()
    {
        AppDbContext db = new AppDbContext();

        #region Get Blog 

        var blogLst = db.Blog.ToList();
        Console.WriteLine(blogLst.ToJson());

        #endregion

        #region Blog By Id
        var model = new BlogModel();
        int blogId = 2;
        var blogById = db.Blog.FirstOrDefault(x => x.BlogId == blogId);
        model.DynamicObj = blogById;
        Console.WriteLine(JsonConvert.SerializeObject(model.DynamicObj));
        Console.WriteLine(blogById.ToJson());

        #endregion

        #region Create Blog 

        //var blogModel = new BlogDataModel
        //{
        //    BlogTitle = "Title",
        //    BlogContent = "content",
        //    BlogAuthor = "Author",
        //};
        //db.Blog.Add(blogModel);
        //db.SaveChanges();

        #endregion

        #region Update Blog

        var blog = db.Blog.FirstOrDefault(x => x.BlogId == blogId);
        blog.BlogAuthor = "Author";
        blog.BlogContent = "content";
        blog.BlogTitle = "Titel";
        db.Blog.Update(blog);

        blog.BlogTitle = "Titel1";
        db.Blog.Update(blog);
        db.SaveChanges();

        #endregion

        #region Delete Blog

        //var item = db.Blog.FirstOrDefault(x => x.BlogId == blogId);
        //db.Blog.Remove(item);
        //db.SaveChanges();

        #endregion
    }

    public async void HttpClient()
    {
        HttpClientService _httpClient = new HttpClientService();

        #region Get Blog

        var blogs = await _httpClient.Execute<List<BlogDataModel>>("api/blog", EnumHttpMethod.GET);
        Console.WriteLine(blogs.ToJson(true));

        #endregion

        #region Get Blog By Id 

        var blog = await _httpClient.Execute<BlogDataModel>($"api/blog/{2}", EnumHttpMethod.GET);
        Console.WriteLine(blog.ToJson(true));

        #endregion

        #region Create Blog 

        var model = new BlogDataModel
        {
            BlogTitle = "BlogTitle",
            BlogAuthor = "BlogAuthor",
            BlogContent = "BlogContent",
        };
        var result = await _httpClient.Execute<BlogResponseModel>($"api/blog", EnumHttpMethod.POST, model);
        Console.WriteLine(result.Message);
        #endregion

        #region update Blog 

        var updateModel = new BlogDataModel
        {
            BlogTitle = "BlogTitle",
            BlogAuthor = "BlogAuthor",
            BlogContent = "BlogContent",
        };
        var updateResult = await _httpClient.Execute<BlogResponseModel>($"api/blog/{2}", EnumHttpMethod.PUT, updateModel);
        Console.WriteLine(updateResult.Message);
        #endregion

        #region delete Blog 

        var deleteResult = await _httpClient.Execute<BlogResponseModel>($"api/blog/{3}", EnumHttpMethod.DELETE);
        Console.WriteLine(deleteResult.Message);

        #endregion
    }

    public async void RestClient()
    {
        RestClientService _restClient = new RestClientService();

        #region Get Blog

        var blogs = await _restClient.Execute<List<BlogDataModel>>("api/blog", EnumHttpMethod.GET);
        Console.WriteLine(blogs.ToJson(true));

        #endregion

        #region Get Blog By Id 

        var blog = await _restClient.Execute<BlogDataModel>($"api/blog/{2}", EnumHttpMethod.GET);
        Console.WriteLine(blog.ToJson(true));

        #endregion

        #region Create Blog 

        var model = new BlogDataModel
        {
            BlogTitle = "BlogTitle",
            BlogAuthor = "BlogAuthor",
            BlogContent = "BlogContent",
        };
        var result = await _restClient.Execute<BlogResponseModel>($"api/blog", EnumHttpMethod.POST, model);
        Console.WriteLine(result.Message);
        #endregion

        #region Update Blog 

        var updateModel = new BlogDataModel
        {
            BlogTitle = "BlogTitle",
            BlogAuthor = "BlogAuthor",
            BlogContent = "BlogContent",
        };
        var updateResult = await _restClient.Execute<BlogResponseModel>($"api/blog/{2}", EnumHttpMethod.PUT, updateModel);
        Console.WriteLine(updateResult.Message);
        #endregion

        #region Delete Blog 

        var deleteResult = await _restClient.Execute<BlogResponseModel>($"api/blog/{3}", EnumHttpMethod.DELETE);
        Console.WriteLine(deleteResult.Message);

        #endregion
    }

    public async void Refit()
    {
        IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7256");
        #region Get Blog

        var blogs = await _service.GetBlogs();
        Console.WriteLine(blogs.ToJson(true));

        #endregion

        #region Get Blog By Id 

        var blog = await _service.GetBlog(2);
        Console.WriteLine(blog.ToJson(true));

        #endregion

        #region Create Blog 

        var model = new BlogModel
        {
            BlogTitle = "BlogTitle",
            BlogAuthor = "BlogAuthor",
            BlogContent = "BlogContent",
        };
        var response = await _service.CreateBlog(model);
        Console.WriteLine(response.Message);
        #endregion

        #region Update Blog 

        var updateModel = new BlogModel
        {
            BlogTitle = "BlogTitle",
            BlogAuthor = "BlogAuthor",
            BlogContent = "BlogContent",
        };
        var updateResult = await _service.UpdateBlog(2,updateModel);
        Console.WriteLine(updateResult.Message);
        #endregion

        #region Delete Blog 

        var deleteResult = await _service.DeleteBlog(3);
        Console.WriteLine(deleteResult.Message);

        #endregion
    }
}

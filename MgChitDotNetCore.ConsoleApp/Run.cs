using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Model;
using MgChitDotNetCore.Shared.Services;
using MgChitDotNetCore.Shared;
using Newtonsoft.Json;

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
        var blogById = db.Blog.FirstOrDefault(x=> x.BlogId == blogId);
        model.DynamicObj = blogById;
        Console.WriteLine(model.DynamicObj.ToJson());
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

    public void HttpClient()
    {
        HttpClientService _httpClient = new HttpClientService();
    }
}

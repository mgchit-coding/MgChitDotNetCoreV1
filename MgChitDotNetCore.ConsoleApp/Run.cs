using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Model;
using MgChitDotNetCore.Shared.Services;
using MgChitDotNetCore.Shared;

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
}

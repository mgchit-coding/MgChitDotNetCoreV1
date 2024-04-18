// See https://aka.ms/new-console-template for more information

using MgChitDotNetCore.Model;
using MgChitDotNetCore.Model.Models;
using MgChitDotNetCore.Shared;
using MgChitDotNetCore.Shared.Services;

Console.WriteLine("Hello, World!");

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

Console.ReadKey();
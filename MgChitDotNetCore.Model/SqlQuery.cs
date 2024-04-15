namespace MgChitDotNetCore.Model;

public class SqlQuery
{
    public static string Blog { get; } = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog]";
    public static string BlogById { get; } = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog]  WHERE [BlogId] = @BlogId";
    public static string BlogCrate { get; } = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
    public static string BlogUpdate { get; } = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE [BlogId] = @BlogId";
    public static string BlogDelete { get; } = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE [BlogId] = @BlogId";
}

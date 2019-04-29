namespace vidl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2f704d18-66d6-4c81-9492-e09e679d6ea2', N'admin@vidly.com', 0, N'ANnCIY2a1/9gw8yuSSoGYl7bJhbYXdxdz4bTTXtEb4+csWdFPmU4M5HSIKf644TCNg==', N'40570972-e923-49f2-8e21-319cc28a9e6e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e00590fb-ecbf-47dc-b325-4512458bdcac', N'guest@vidly.com', 0, N'AP2tx96TiLqfyR1d2Bu9N7vGxXmMr3k8I9yPQ7JpkfD1uRzQkmlM9kgH2LuOlohDjQ==', N'04a656c4-ec5a-49b2-8c14-a83ad813d399', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a9b6b2fa-c738-467e-8995-af74b428d13e', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2f704d18-66d6-4c81-9492-e09e679d6ea2', N'a9b6b2fa-c738-467e-8995-af74b428d13e')

");
        }
        
        public override void Down()
        {
        }
    }
}

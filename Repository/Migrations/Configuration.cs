namespace Repository.Migrations
{
    using Model.Contants;
    using Model.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.BaseDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository.BaseDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //#region Seed User Type
            //context.UserTypes.AddOrUpdate(p => p.Id,
            //    new UserType { Id = Guid.NewGuid().ToString(), Name = UserTypeNameConst.Guest },
            //    new UserType { Id = Guid.NewGuid().ToString(), Name = UserTypeNameConst.Admin },
            //    new UserType { Id = Guid.NewGuid().ToString(), Name = UserTypeNameConst.User },
            //    new UserType { Id = Guid.NewGuid().ToString(), Name = UserTypeNameConst.Support }
            //    );
            //#endregion

            //#region Seed User
            //context.Users.AddOrUpdate(p => p.Id,
            //    new User { Id = Guid.NewGuid().ToString(), UserName = "thanhcv", Password = "1", FullName = "Cấn Văn Thành", Email = "cvthanh028428@gmail.com", UserTypeId = "77bb881e-e6c3-4687-a71c-0802c6f898c6" }
            //    );
            //#endregion
        }
    }
}

using Model.Entity;
using Oracle.ManagedDataAccess.Client;
using System.Data.Entity;

namespace Repository
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext() : base("PizzaDbContext")
        {
            //Database.SetInitializer<BaseDbContext>(new DropCreateDatabaseIfModelChanges<BaseDbContext>());
            //Database.SetInitializer<BaseDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(CalcDefaultSchemaName(this));

            #region Multi Column Key
            modelBuilder.Entity<RolePermission>().HasKey(s => new { s.RoleId, s.PermissionId });
            modelBuilder.Entity<RoleUserGroup>().HasKey(s => new { s.RoleId, s.UserGroupId });
            modelBuilder.Entity<RoleUserType>().HasKey(s => new { s.RoleId, s.UserTypeId });
            modelBuilder.Entity<UserGroupUser>().HasKey(s => new { s.UserId, s.UserGroupId });
            #endregion
        }

        public string CalcDefaultSchemaName(DbContext db)
        {
            var oracleConnectionStringBuilder =
                new OracleConnectionStringBuilder(db.Database.Connection.ConnectionString);
            var defaultSchema = oracleConnectionStringBuilder["USER ID"].ToString();
            return defaultSchema;
        }

        #region Base Table 
        public DbSet<Log> Logs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<RoleUserGroup> RoleUserGroups { get; set; }
        public DbSet<RoleUserType> RoleUserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupUser> UserGroupUsers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<LoginFail> LoginFails { get; set; }
        #endregion
    }
}

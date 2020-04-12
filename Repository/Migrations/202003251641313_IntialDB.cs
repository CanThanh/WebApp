namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PIZZA.LOG",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        TABLE_NAME = c.String(nullable: false, maxLength: 50),
                        OBJECT_ID = c.String(nullable: false, maxLength: 50),
                        VALUE = c.Binary(nullable: false),
                        CREATE_DATE = c.Decimal(nullable: false, precision: 19, scale: 0),
                        CREATE_BY = c.String(maxLength: 50),
                        IP_ADDRESS = c.String(maxLength: 50),
                        BROWSER = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "PIZZA.MENU",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        NAME = c.String(nullable: false, maxLength: 50),
                        LINK = c.String(nullable: false, maxLength: 200),
                        PARENT_ID = c.String(maxLength: 50),
                        MENU_TYPE = c.String(maxLength: 50),
                        MENU_ICON = c.String(maxLength: 50),
                        ORDER = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PERMISSION_ID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("PIZZA.MENU", t => t.PARENT_ID)
                .ForeignKey("PIZZA.PERMISSION", t => t.PERMISSION_ID)
                .Index(t => t.PARENT_ID)
                .Index(t => t.PERMISSION_ID);
            
            CreateTable(
                "PIZZA.PERMISSION",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        CODE = c.String(nullable: false, maxLength: 50),
                        NAME = c.String(nullable: false, maxLength: 50),
                        CREATE_DATE = c.Decimal(nullable: false, precision: 19, scale: 0),
                        CREATE_BY = c.String(maxLength: 50),
                        MODIFY_DATE = c.Decimal(precision: 19, scale: 0),
                        MODIFY_BY = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "PIZZA.ROLE_PERMISSION",
                c => new
                    {
                        ROLE_ID = c.String(nullable: false, maxLength: 50),
                        PERMISSION_ID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ROLE_ID, t.PERMISSION_ID })
                .ForeignKey("PIZZA.PERMISSION", t => t.PERMISSION_ID, cascadeDelete: true)
                .ForeignKey("PIZZA.ROLE", t => t.ROLE_ID, cascadeDelete: true)
                .Index(t => t.PERMISSION_ID)
                .Index(t => t.ROLE_ID);
            
            CreateTable(
                "PIZZA.ROLE",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        CODE = c.String(nullable: false, maxLength: 50),
                        NAME = c.String(nullable: false, maxLength: 50),
                        CREATE_DATE = c.Decimal(nullable: false, precision: 19, scale: 0),
                        CREATE_BY = c.String(maxLength: 50),
                        MODIFY_DATE = c.Decimal(precision: 19, scale: 0),
                        MODIFY_BY = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "PIZZA.ROLE_USERGROUP",
                c => new
                    {
                        ROLE_ID = c.String(nullable: false, maxLength: 50),
                        USERGROUP_ID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ROLE_ID, t.USERGROUP_ID })
                .ForeignKey("PIZZA.ROLE", t => t.ROLE_ID, cascadeDelete: true)
                .ForeignKey("PIZZA.USER_GROUP", t => t.USERGROUP_ID, cascadeDelete: true)
                .Index(t => t.ROLE_ID)
                .Index(t => t.USERGROUP_ID);
            
            CreateTable(
                "PIZZA.USER_GROUP",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        NAME = c.String(nullable: false, maxLength: 50),
                        CREATE_DATE = c.Decimal(nullable: false, precision: 19, scale: 0),
                        CREATE_BY = c.String(maxLength: 50),
                        MODIFY_DATE = c.Decimal(precision: 19, scale: 0),
                        MODIFY_BY = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "PIZZA.ROLE_USERTYPE",
                c => new
                    {
                        ROLE_ID = c.String(nullable: false, maxLength: 50),
                        USERTYPE_ID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ROLE_ID, t.USERTYPE_ID })
                .ForeignKey("PIZZA.ROLE", t => t.ROLE_ID, cascadeDelete: true)
                .ForeignKey("PIZZA.USER_TYPE", t => t.USERTYPE_ID, cascadeDelete: true)
                .Index(t => t.ROLE_ID)
                .Index(t => t.USERTYPE_ID);
            
            CreateTable(
                "PIZZA.USER_TYPE",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        NAME = c.String(nullable: false, maxLength: 50),
                        CREATE_DATE = c.Decimal(nullable: false, precision: 19, scale: 0),
                        CREATE_BY = c.String(maxLength: 50),
                        MODIFY_DATE = c.Decimal(precision: 19, scale: 0),
                        MODIFY_BY = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "PIZZA.SESSION",
                c => new
                    {
                        USER_ID = c.String(nullable: false, maxLength: 50),
                        SESSION_ID = c.String(nullable: false, maxLength: 50),
                        LOG_TIME = c.Decimal(nullable: false, precision: 19, scale: 0),
                        IP_ADDRESS = c.String(maxLength: 50),
                        BROWSER = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.USER_ID, t.SESSION_ID })
                .ForeignKey("PIZZA.USER", t => t.USER_ID, cascadeDelete: true)
                .Index(t => t.USER_ID);
            
            CreateTable(
                "PIZZA.USER",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        USER_NAME = c.String(nullable: false, maxLength: 50),
                        PASSWORD = c.String(nullable: false, maxLength: 50),
                        FULL_NAME = c.String(nullable: false, maxLength: 50),
                        EMAIL = c.String(nullable: false, maxLength: 50),
                        MOBILE_PHONE = c.String(maxLength: 50),
                        STATUS = c.Decimal(nullable: false, precision: 10, scale: 0),
                        RESET_PASSWORD_CODE = c.String(maxLength: 50),
                        TIME_RESET_PASSWORD_EXPIRE = c.Decimal(precision: 19, scale: 0),
                        USER_TYPE_ID = c.String(nullable: false, maxLength: 50),
                        CREATE_DATE = c.Decimal(nullable: false, precision: 19, scale: 0),
                        CREATE_BY = c.String(maxLength: 50),
                        MODIFY_DATE = c.Decimal(precision: 19, scale: 0),
                        MODIFY_BY = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("PIZZA.USER_TYPE", t => t.USER_TYPE_ID, cascadeDelete: true)
                .Index(t => t.USER_TYPE_ID);
            
            CreateTable(
                "PIZZA.USER_USERGROUP",
                c => new
                    {
                        USER_ID = c.String(nullable: false, maxLength: 50),
                        USER_GROUP_ID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.USER_ID, t.USER_GROUP_ID })
                .ForeignKey("PIZZA.USER", t => t.USER_ID, cascadeDelete: true)
                .ForeignKey("PIZZA.USER_GROUP", t => t.USER_GROUP_ID, cascadeDelete: true)
                .Index(t => t.USER_ID)
                .Index(t => t.USER_GROUP_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("PIZZA.USER_USERGROUP", "USER_GROUP_ID", "PIZZA.USER_GROUP");
            DropForeignKey("PIZZA.USER_USERGROUP", "USER_ID", "PIZZA.USER");
            DropForeignKey("PIZZA.SESSION", "USER_ID", "PIZZA.USER");
            DropForeignKey("PIZZA.USER", "USER_TYPE_ID", "PIZZA.USER_TYPE");
            DropForeignKey("PIZZA.ROLE_USERTYPE", "USERTYPE_ID", "PIZZA.USER_TYPE");
            DropForeignKey("PIZZA.ROLE_USERTYPE", "ROLE_ID", "PIZZA.ROLE");
            DropForeignKey("PIZZA.ROLE_USERGROUP", "USERGROUP_ID", "PIZZA.USER_GROUP");
            DropForeignKey("PIZZA.ROLE_USERGROUP", "ROLE_ID", "PIZZA.ROLE");
            DropForeignKey("PIZZA.ROLE_PERMISSION", "ROLE_ID", "PIZZA.ROLE");
            DropForeignKey("PIZZA.ROLE_PERMISSION", "PERMISSION_ID", "PIZZA.PERMISSION");
            DropForeignKey("PIZZA.MENU", "PERMISSION_ID", "PIZZA.PERMISSION");
            DropForeignKey("PIZZA.MENU", "PARENT_ID", "PIZZA.MENU");
            DropIndex("PIZZA.USER_USERGROUP", new[] { "USER_GROUP_ID" });
            DropIndex("PIZZA.USER_USERGROUP", new[] { "USER_ID" });
            DropIndex("PIZZA.SESSION", new[] { "USER_ID" });
            DropIndex("PIZZA.USER", new[] { "USER_TYPE_ID" });
            DropIndex("PIZZA.ROLE_USERTYPE", new[] { "USERTYPE_ID" });
            DropIndex("PIZZA.ROLE_USERTYPE", new[] { "ROLE_ID" });
            DropIndex("PIZZA.ROLE_USERGROUP", new[] { "USERGROUP_ID" });
            DropIndex("PIZZA.ROLE_USERGROUP", new[] { "ROLE_ID" });
            DropIndex("PIZZA.ROLE_PERMISSION", new[] { "ROLE_ID" });
            DropIndex("PIZZA.ROLE_PERMISSION", new[] { "PERMISSION_ID" });
            DropIndex("PIZZA.MENU", new[] { "PERMISSION_ID" });
            DropIndex("PIZZA.MENU", new[] { "PARENT_ID" });
            DropTable("PIZZA.USER_USERGROUP");
            DropTable("PIZZA.USER");
            DropTable("PIZZA.SESSION");
            DropTable("PIZZA.USER_TYPE");
            DropTable("PIZZA.ROLE_USERTYPE");
            DropTable("PIZZA.USER_GROUP");
            DropTable("PIZZA.ROLE_USERGROUP");
            DropTable("PIZZA.ROLE");
            DropTable("PIZZA.ROLE_PERMISSION");
            DropTable("PIZZA.PERMISSION");
            DropTable("PIZZA.MENU");
            DropTable("PIZZA.LOG");
        }
    }
}

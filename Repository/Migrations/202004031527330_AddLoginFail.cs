namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginFail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("PIZZA.SESSION", "USER_ID", "PIZZA.USER");
            DropIndex("PIZZA.SESSION", new[] { "USER_ID" });
            CreateTable(
                "PIZZA.LOGIN_FAIL",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        LOG_TIME = c.Decimal(nullable: false, precision: 19, scale: 0),
                        IP_ADDRESS = c.String(maxLength: 50),
                        BROWSER = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("PIZZA.SESSION");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => new { t.USER_ID, t.SESSION_ID });
            
            DropTable("PIZZA.LOGIN_FAIL");
            CreateIndex("PIZZA.SESSION", "USER_ID");
            AddForeignKey("PIZZA.SESSION", "USER_ID", "PIZZA.USER", "ID", cascadeDelete: true);
        }
    }
}

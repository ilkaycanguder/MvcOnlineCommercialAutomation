﻿namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faturalar_siraNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faturalars", "FaturaSeriNo", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Faturalars", "FaturaSeriNo");
        }
    }
}

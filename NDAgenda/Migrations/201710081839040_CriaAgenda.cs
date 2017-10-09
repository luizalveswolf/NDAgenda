namespace NDAgenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaAgenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoContato = c.Int(nullable: false),
                        Telefone = c.String(),
                        Email = c.String(),
                        Site = c.String(),
                        TipoTelefone = c.Int(nullable: false),
                        Endereco_ID = c.Int(),
                        Pessoa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_ID)
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_ID)
                .Index(t => t.Endereco_ID)
                .Index(t => t.Pessoa_ID);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rua = c.String(),
                        Bairro = c.String(),
                        Numero = c.String(),
                        TipoEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contatos", "Pessoa_ID", "dbo.Pessoas");
            DropForeignKey("dbo.Contatos", "Endereco_ID", "dbo.Enderecoes");
            DropIndex("dbo.Contatos", new[] { "Pessoa_ID" });
            DropIndex("dbo.Contatos", new[] { "Endereco_ID" });
            DropTable("dbo.Pessoas");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Contatos");
        }
    }
}

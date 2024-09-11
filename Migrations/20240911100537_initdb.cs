﻿using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.models;

#nullable disable

namespace razorweb.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });
                //Insert Data
                // Fake Data: bogus (tạo dữ liệu database giả định)

            Randomizer.Seed = new Random(8675309);
            
            var fakeArticle = new Faker<Article>();
            fakeArticle.RuleFor(a=>a.Title,fakeArticle=>fakeArticle.Lorem.Sentence(5,5));
            fakeArticle.RuleFor(a=>a.Created,fakeArticle=>fakeArticle.Date.Between(new DateTime(2021,1,1),new DateTime(2021,7,30)));
            fakeArticle.RuleFor(a=>a.Content,fakeArticle=>fakeArticle.Lorem.Paragraphs(1,4));
            
            for(int i=0;i<100;i++){
                Article article = fakeArticle.Generate();
                migrationBuilder.InsertData(
                table: "articles",
                columns: new[] {"Title","Created","Content"},
                values: new object[]{
                    article.Title,
                    article.Created,
                    article.Content
                }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Storyboard.WebApplication.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StoryboardDBEntities : DbContext
    {
        public StoryboardDBEntities()
            : base("name=StoryboardDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Storyboard.WebApplication.Models.ArticleViewModel> ArticleViewModels { get; set; }

        public System.Data.Entity.DbSet<Storyboard.WebApplication.DTOs.ArticleDTO> ArticleDTOes { get; set; }

        public System.Data.Entity.DbSet<Storyboard.WebApplication.Models.LoginViewModel> LoginViewModels { get; set; }
    }
}

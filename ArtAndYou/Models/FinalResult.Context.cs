﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtAndYou.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ArtInfoEntities3 : DbContext
    {
        public ArtInfoEntities3()
            : base("name=ArtInfoEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FINALRESULT> FINALRESULTS { get; set; }

        public System.Data.Entity.DbSet<ArtAndYou.Models.UserInfo> UserInfoes { get; set; }
    }
}

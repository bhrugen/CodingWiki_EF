using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{ 
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
           

            modelBuilder.HasKey(u => new { u.Author_Id, u.Book_Id });
            modelBuilder.HasOne(u => u.Book).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.Book_Id);
            modelBuilder.HasOne(u => u.Author).WithMany(u => u.BookAuthorMap)
                .HasForeignKey(u => u.Author_Id);

        }
    }
}

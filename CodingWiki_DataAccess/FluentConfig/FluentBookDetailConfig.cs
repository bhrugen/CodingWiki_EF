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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {

            //name of table
            modelBuilder.ToTable("Fluent_BookDetails");

            //name of columns
            modelBuilder.Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");


            //primary key
            modelBuilder.HasKey(u => u.BookDetail_Id);


            //other validations
            modelBuilder.Property(u => u.NumberOfChapters).IsRequired();
            

            //relations
            modelBuilder.HasOne(b => b.Book).WithOne(b => b.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(u => u.Book_Id);
        }
    }
}

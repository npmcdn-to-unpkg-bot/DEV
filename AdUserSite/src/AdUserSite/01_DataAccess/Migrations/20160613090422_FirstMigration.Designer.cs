using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AdUserSite._01_DataAccess;

namespace AdUserSite._01_DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160613090422_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdUserSite._00_CommonUtility.Models.User", b =>
                {
                    b.Property<string>("AccountName");

                    b.Property<bool>("DoubleUserIsOk");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("LastNamePrefix");

                    b.HasKey("AccountName");

                    b.ToTable("Users");
                });
        }
    }
}

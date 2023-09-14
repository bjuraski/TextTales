﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TextTales.Api.Data;

#nullable disable

namespace TextTales.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230911055053_AddCategoryProductRelation")]
    partial class AddCategoryProductRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TextTales.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DisplayOrder = 1,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 2L,
                            DisplayOrder = 2,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 3L,
                            DisplayOrder = 3,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("TextTales.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternationalStandardBookNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Author = "Billy Spark",
                            CategoryId = 1L,
                            Description = "In the heart-pounding world of \"Fortune of Time,\" a relentless thriller unfolds as a brilliant detective races against the clock to unravel a web of secrets and deception. Gripping suspense and unexpected twists will keep you on the edge of your seat until the very last page.",
                            InternationalStandardBookNumber = "SWD9999001",
                            Price = 90m,
                            Title = "Fortune of Time"
                        },
                        new
                        {
                            Id = 2L,
                            Author = "Nancy Hoover",
                            CategoryId = 3L,
                            Description = "\"Dark Skies\" invites you into a realm of unrelenting terror, where ominous shadows and chilling horrors lurk in every corner. Prepare to be spellbound by the spine-tingling suspense and unearth the bone-chilling secrets hidden within the darkest of nights.",
                            InternationalStandardBookNumber = "CAW777777701",
                            Price = 30m,
                            Title = "Dark Skies"
                        },
                        new
                        {
                            Id = 3L,
                            Author = "Julian Button",
                            CategoryId = 1L,
                            Description = "\"Vanish in the Sunset\" is a heart-pounding thriller that will take you on a rollercoaster ride of suspense and intrigue. When the sun sets, mysteries come to light, and you'll be captivated by the relentless pursuit of truth in this gripping tale.",
                            InternationalStandardBookNumber = "RITO5555501",
                            Price = 50m,
                            Title = "Vanish in the Sunset"
                        },
                        new
                        {
                            Id = 4L,
                            Author = "Abby Muscles",
                            CategoryId = 2L,
                            Description = "\"Cotton Candy\" is a sweet and enchanting romance that will warm your heart. Follow the journey of two souls as they navigate the twists and turns of love, sprinkled with the delightful moments that make life as sweet as cotton candy.",
                            InternationalStandardBookNumber = "WS3333333301",
                            Price = 65m,
                            Title = "Cotton Candy"
                        },
                        new
                        {
                            Id = 5L,
                            Author = "Ron Parker",
                            CategoryId = 3L,
                            Description = "Prepare to be submerged in a world of dread and terror with \"Rock in the Ocean.\" This bone-chilling horror story will take you on a treacherous voyage to uncover the horrifying secrets lurking beneath the waves. Beware of what lies beneath.",
                            InternationalStandardBookNumber = "SOTJ1111111101",
                            Price = 27m,
                            Title = "Rock in the Ocean"
                        },
                        new
                        {
                            Id = 6L,
                            Author = "Laura Phantom",
                            CategoryId = 2L,
                            Description = "\"Leaves and Wonders\" is a romance that blooms amidst the beauty of nature. Discover a love story that transcends time, as two hearts find solace in the wonders of the world around them. Let this enchanting tale sweep you off your feet.",
                            InternationalStandardBookNumber = "FOT000000001",
                            Price = 23m,
                            Title = "Leaves and Wonders"
                        });
                });

            modelBuilder.Entity("TextTales.Models.Product", b =>
                {
                    b.HasOne("TextTales.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
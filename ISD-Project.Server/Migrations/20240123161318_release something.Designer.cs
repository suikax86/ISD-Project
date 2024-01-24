﻿// <auto-generated />
using System;
using ISD_Project.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ISD_Project.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240123161318_release something")]
    partial class releasesomething
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ISD_Project.Server.InsuranceContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("InsuranceId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileStatus")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InsuranceId");

                    b.ToTable("InsuranceContracts");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.ApprovalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApprovalComment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("ApprovalDate")
                        .HasColumnType("date");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("InsuranceId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileStatus")
                        .HasColumnType("integer");

                    b.Property<int>("ValidationDepartmentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("ValidationDepartmentId");

                    b.ToTable("ApprovalStatuses");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.DTOs.InsuranceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InsuranceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Giải pháp bảo vệ tài chính tối ưu cho bạn và gia đình trước rủi ro về tai nạn, tử vong và thương tật do tai nạn",
                            Name = "Bảo hiểm tai nạn"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Giải pháp gia tăng bảo vệ tài chính và hỗ trợ đóng phí cho bạn và gia đình trước những rủi ro tử vong và thương tật",
                            Name = "Bảo hiểm tử vong và thương tật"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Giải pháp hỗ trợ đóng phí và bảo vệ tài chính cho bạn và gia đình trước những rủi ro mắc bệnh hiểm nghèo",
                            Name = "Bảo hiểm hiểm nghèo"
                        });
                });

            modelBuilder.Entity("ISD_Project.Server.Models.HealthInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AlcoholConsumption")
                        .HasColumnType("boolean");

                    b.Property<int>("CigarettesPerDay")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("DangerousSportsDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DaysPerWeekAlcohol")
                        .HasColumnType("integer");

                    b.Property<bool>("DiagnosedWithHealthConditions")
                        .HasColumnType("boolean");

                    b.Property<bool>("DrugUse")
                        .HasColumnType("boolean");

                    b.Property<bool>("EngagesInDangerousSports")
                        .HasColumnType("boolean");

                    b.Property<string>("ExperiencedDiseasesDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("ExperiencedDiseasesInLast5Years")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasSpecificHealthConditions")
                        .HasColumnType("boolean");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Smoking")
                        .HasColumnType("boolean");

                    b.Property<bool>("UnexplainedWeightLoss")
                        .HasColumnType("boolean");

                    b.Property<string>("UnexplainedWeightLossDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("HealthInformation");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.Insurance", b =>
                {
                    b.Property<int>("InsuranceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InsuranceId"));

                    b.Property<int>("CoveragePeriodInYears")
                        .HasColumnType("integer");

                    b.Property<string>("DetailDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("InsuranceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("InsuranceTypeId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PriceAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("SummaryDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("InsuranceId");

                    b.HasIndex("InsuranceTypeId");

                    b.ToTable("Insurances");

                    b.HasData(
                        new
                        {
                            InsuranceId = 1,
                            CoveragePeriodInYears = 5,
                            DetailDescription = "Lựa chọn bảo hiểm tai nạn dành cho trẻ em nhằm mang lại sự đảm bảo vững chắc cho quá trình phát triển của trẻ cũng như giảm gánh nặng chi phí trước rủi ro bất ngờ xảy đến.",
                            ImageUrl = "",
                            InsuranceName = "Bảo hiểm Tai nạn dành cho trẻ em",
                            InsuranceTypeId = 1,
                            PriceAmount = 1000000m,
                            SummaryDescription = "Giải pháp bảo vệ trước rủi ro tai nạn dành cho trẻ em."
                        },
                        new
                        {
                            InsuranceId = 2,
                            CoveragePeriodInYears = 7,
                            DetailDescription = "Bảo hiểm chết do tai nạn của Prudential sẽ là giải pháp san sẻ gánh nặng tài chính kịp thời. Nhờ đó, góp phần tạo điều kiện giúp gia đình người tham gia bảo hiểm nhanh chóng vượt qua những khó khăn để sớm ổn định cuộc sống sau này. Không chỉ vậy, số tiền bảo hiểm được chi trả nhanh chóng, theo quy trình rõ ràng. Hiện tại, sản phẩm được thiết kế có thể đính kèm cùng nhiều gói bảo hiểm chính của Prudential, khách hàng có thể dễ dàng lựa chọn tích hợp để bảo vệ tài chính toàn diện và tối ưu hơn.",
                            ImageUrl = "",
                            InsuranceName = "Bảo hiểm Chết do tai nạn",
                            InsuranceTypeId = 1,
                            PriceAmount = 1000000m,
                            SummaryDescription = "Giải pháp tối ưu cung cấp quyền lợi bảo vệ tài chính trước rủi ro tử vong do tai nạn."
                        },
                        new
                        {
                            InsuranceId = 3,
                            CoveragePeriodInYears = 4,
                            DetailDescription = "Điểm nổi bật của sản phẩm Bảo hiểm Miễn đóng phí chết và thương tật toàn bộ vĩnh viễn thể hiện ở khả năng hỗ trợ tài chính, gia tăng quyền lợi bảo vệ tối đa cho người được bảo hiểm. Chỉ với một khoản phí hợp lý cho sản phẩm này, người tham gia được miễn đóng phí, không phải lo lắng về rủi ro phải dừng đóng phí bảo hiểm của hợp đồng bảo hiểm. Trong trường hợp bên mua bảo hiểm chẳng may tử vong hoặc thương tật toàn bộ vĩnh viễn, hợp đồng bảo hiểm vẫn có thể được duy trì, quyền lợi của sản phẩm bảo hiểm vẫn được đảm bảo.",
                            ImageUrl = "",
                            InsuranceName = "Bảo hiểm Miễn đóng phí chết và thương tật toàn bộ vĩnh viễn",
                            InsuranceTypeId = 2,
                            PriceAmount = 2000000m,
                            SummaryDescription = "Giải pháp miễn đóng phí nếu không may gặp rủi ro tử vong hoặc thương tật toàn bộ vĩnh viễn"
                        },
                        new
                        {
                            InsuranceId = 4,
                            CoveragePeriodInYears = 3,
                            DetailDescription = "KHÔNG PHỤ THUỘC DANH SÁCH BỆNH TRUYỀN THỐNG, bảo hiểm theo tình trạng tổn thương của hệ cơ quan và chức năng",
                            ImageUrl = "",
                            InsuranceName = "Sản phẩm bảo hiểm tử kỳ với quyền lợi bảo hiểm tình trạng tổn thương theo mức độ",
                            InsuranceTypeId = 3,
                            PriceAmount = 1500000m,
                            SummaryDescription = "Bảo vệ “các hệ điều hành cơ thể” theo tình trạng tổn thương"
                        });
                });

            modelBuilder.Entity("ISD_Project.Server.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Customer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "FinancialDepartment"
                        },
                        new
                        {
                            Id = 4,
                            Name = "ValidationDepartment"
                        },
                        new
                        {
                            Id = 5,
                            Name = "CustomerCareDepartment"
                        });
                });

            modelBuilder.Entity("ISD_Project.Server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DateIssued")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("IdentityDocumentId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<int?>("UserAccountId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("ValidUntil")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ISD_Project.Server.Models.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IsActivated")
                        .HasColumnType("integer");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime?>("RestTokenExpires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("VerificationToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.Admin", b =>
                {
                    b.HasBaseType("ISD_Project.Server.Models.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.Customer", b =>
                {
                    b.HasBaseType("ISD_Project.Server.Models.User");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.CustomerCareDepartment", b =>
                {
                    b.HasBaseType("ISD_Project.Server.Models.User");

                    b.HasDiscriminator().HasValue("CustomerCareDepartment");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.FinancialDepartment", b =>
                {
                    b.HasBaseType("ISD_Project.Server.Models.User");

                    b.HasDiscriminator().HasValue("FinancialDepartment");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.ValidationDepartment", b =>
                {
                    b.HasBaseType("ISD_Project.Server.Models.User");

                    b.HasDiscriminator().HasValue("ValidationDepartment");
                });

            modelBuilder.Entity("ISD_Project.Server.InsuranceContract", b =>
                {
                    b.HasOne("ISD_Project.Server.Models.Customer", "Customer")
                        .WithMany("InsuranceContracts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISD_Project.Server.Models.Insurance", "Insurance")
                        .WithMany("InsuranceContracts")
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Insurance");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.ApprovalStatus", b =>
                {
                    b.HasOne("ISD_Project.Server.Models.Customer", "Customer")
                        .WithMany("ApprovalStatuses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISD_Project.Server.Models.Insurance", "Insurance")
                        .WithMany("ApprovalStatuses")
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISD_Project.Server.Models.ValidationDepartment", "ValidationDepartment")
                        .WithMany("ApprovalStatuses")
                        .HasForeignKey("ValidationDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Insurance");

                    b.Navigation("ValidationDepartment");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.HealthInformation", b =>
                {
                    b.HasOne("ISD_Project.Server.Models.Customer", "Customer")
                        .WithOne("HealthInformation")
                        .HasForeignKey("ISD_Project.Server.Models.HealthInformation", "CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.Insurance", b =>
                {
                    b.HasOne("ISD_Project.Server.Models.DTOs.InsuranceType", "InsuranceType")
                        .WithMany("Insurances")
                        .HasForeignKey("InsuranceTypeId");

                    b.Navigation("InsuranceType");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.UserAccount", b =>
                {
                    b.HasOne("ISD_Project.Server.Models.User", "User")
                        .WithOne("UserAccount")
                        .HasForeignKey("ISD_Project.Server.Models.UserAccount", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.UserRole", b =>
                {
                    b.HasOne("ISD_Project.Server.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISD_Project.Server.Models.UserAccount", "UserAccount")
                        .WithOne("UserRole")
                        .HasForeignKey("ISD_Project.Server.Models.UserRole", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.DTOs.InsuranceType", b =>
                {
                    b.Navigation("Insurances");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.Insurance", b =>
                {
                    b.Navigation("ApprovalStatuses");

                    b.Navigation("InsuranceContracts");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.User", b =>
                {
                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.UserAccount", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.Customer", b =>
                {
                    b.Navigation("ApprovalStatuses");

                    b.Navigation("HealthInformation");

                    b.Navigation("InsuranceContracts");
                });

            modelBuilder.Entity("ISD_Project.Server.Models.ValidationDepartment", b =>
                {
                    b.Navigation("ApprovalStatuses");
                });
#pragma warning restore 612, 618
        }
    }
}

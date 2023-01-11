﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vacancies.Persistence.EF;

#nullable disable

namespace Vacancies.Persistence.Migrations
{
    [DbContext(typeof(VacanciesDbContext))]
    [Migration("20221120203128_UpdateSkillTableRelation")]
    partial class UpdateSkillTableRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Vacancies.Persistence.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category_name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.CurriculumVitae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int?>("ExpectedSalary")
                        .HasColumnType("integer")
                        .HasColumnName("expected_salary");

                    b.Property<DateTime>("ExpiresOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expires_on");

                    b.Property<string>("Gender")
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("position");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("published_on");

                    b.Property<string>("Region")
                        .HasColumnType("text")
                        .HasColumnName("region");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_curriculum_vitaes");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_curriculum_vitaes_category_id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_curriculum_vitaes_email");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasDatabaseName("ix_curriculum_vitaes_phone");

                    b.ToTable("curriculum_vitaes", (string)null);
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.CurriculumVitae_Skill", b =>
                {
                    b.Property<int>("CurriculumVitaeId")
                        .HasColumnType("integer")
                        .HasColumnName("curriculum_vitae_id");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer")
                        .HasColumnName("skill_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.HasKey("CurriculumVitaeId", "SkillId")
                        .HasName("pk_curriculum_vitae_skills");

                    b.HasIndex("SkillId")
                        .HasDatabaseName("ix_curriculum_vitae_skills_skill_id");

                    b.ToTable("curriculum_vitae_skills", (string)null);
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("CurriculumId")
                        .HasColumnType("integer")
                        .HasColumnName("curriculum_id");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("degree");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("institution");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("profession");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id")
                        .HasName("pk_educations");

                    b.HasIndex("CurriculumId")
                        .HasDatabaseName("ix_educations_curriculum_id");

                    b.ToTable("educations", (string)null);
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("CurriculumId")
                        .HasColumnType("integer")
                        .HasColumnName("curriculum_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("job_title");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id")
                        .HasName("pk_experiences");

                    b.HasIndex("CurriculumId")
                        .HasDatabaseName("ix_experiences_curriculum_id");

                    b.ToTable("experiences", (string)null);
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_skills");

                    b.ToTable("skills", (string)null);
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgeRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("age_requirement");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("integer")
                        .HasColumnName("contact_number");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("education");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int>("Experience")
                        .HasColumnType("integer")
                        .HasColumnName("experience");

                    b.Property<DateTime>("ExpiresOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expires_on");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("job_title");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("published_on");

                    b.Property<string>("Recruiter")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recruiter");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("region");

                    b.Property<int>("Salary")
                        .HasColumnType("integer")
                        .HasColumnName("salary");

                    b.HasKey("Id")
                        .HasName("pk_vacancies");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_vacancies_category_id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_vacancies_email");

                    b.ToTable("vacancies", (string)null);
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Vacancy_Skill", b =>
                {
                    b.Property<int>("VacancyId")
                        .HasColumnType("integer")
                        .HasColumnName("vacancy_id");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer")
                        .HasColumnName("skill_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.HasKey("VacancyId", "SkillId")
                        .HasName("pk_vacancy_skills");

                    b.HasIndex("SkillId")
                        .HasDatabaseName("ix_vacancy_skills_skill_id");

                    b.ToTable("vacancy_skills", (string)null);
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.CurriculumVitae", b =>
                {
                    b.HasOne("Vacancies.Persistence.Entities.Category", "Category")
                        .WithMany("CurriculumVitaes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("fk_curriculum_vitaes_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.CurriculumVitae_Skill", b =>
                {
                    b.HasOne("Vacancies.Persistence.Entities.CurriculumVitae", "CurriculumVitae")
                        .WithMany("CurriculumVitae_Skills")
                        .HasForeignKey("CurriculumVitaeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("fk_curriculum_vitae_skills_curriculum_vitaes_curriculum_vitae_");

                    b.HasOne("Vacancies.Persistence.Entities.Skill", "Skill")
                        .WithMany("CurriculumVitae_Skills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("fk_curriculum_vitae_skills_skills_skill_id");

                    b.Navigation("CurriculumVitae");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Education", b =>
                {
                    b.HasOne("Vacancies.Persistence.Entities.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Educations")
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_educations_curriculum_vitaes_curriculum_vitae_id");

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Experience", b =>
                {
                    b.HasOne("Vacancies.Persistence.Entities.CurriculumVitae", "CurriculumVitae")
                        .WithMany("Experiences")
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_experiences_curriculum_vitaes_curriculum_vitae_id");

                    b.Navigation("CurriculumVitae");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Vacancy", b =>
                {
                    b.HasOne("Vacancies.Persistence.Entities.Category", "Category")
                        .WithMany("Vacancies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("fk_vacancies_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Vacancy_Skill", b =>
                {
                    b.HasOne("Vacancies.Persistence.Entities.Skill", "Skill")
                        .WithMany("Vacancy_Skills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vacancy_skills_skills_skill_id");

                    b.HasOne("Vacancies.Persistence.Entities.Vacancy", "Vacancy")
                        .WithMany("Vacancy_Skills")
                        .HasForeignKey("VacancyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vacancy_skills_vacancies_vacancy_id");

                    b.Navigation("Skill");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Category", b =>
                {
                    b.Navigation("CurriculumVitaes");

                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.CurriculumVitae", b =>
                {
                    b.Navigation("CurriculumVitae_Skills");

                    b.Navigation("Educations");

                    b.Navigation("Experiences");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Skill", b =>
                {
                    b.Navigation("CurriculumVitae_Skills");

                    b.Navigation("Vacancy_Skills");
                });

            modelBuilder.Entity("Vacancies.Persistence.Entities.Vacancy", b =>
                {
                    b.Navigation("Vacancy_Skills");
                });
#pragma warning restore 612, 618
        }
    }
}

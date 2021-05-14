﻿// <auto-generated />
using System;
using Lab.Quiz.NewDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab.Quiz.NewDAL.Migrations
{
    [DbContext(typeof(QuizDBContext))]
    partial class QuizDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab.Quiz.NewDAL.Models.CardAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRight")
                        .HasColumnType("bit");

                    b.Property<long?>("QuizCardId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuizCardId");

                    b.ToTable("CardAnswers");
                });

            modelBuilder.Entity("Lab.Quiz.NewDAL.Models.Quiz", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("Lab.Quiz.NewDAL.Models.QuizCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardType")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuizCards");
                });

            modelBuilder.Entity("Lab.Quiz.NewDAL.Models.QuizCardWithProgramCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExpectedOutgoingData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncomingData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("MaximumExecutionTime")
                        .HasColumnType("time");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuizCardsWithProgramCode");
                });

            modelBuilder.Entity("QuizQuizCard", b =>
                {
                    b.Property<long>("QuizCardsId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuizzesId")
                        .HasColumnType("bigint");

                    b.HasKey("QuizCardsId", "QuizzesId");

                    b.HasIndex("QuizzesId");

                    b.ToTable("QuizQuizCard");
                });

            modelBuilder.Entity("QuizQuizCardWithProgramCode", b =>
                {
                    b.Property<long>("QuizCardsWithProgramCodeId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuizzesId")
                        .HasColumnType("bigint");

                    b.HasKey("QuizCardsWithProgramCodeId", "QuizzesId");

                    b.HasIndex("QuizzesId");

                    b.ToTable("QuizQuizCardWithProgramCode");
                });

            modelBuilder.Entity("Lab.Quiz.NewDAL.Models.CardAnswer", b =>
                {
                    b.HasOne("Lab.Quiz.NewDAL.Models.QuizCard", "QuizCard")
                        .WithMany("CardAnswers")
                        .HasForeignKey("QuizCardId");

                    b.Navigation("QuizCard");
                });

            modelBuilder.Entity("QuizQuizCard", b =>
                {
                    b.HasOne("Lab.Quiz.NewDAL.Models.QuizCard", null)
                        .WithMany()
                        .HasForeignKey("QuizCardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab.Quiz.NewDAL.Models.Quiz", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizQuizCardWithProgramCode", b =>
                {
                    b.HasOne("Lab.Quiz.NewDAL.Models.QuizCardWithProgramCode", null)
                        .WithMany()
                        .HasForeignKey("QuizCardsWithProgramCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab.Quiz.NewDAL.Models.Quiz", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lab.Quiz.NewDAL.Models.QuizCard", b =>
                {
                    b.Navigation("CardAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
